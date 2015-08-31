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
        public static async Task<bool> ContainsAsync<TSource>(this IAsyncEnumerable<TSource> source, TSource value, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");

            var comparer = EqualityComparer<TSource>.Default;

            var e = await source.GetEnumerator(ct);
            ct.ThrowIfCancellationRequested();

            var x = await e.MoveNext(ct);
            while (x.IsValue)
            {
                ct.ThrowIfCancellationRequested();
                if (comparer.Equals(x.Value, value)) return true;
                x = await e.MoveNext(ct);
            }
            x.ThrowIfCanceledOrFaulted();
            ct.ThrowIfCancellationRequested();
            return false;
        }

        public static async Task<bool> ContainsAsync<TSource>(this IAsyncEnumerable<TSource> source, TSource value, IEqualityComparer<TSource> comparer, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");

            var e = await source.GetEnumerator(ct);
            ct.ThrowIfCancellationRequested();

            var x = await e.MoveNext(ct);
            while (x.IsValue)
            {
                ct.ThrowIfCancellationRequested();
                if (comparer.Equals(x.Value, value)) return true;
                x = await e.MoveNext(ct);
            }
            x.ThrowIfCanceledOrFaulted();
            ct.ThrowIfCancellationRequested();
            return false;
        }
    }
}
