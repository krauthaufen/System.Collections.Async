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
        /// Synchronously enumerates all items.
        /// </summary>
        public static IEnumerable<TSource> AsEnumerable<TSource>(this IAsyncEnumerable<TSource> source, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            var e = source.GetEnumerator(ct).Result;
            
            var x = e.MoveNext(ct).Result;
            while (x.IsValue)
            {
                x.ThrowIfCanceledOrFaulted();
                ct.ThrowIfCancellationRequested();
                yield return x.Value;
                x = e.MoveNext(ct).Result;
            }
            x.ThrowIfCanceledOrFaulted();
        }
    }
}
