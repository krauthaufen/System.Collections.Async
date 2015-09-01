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
        public static IAsyncEnumerable<TSource> TakeWhile<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            
            if (ct.IsCancellationRequested) return FrozenEnumerable<TSource>.Canceled;

            return new _AsyncEnumerable<TSource>(async ct2 =>
            {
                var e = await source.GetEnumerator(ct2);
                if (e.IsFrozen) return e;

                IMoveNextResult<TSource> frozen = null;
                return new _AsyncEnumerator<TSource>(async () =>
                {
                    if (ct.IsCancellationRequested) return MoveNext.Canceled<TSource>();
                    if (frozen != null) return frozen;
                    
                    var x = await e.MoveNext(ct);
                    if (x.IsValue)
                    {
                        if (predicate(x.Value)) return x;
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

        public static IAsyncEnumerable<TSource> TakeWhile<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, int, bool> predicate, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));

            if (ct.IsCancellationRequested) return FrozenEnumerable<TSource>.Canceled;

            return new _AsyncEnumerable<TSource>(async ct2 =>
            {
                var e = await source.GetEnumerator(ct2);
                if (e.IsFrozen) return e;

                IMoveNextResult<TSource> frozen = null;
                var index = 0;
                return new _AsyncEnumerator<TSource>(async () =>
                {
                    if (ct.IsCancellationRequested) return MoveNext.Canceled<TSource>();
                    if (frozen != null) return frozen;

                    var x = await e.MoveNext(ct);
                    if (x.IsValue)
                    {
                        if (predicate(x.Value, index++)) return x;
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
