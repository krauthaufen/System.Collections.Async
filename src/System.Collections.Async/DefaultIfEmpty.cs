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
            if (ct.IsCancellationRequested) return FrozenEnumerable<TSource>.Canceled;

            return new _AsyncEnumerable<TSource>(async ct2 =>
            {
                var e = await source.GetEnumerator(ct2);
                switch (e.Status)
                {
                    case MoveNextStatus.Canceled:
                        return FrozenEnumerator<TSource>.Canceled;
                    case MoveNextStatus.Faulted:
                        return FrozenEnumerator<TSource>.Faulted(e.Exception);
                    case MoveNextStatus.Completed:
                        return await FromValue(defaultValue).GetEnumerator(ct2);
                    case MoveNextStatus.Value:
                        return e;
                }
                
                var x = await e.MoveNext(ct2);
                if (x.Status == MoveNextStatus.Completed) return await FromValue(defaultValue).GetEnumerator(ct2);

                return new _AsyncEnumerator<TSource>(async () =>
                {
                    var result = x;
                    x = await e.MoveNext(ct2);
                    return result;
                });
            });
        }
    }
}
