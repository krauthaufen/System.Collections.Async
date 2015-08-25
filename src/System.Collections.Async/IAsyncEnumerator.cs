using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System.Collections.Async
{
    public interface IAsyncEnumerator<out T>
    {
        /// <summary>
        /// Gets the current element in the collection.
        /// </summary>
        T Current { get; }

        /// <summary>
        /// Advances the enumerator to the next element of the collection.
        /// Returns true if the enumerator successfully advanced to the next element;
        /// false if it passed the end of the collection.
        /// </summary>
        Task<bool> MoveNext(CancellationToken ct);
    }
}
