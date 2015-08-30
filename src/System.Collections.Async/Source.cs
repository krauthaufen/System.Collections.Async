//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace System.Collections.Async
//{
//    public static partial class AsyncEnumerable
//    {
//        public static IAsyncEnumerableSource<T> Source<T>()
//        {
//            return new _AsyncEnumerableSource<T>();
//        }
//    }

//    internal class _AsyncEnumerableSource<T> : IAsyncEnumerableSource<T>
//    {
//        private class _Enumerator : IAsyncEnumerator<T>
//        {
//            private _AsyncEnumerableSource<T> _parent;

//            public _Enumerator(_AsyncEnumerableSource<T> parent)
//            {
//                _parent = parent;
//            }

//            public T Current
//            {
//                get
//                {
//                    if (_parent._isCompleted) throw new InvalidOperationException();
//                    return _parent._current;
//                }
//            }

//            public Task<bool> MoveNext(CancellationToken ct)
//            {
//                return _parent._moveNext.Task;
//            }
//        }

//        public _AsyncEnumerableSource()
//        {
//            _enumerator = Task.FromResult<IAsyncEnumerator<T>>(new _Enumerator(this));
//        }

//        private SemaphoreSlim _semaphore = new SemaphoreSlim(1);
//        private Task<IAsyncEnumerator<T>> _enumerator;
//        private int _subscribersCount = 0;
//        private bool _isCompleted = false;

//        private T _current;
//        private TaskCompletionSource<bool> _moveNext = new TaskCompletionSource<bool>();
//        private readonly Task DONE = Task.FromResult(0);

//        public async Task Yield(T value)
//        {
//            try
//            {
//                await _semaphore.WaitAsync();

//                if (_subscribersCount == 0 || _isCompleted) return;

//                var moveNext = _moveNext;
//                _moveNext = new TaskCompletionSource<bool>();

//                _current = value;
//                moveNext.SetResult(true);
//            }
//            finally
//            {
//                _semaphore.Release();
//            }
//        }

//        public async Task Break()
//        {
//            try
//            {
//                await _semaphore.WaitAsync();

//                if (_isCompleted) return;
//                _isCompleted = true;

//                _current = default(T);
//                _moveNext.SetResult(false);
//            }
//            finally
//            {
//                _semaphore.Release();
//            }
//        }

//        public int SubscribersCount => _subscribersCount;

//        public Task<IAsyncEnumerator<T>> GetEnumerator(CancellationToken ct)
//        {
//            ct.ThrowIfCancellationRequested();

//            Interlocked.Increment(ref _subscribersCount);
//            return _enumerator;
//        }
//    }
//}
