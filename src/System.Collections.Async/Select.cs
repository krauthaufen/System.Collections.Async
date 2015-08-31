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
                if (ct.IsCancellationRequested || ct2.IsCancellationRequested) return _CanceledEnumerator<TResult>.Default;

                var e = await source.GetEnumerator(ct2);
                switch (e.Status)
                {
                    case MoveNextStatus.Canceled:
                        return _CanceledEnumerator<TResult>.Default;
                    case MoveNextStatus.Faulted:
                        return new _FaultedEnumerator<TResult>(e.Exception);
                    case MoveNextStatus.Completed:
                        return _EmptyEnumerator<TResult>.Default;
                }

                return new _AsyncEnumerator<TResult>(async () =>
                {
                    if (ct.IsCancellationRequested || ct2.IsCancellationRequested) return MoveNext.Canceled<TResult>();

                    var x = await e.MoveNext(ct);

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
