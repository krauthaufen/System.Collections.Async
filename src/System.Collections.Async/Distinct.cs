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
        public static IAsyncEnumerable<TSource> Distinct<TSource>(this IAsyncEnumerable<TSource> source, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");
            if (ct.IsCancellationRequested) return FrozenEnumerable<TSource>.Canceled;

            return new _AsyncEnumerable<TSource>(async ct2 =>
            {
                var e = await source.GetEnumerator(ct2);
                if (e.IsFrozen) return e;

                IMoveNextResult<TSource> frozen = null;
                var seen = new HashSet<TSource>();
                return new _AsyncEnumerator<TSource>(async () =>
                {
                    if (frozen != null) return frozen;

                    while (true)
                    {
                        var x = await e.MoveNext(ct);
                        if (x.IsValue)
                        {
                            if (seen.Contains(x.Value)) continue;
                            seen.Add(x.Value);
                            return x;
                        }
                        else
                        {
                            frozen = x;
                            return frozen;
                        }
                    }
                });
            });
        }
    }
}
