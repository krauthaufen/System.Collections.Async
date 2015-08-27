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
        public static IAsyncEnumerable<TSource> DefaultIfEmpty<TSource>(this IAsyncEnumerable<TSource> source, CancellationToken ct = default(CancellationToken))
        {
            return DefaultIfEmpty(source, default(TSource), ct);
        }

        public static IAsyncEnumerable<TSource> DefaultIfEmpty<TSource>(this IAsyncEnumerable<TSource> source, TSource defaultValue, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");

            return new _AsyncEnumerable<TSource>(async ct2 =>
            {
                var e = await source.GetEnumerator(ct2);
                var empty = true;
                return new _AsyncEnumerator<TSource>(async () =>
                {
                    if (await e.MoveNext(ct))
                    {
                        empty = false;
                        return Tuple.Create(e.Current, true);
                    }
                    else
                    {
                        if (empty)
                        {
                            empty = false;
                            return Tuple.Create(defaultValue, true);
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
