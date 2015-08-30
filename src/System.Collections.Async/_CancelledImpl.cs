using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System.Collections.Async
{
    internal class _AsyncEnumeratorCancelled<T> : IAsyncEnumerator<T>
    {
        Task<IMoveNextResult<T>> IAsyncEnumerator<T>.MoveNext(CancellationToken ct)
        {
            return Task.FromResult(MoveNext.Cancelled<T>());
        }
    }
}
