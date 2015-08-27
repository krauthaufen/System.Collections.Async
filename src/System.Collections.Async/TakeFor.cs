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
        public static IAsyncEnumerable<TSource> TakeFor<TSource>(this IAsyncEnumerable<TSource> source, TimeSpan duration, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");

            return new _AsyncEnumerable<TSource>(async ct2 =>
            {
                var stop = DateTime.UtcNow + duration;
                var e = await source.GetEnumerator(ct2);
                return new _AsyncEnumerator<TSource>(async () =>
                {
                    var isValid = await e.MoveNext(ct);
                    if (isValid && DateTime.UtcNow < stop)
                    {
                        return Tuple.Create(e.Current, true);
                    }
                    else
                    {
                        return Tuple.Create(default(TSource), false);
                    }
                });
            });
        }
    }
}
