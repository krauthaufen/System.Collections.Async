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
            if (ct.IsCancellationRequested) return FrozenEnumerable<TSource>.Canceled;

            return new _AsyncEnumerable<TSource>(async ct2 =>
            {
                var e = await source.GetEnumerator(ct2);
                if (e.IsFrozen) return e;

                IMoveNextResult<TSource> frozen = null;
                var taken = 0;
                return new _AsyncEnumerator<TSource>(async () =>
                {
                    if (frozen != null) return frozen;

                    var x = await e.MoveNext(ct);
                    if (x.IsValue)
                    {
                        if (taken++ < count) return x;
                        else frozen = MoveNext.Completed<TSource>();
                    }
                    else
                    {
                        frozen = x;
                    }
                    return frozen;
                });
            });
        }
    }
}
