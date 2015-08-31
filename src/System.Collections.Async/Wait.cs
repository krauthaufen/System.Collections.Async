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
        /// <summary>
        /// Waits synchronously for the source to complete.
        /// </summary>
        public static void Wait<T>(this IAsyncEnumerable<T> source, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");

            var e = source.GetEnumerator(ct).Result;
            ct.ThrowIfCancellationRequested();

            var x = e.MoveNext(ct).Result;
            while (x.IsValue)
            {
                ct.ThrowIfCancellationRequested();
                x = e.MoveNext(ct).Result;
            }
            x.ThrowIfCancelledOrFaulted();
            ct.ThrowIfCancellationRequested();
        }
    }
}
