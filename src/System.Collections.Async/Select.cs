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

            if (ct.IsCancellationRequested) return _CanceledEnumerable<TResult>.Default;

            return new _AsyncEnumerable<TResult>(async ct2 =>
            {
                var e = await source.GetEnumerator(ct2);
                if (e.Status == MoveNextStatus.Canceled || ct.IsCancellationRequested || ct2.IsCancellationRequested) return new _CanceledEnumerator<TResult>();
                if (e.Status == MoveNextStatus.Faulted) return new _FaultedEnumerator<TResult>(e.Exception);
                
                return new _AsyncEnumerator<TResult>(async () =>
                {
                    var x = await e.MoveNext(ct);
                    if (ct.IsCancellationRequested || ct2.IsCancellationRequested) return MoveNext.Canceled<TResult>();

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
