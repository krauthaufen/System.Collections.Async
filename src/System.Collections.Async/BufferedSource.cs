using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System.Collections.Async
{
    public static partial class AsyncEnumerable
    {
        public static IAsyncEnumerableSource<T> BufferedSource<T>()
        {
            return new _AsyncEnumerableBufferedSource<T>();
        }
    }

    internal class _AsyncEnumerableBufferedSource<T> : IAsyncEnumerableSource<T>
    {
        private class _Enumerator : IAsyncEnumerator<T>
        {
            private static int s_id = 0;

            private _AsyncEnumerableBufferedSource<T> _parent;
            private int _index = 0;
            private bool _isFrozen = false;
            private MoveNextStatus _status = MoveNextStatus.None;

            public _Enumerator(_AsyncEnumerableBufferedSource<T> parent)
            {
                _parent = parent;
                Interlocked.Increment(ref s_id);
            }

            public Exception Exception => null;

            public bool IsFrozen => _isFrozen;

            public MoveNextStatus Status => _status;

            public async Task<IMoveNextResult<T>> MoveNext(CancellationToken ct)
            {
                try
                {
                    var next = _parent._next;

                    Console.WriteLine($"[Source {s_id}] MoveNext, index == {_index}");
                    if (_index < _parent._buffer.Count)
                    {
                        var x = _parent._buffer[_index];
                        return Async.MoveNext.Value(x);
                    }

                    return await next.Task;
                }
                finally
                {
                    Interlocked.Increment(ref _index);
                }
            }
        }

        public _AsyncEnumerableBufferedSource()
        {
            _next = new TaskCompletionSource<IMoveNextResult<T>>();
        }

        private SemaphoreSlim _semaphore = new SemaphoreSlim(1);
        private int _subscribersCount = 0;
        private bool _isFrozen = false;
        private List<T> _buffer = new List<T>();
        private TaskCompletionSource<IMoveNextResult<T>> _next;

        public async Task Yield(T value)
        {
            await _semaphore.WaitAsync();

            try
            {
                if (_isFrozen) return;

                _buffer.Add(value);

                var next = _next;
                _next = new TaskCompletionSource<IMoveNextResult<T>>();
                next.SetResult(MoveNext.Value(value));
            }
            finally
            {
                _semaphore.Release();
            }
        }

        public async Task Break()
        {
            await _semaphore.WaitAsync();

            try
            {
                if (_isFrozen) return;

                _isFrozen = true;
                _next.SetResult(MoveNext.Completed<T>());
            }
            finally
            {
                _semaphore.Release();
            }
        }

        public int SubscribersCount => _subscribersCount;

        public async Task<IAsyncEnumerator<T>> GetEnumerator(CancellationToken ct)
        {
            ct.ThrowIfCancellationRequested();

            await _semaphore.WaitAsync();

            try
            {
                Interlocked.Increment(ref _subscribersCount);
                return new _Enumerator(this);
            }
            finally
            {
                _semaphore.Release();
            }
        }
    }
}
