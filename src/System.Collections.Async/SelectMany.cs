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
        public static IAsyncEnumerable<TResult> SelectMany<TSource, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, IEnumerable<TResult>> selector, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");
            if (selector == null) throw new ArgumentNullException("selector");
            
            return new _AsyncEnumerable<TResult>(async ct2 =>
            {
                var outer = await source.GetEnumerator(ct2);
                ct.ThrowIfCancellationRequested();
                ct2.ThrowIfCancellationRequested();

                var x = await outer.MoveNext(ct2);
                ct.ThrowIfCancellationRequested();
                ct2.ThrowIfCancellationRequested();
                if (!x.IsValue)
                {
                    x.ThrowIfCancelledOrFaulted();
                    return new _AsyncEnumeratorEmpty<TResult>();
                }

                var inner = selector(x.Value).GetEnumerator();
                return new _AsyncEnumerator<TResult>(async () =>
                {
                    while (true)
                    {
                        if (inner.MoveNext())
                        {
                            return MoveNext.Value(inner.Current);
                        }
                        else
                        {
                            x = await outer.MoveNext(ct2);
                            ct.ThrowIfCancellationRequested();
                            ct2.ThrowIfCancellationRequested();

                            if (x.IsValue)
                            {
                                inner = selector(x.Value).GetEnumerator();
                            }
                            else
                            {
                                x.ThrowIfCancelledOrFaulted();
                                return MoveNext.Completed<TResult>();
                            }
                        }
                    }
                });
            });
        }
    }
}
