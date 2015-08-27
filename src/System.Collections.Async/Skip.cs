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
        public static IAsyncEnumerable<TSource> Skip<TSource>(this IAsyncEnumerable<TSource> source, int count, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");

            return new _AsyncEnumerable<TSource>(async ct2 =>
            {
                var skipped = 0;
                var e = await source.GetEnumerator(ct2);
                return new _AsyncEnumerator<TSource>(async () =>
                {
                    while (true)
                    {
                        var next = await e.MoveNext(ct);
                        if (skipped++ < count) continue;
                        if (next)
                        {
                            return Tuple.Create(e.Current, true);
                        }
                        else
                        {
                            return Tuple.Create(default(TSource), false);
                        }
                    }
                });
            });
        }
    }
}
