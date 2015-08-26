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
        public static IAsyncEnumerable<TSource> ConcatAsync<TSource>(this IAsyncEnumerable<TSource> first, IAsyncEnumerable<TSource> second, CancellationToken ct = default(CancellationToken))
        {
            if (first == null) throw new ArgumentNullException("first");
            if (second == null) throw new ArgumentNullException("second");

            return new _AsyncEnumerable<TSource>(async ct2 =>
            {
                var e = await first.GetEnumerator(ct2);
                var switched = false;
                return new _AsyncEnumerator<TSource>(async () =>
                {
                    while (true)
                    {
                        if (await e.MoveNext(ct))
                        {
                            return Tuple.Create(e.Current, true);
                        }
                        else
                        {
                            if (switched)
                            {
                                return Tuple.Create(default(TSource), false);
                            }
                            else
                            {
                                e = await second.GetEnumerator(ct2);
                                switched = true;
                            }
                        }
                    }
                });
            });
        }
    }
}
