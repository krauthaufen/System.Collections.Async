using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System.Collections.Async
{
    internal class _AsyncEnumeratorFaulted<T> : IAsyncEnumerator<T>
    {
        private Exception _exception;

        public _AsyncEnumeratorFaulted(Exception e)
        {
            _exception = e;
        }

        Task<IMoveNextResult<T>> IAsyncEnumerator<T>.MoveNext(CancellationToken ct)
        {
            return Task.FromResult(MoveNext.Faulted<T>(_exception));
        }
    }
}
