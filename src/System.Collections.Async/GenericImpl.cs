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
            ct.ThrowIfCancellationRequested();
            return _createEnumerator(ct);
        }
    }

    internal class _AsyncEnumerator<T> : IAsyncEnumerator<T>
    {
        private Func<Task<Tuple<T, bool>>> _next;
        private T _current;

        public _AsyncEnumerator(Func<Task<Tuple<T, bool>>> next)
        {
            _next = next;
        }

        public T Current => _current;

        public async Task<bool> MoveNext(CancellationToken ct)
        {
            var x = await _next();
            if (x.Item2) _current = x.Item1;
            return x.Item2;
        }
    }
}
