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
        public static IAsyncEnumerable<TSource> Take<TSource>(this IAsyncEnumerable<TSource> source, int count, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");
            if (ct.IsCancellationRequested) return _CanceledEnumerable<TSource>.Default;

            return new _AsyncEnumerable<TSource>(async ct2 =>
            {
                var taken = 0;
                var e = await source.GetEnumerator(ct2);
                switch (e.Status)
                {
                    case MoveNextStatus.Canceled:
                        return _CanceledEnumerator<TSource>.Default;
                    case MoveNextStatus.Faulted:
                        return new _FaultedEnumerator<TSource>(e.Exception);
                    case MoveNextStatus.Completed:
                        return _EmptyEnumerator<TSource>.Default;
                }

                return new _AsyncEnumerator<TSource>(async () =>
                {
                    if (ct.IsCancellationRequested) return MoveNext<TSource>.Canceled;
                    if (taken >= count) return MoveNext<TSource>.Completed;

                    taken++;
                    return await e.MoveNext(ct);
                });
            });
        }
    }
}
