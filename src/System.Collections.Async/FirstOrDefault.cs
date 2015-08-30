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
        public static async Task<TSource> FirstOrDefaultAsync<TSource>(this IAsyncEnumerable<TSource> source, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");

            var e = await source.GetEnumerator(ct);
            ct.ThrowIfCancellationRequested();

            var x = await e.MoveNext(ct);
            x.ThrowIfCancelledOrFaulted();

            return x.IsValue ? x.Value : default(TSource);
        }

        public static async Task<TSource> FirstOrDefaultAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");
            if (predicate == null) throw new ArgumentNullException("predicate");

            var e = await source.GetEnumerator(ct);
            ct.ThrowIfCancellationRequested();

            var x = await e.MoveNext(ct);
            while (x.IsValue)
            {
                x.ThrowIfCancelledOrFaulted();
                if (predicate(x.Value)) return x.Value;
                x = await e.MoveNext(ct);
            }
            x.ThrowIfCancelledOrFaulted();
            return default(TSource);
        }
    }
}
