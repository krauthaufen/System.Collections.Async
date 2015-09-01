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
        public static IAsyncEnumerable<TSource> Where<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");
            if (predicate == null) throw new ArgumentNullException("predicate");
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
                        return FrozenEnumerator<TSource>.Completed;
                }

                return new _AsyncEnumerator<TSource>(async () =>
                {
                    while (true)
                    {
                        var x = await e.MoveNext(ct2);
                        if (x.IsValue && !predicate(x.Value)) continue;
                        return x;
                    }
                });
            });
        }

        public static IAsyncEnumerable<TSource> Where<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, int, bool> predicate, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");
            if (predicate == null) throw new ArgumentNullException("predicate");
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
                        return FrozenEnumerator<TSource>.Completed;
                }

                var i = 0;
                return new _AsyncEnumerator<TSource>(async () =>
                {
                    while (true)
                    {
                        var x = await e.MoveNext(ct2);
                        if (x.IsValue && !predicate(x.Value, i++)) continue;
                        return x;
                    }
                });
            });
        }
    }
}
