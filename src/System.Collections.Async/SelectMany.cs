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

            if (ct.IsCancellationRequested) return FrozenEnumerable<TResult>.Canceled;

            return new _AsyncEnumerable<TResult>(async ct2 =>
            {
                if (ct.IsCancellationRequested || ct2.IsCancellationRequested) return FrozenEnumerator<TResult>.Canceled;

                var outer = await source.GetEnumerator(ct2);
                if (outer.IsFrozen) return outer.Convert<TSource, TResult>();

                var x = await outer.MoveNext(ct2);
                if (x.Status.IsFrozen()) return outer.Convert<TSource, TResult>();
                
                var inner = selector(x.Value).GetEnumerator();
                return new _AsyncEnumerator<TResult>(async () =>
                {
                    if (ct.IsCancellationRequested || ct2.IsCancellationRequested) return MoveNext.Canceled<TResult>();

                    while (true)
                    {
                        if (inner.MoveNext())
                        {
                            return MoveNext.Value(inner.Current);
                        }
                        else
                        {
                            x = await outer.MoveNext(ct2);

                            if (x.IsValue)
                            {
                                inner = selector(x.Value).GetEnumerator();
                            }
                            else
                            {
                                return MoveNext.Convert<TSource, TResult>(x);
                            }
                        }
                    }
                });
            });
        }
    }
}
