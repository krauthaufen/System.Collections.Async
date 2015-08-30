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
        public static IAsyncEnumerable<TResult> Select<TSource, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, TResult> selector, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");
            if (selector == null) throw new ArgumentNullException("selector");

            return new _AsyncEnumerable<TResult>(async ct2 =>
            {
                var e = await source.GetEnumerator(ct2);
                
                return new _AsyncEnumerator<TResult>(async () =>
                {
                    var x = await e.MoveNext(ct);
                    ct2.ThrowIfCancellationRequested();

                    if (x.IsValue)
                    {
                        try
                        {
                            return MoveNext.Value(selector(x.Value));
                        }
                        catch (Exception ex)
                        {
                            return MoveNext.Faulted<TResult>(ex);
                        }
                    }
                    else
                    {
                        return MoveNext.Convert<TSource, TResult>(x);
                    }
                });
            });
        }
    }
}
