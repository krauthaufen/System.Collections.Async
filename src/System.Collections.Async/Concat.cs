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
        public static IAsyncEnumerable<TSource> Concat<TSource>(this IAsyncEnumerable<TSource> first, IAsyncEnumerable<TSource> second, CancellationToken ct = default(CancellationToken))
        {
            if (first == null) throw new ArgumentNullException("first");
            if (second == null) throw new ArgumentNullException("second");

            return new _AsyncEnumerable<TSource>(async ct2 =>
            {
                var e = await first.GetEnumerator(ct2);
                ct.ThrowIfCancellationRequested();
                ct2.ThrowIfCancellationRequested();

                var switched = false;
                return new _AsyncEnumerator<TSource>(async () =>
                {
                    while (true)
                    {
                        var x = await e.MoveNext(ct2);
                        ct.ThrowIfCancellationRequested();
                        ct2.ThrowIfCancellationRequested();

                        if (x.IsValue)
                        {
                            return MoveNext.Value(x.Value);
                        }
                        else
                        {
                            if (switched)
                            {
                                return x;
                            }
                            else
                            {
                                e = await second.GetEnumerator(ct2);
                                ct.ThrowIfCancellationRequested();
                                ct2.ThrowIfCancellationRequested();
                                switched = true;
                            }
                        }
                    }
                });
            });
        }
    }
}
