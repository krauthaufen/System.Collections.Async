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
        public static async Task<TSource> LastAsync<TSource>(this IAsyncEnumerable<TSource> source, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");

            var e = await source.GetEnumerator(ct);
            if (await e.MoveNext(ct))
            {
                var latest = e.Current;
                while (await e.MoveNext(ct))
                {
                    latest = e.Current;
                }
                return latest;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public static async Task<TSource> LastAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");
            if (predicate == null) throw new ArgumentNullException("predicate");

            var e = await source.GetEnumerator(ct);
            var isValidResult = false;
            var latest = default(TSource);
            while (await e.MoveNext(ct))
            {
                if (predicate(e.Current))
                {
                    latest = e.Current;
                    isValidResult = true;
                }
            }
            if (isValidResult)
            {
                return latest;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }
}
