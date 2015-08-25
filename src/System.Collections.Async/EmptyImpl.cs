using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System.Collections.Async
{
    internal class _AsyncEnumeratorEmpty<T> : IAsyncEnumerator<T>
    {
        public T Current { get; }

        public Task<bool> MoveNext(CancellationToken ct)
        {
            return Task.FromResult(false);
        }
    }
}
