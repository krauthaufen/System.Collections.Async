using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System.Collections.Async
{
    internal class _AsyncEnumerable<T> : IAsyncEnumerable<T>
    {
        private Func<CancellationToken, Task<IAsyncEnumerator<T>>> _createEnumerator;

        public _AsyncEnumerable(Func<CancellationToken, Task<IAsyncEnumerator<T>>> createEnumerator)
        {
            _createEnumerator = createEnumerator;
        }

        public _AsyncEnumerable(Func<CancellationToken, IAsyncEnumerator<T>> createEnumerator)
        {
            _createEnumerator = ct => Task.FromResult<IAsyncEnumerator<T>>(createEnumerator(ct));
        }

        public Task<IAsyncEnumerator<T>> GetEnumerator(CancellationToken ct)
        {
            if (ct.IsCancellationRequested) return Task.FromResult(FrozenEnumerator<T>.Canceled);
            return _createEnumerator(ct);
        }
    }

    internal class _AsyncEnumerator<T> : IAsyncEnumerator<T>
    {
        private Func<Task<IMoveNextResult<T>>> _next;

        public _AsyncEnumerator(Func<Task<IMoveNextResult<T>>> next)
        {
            Status = MoveNextStatus.None;
            _next = next;
        }

        public async Task<IMoveNextResult<T>> MoveNext(CancellationToken ct)
        {
            if (ct.IsCancellationRequested) return Async.MoveNext.Canceled<T>();
            var x = await _next();
            if (x.Status == MoveNextStatus.Faulted) Exception = x.Exception;
            Status = x.Status;
            return x;
        }
        
        public MoveNextStatus Status { get; private set; }

        public Exception Exception { get; private set; }

        public bool IsFrozen => Status != MoveNextStatus.None && Status != MoveNextStatus.Value;
    }
}
