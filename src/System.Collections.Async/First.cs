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
        public static async Task<TSource> FirstAsync<TSource>(this IAsyncEnumerable<TSource> source, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");

            var e = await source.GetEnumerator(ct);
            if (await e.MoveNext(ct))
            {
                return e.Current;
            }
            throw new InvalidOperationException();
        }

        public static async Task<TSource> FirstAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");
            if (predicate == null) throw new ArgumentNullException("predicate");

            var e = await source.GetEnumerator(ct);
            while (await e.MoveNext(ct))
            {
                if (predicate(e.Current)) return e.Current;
            }
            throw new InvalidOperationException();
        }
    }
}
