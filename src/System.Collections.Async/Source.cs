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
        public static IAsyncEnumerableSource<T> Source<T>()
        {
            return new _AsyncEnumerableSource<T>();
        }
    }

    internal class _AsyncEnumerableSource<T> : IAsyncEnumerableSource<T>
    {
        private class _Enumerator : IAsyncEnumerator<T>
        {
            private _AsyncEnumerableSource<T> _parent;

            public _Enumerator(_AsyncEnumerableSource<T> parent)
            {
                _parent = parent;
            }

            public Exception Exception => null;

            public MoveNextStatus Status => _parent._status;

            public Task<IMoveNextResult<T>> MoveNext(CancellationToken ct)
            {
                return _parent._moveNext.Task;
            }
        }

        public _AsyncEnumerableSource()
        {
            _enumerator = Task.FromResult<IAsyncEnumerator<T>>(new _Enumerator(this));
            _moveNext = new TaskCompletionSource<IMoveNextResult<T>>();
        }

        private SemaphoreSlim _semaphore = new SemaphoreSlim(1);
        private Task<IAsyncEnumerator<T>> _enumerator;
        private int _subscribersCount = 0;
        private MoveNextStatus _status = MoveNextStatus.None;

        private TaskCompletionSource<IMoveNextResult<T>> _moveNext;
        
        public async Task Yield(T value)
        {
            try
            {
                await _semaphore.WaitAsync();

                if (_status == MoveNextStatus.Completed || _subscribersCount == 0) return;

                var moveNext = _moveNext;
                _moveNext = new TaskCompletionSource<IMoveNextResult<T>>();

                _status = MoveNextStatus.Value;
                moveNext.SetResult(MoveNext.Value(value));
            }
            finally
            {
                _semaphore.Release();
            }
        }

        public async Task Break()
        {
            try
            {
                await _semaphore.WaitAsync();

                if (_status == MoveNextStatus.Completed) return;

                _status = MoveNextStatus.Completed;
                _moveNext.SetResult(MoveNext.Completed<T>());
            }
            finally
            {
                _semaphore.Release();
            }
        }

        public int SubscribersCount => _subscribersCount;

        public Task<IAsyncEnumerator<T>> GetEnumerator(CancellationToken ct)
        {
            ct.ThrowIfCancellationRequested();

            Interlocked.Increment(ref _subscribersCount);
            return _enumerator;
        }
    }
}
