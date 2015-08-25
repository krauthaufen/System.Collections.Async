using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System.Collections.Async
{
    public interface IAsyncEnumerable<T>
    {
        /// <summary>
        /// Asynchronously gets enumerator.
        /// </summary>
        Task<IAsyncEnumerator<T>> GetEnumerator(CancellationToken ct);
    }
}
