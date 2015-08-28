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
        public static async Task<long> LongCountAsync<TSource>(this IAsyncEnumerable<TSource> source, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");

            var count = 0L;
            var e = await source.GetEnumerator(ct);
            while (await e.MoveNext(ct))
            {
                count++;
            }
            return count;
        }

        public static async Task<long> LongCountAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");
            if (predicate == null) throw new ArgumentNullException("predicate");

            var count = 0L;
            var e = await source.GetEnumerator(ct);
            while (await e.MoveNext(ct))
            {
                if (predicate(e.Current)) count++;
            }
            return count;
        }
    }
}
