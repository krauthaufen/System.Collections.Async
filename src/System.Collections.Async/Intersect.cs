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
        public static IAsyncEnumerable<TSource> Intersect<TSource>(this IAsyncEnumerable<TSource> first, IAsyncEnumerable<TSource> second, CancellationToken ct = default(CancellationToken))
        {
            if (first == null) throw new ArgumentNullException(nameof(first));
            if (second == null) throw new ArgumentNullException(nameof(second));
            if (ct.IsCancellationRequested) return FrozenEnumerable<TSource>.Canceled;

            return new _AsyncEnumerable<TSource>(async ct2 =>
            {
                IEqualityComparer<TSource> comparer = EqualityComparer<TSource>.Default;

                var distinct = new HashSet<TSource>(comparer);
                var intersect = new HashSet<TSource>(comparer);
                IMoveNextResult<TSource> frozen = null;

                var s = await second.GetEnumerator(ct2);
                if (s.IsFrozen) return s;

                var x = await s.MoveNext(ct2);
                while (x.IsValue) intersect.Add(x.Value);
                switch (x.Status)
                {
                    case MoveNextStatus.Canceled:
                        return FrozenEnumerator<TSource>.Canceled;
                    case MoveNextStatus.Faulted:
                        return FrozenEnumerator<TSource>.Faulted(x.Exception);
                }

                var e = await first.GetEnumerator(ct2);
                if (e.IsFrozen) return e;

                return new _AsyncEnumerator<TSource>(async () =>
                {
                    if (frozen != null) return frozen;

                    while (true)
                    {
                        var y = await e.MoveNext(ct2);
                        if (y.IsValue)
                        {
                            if (!distinct.Add(y.Value) || !intersect.Contains(y.Value)) continue;
                            return y;
                        }
                        else
                        {
                            frozen = y;
                            return frozen;
                        }
                    }
                });
            });
        }

        public static IAsyncEnumerable<TSource> Intersect<TSource>(this IAsyncEnumerable<TSource> first, IAsyncEnumerable<TSource> second, IEqualityComparer<TSource> comparer, CancellationToken ct = default(CancellationToken))
        {
            if (first == null) throw new ArgumentNullException(nameof(first));
            if (second == null) throw new ArgumentNullException(nameof(second));
            if (ct.IsCancellationRequested) return FrozenEnumerable<TSource>.Canceled;

            return new _AsyncEnumerable<TSource>(async ct2 =>
            {
                var distinct = new HashSet<TSource>(comparer);
                var intersect = new HashSet<TSource>(comparer);
                IMoveNextResult<TSource> frozen = null;

                var s = await second.GetEnumerator(ct2);
                if (s.IsFrozen) return s;

                var x = await s.MoveNext(ct2);
                while (x.IsValue) intersect.Add(x.Value);
                switch (x.Status)
                {
                    case MoveNextStatus.Canceled:
                        return FrozenEnumerator<TSource>.Canceled;
                    case MoveNextStatus.Faulted:
                        return FrozenEnumerator<TSource>.Faulted(x.Exception);
                }

                var e = await first.GetEnumerator(ct2);
                if (e.IsFrozen) return e;

                return new _AsyncEnumerator<TSource>(async () =>
                {
                    if (frozen != null) return frozen;

                    while (true)
                    {
                        var y = await e.MoveNext(ct2);
                        if (y.IsValue)
                        {
                            if (!distinct.Add(y.Value) || !intersect.Contains(y.Value)) continue;
                            return y;
                        }
                        else
                        {
                            frozen = y;
                            return frozen;
                        }
                    }
                });
            });
        }

        public static IAsyncEnumerable<TSource> Intersect<TSource>(this IAsyncEnumerable<TSource> first, IEnumerable<TSource> second, CancellationToken ct = default(CancellationToken))
        {
            if (first == null) throw new ArgumentNullException(nameof(first));
            if (second == null) throw new ArgumentNullException(nameof(second));
            if (ct.IsCancellationRequested) return FrozenEnumerable<TSource>.Canceled;

            return new _AsyncEnumerable<TSource>(async ct2 =>
            {
                var comparer = EqualityComparer<TSource>.Default;

                var distinct = new HashSet<TSource>(comparer);
                var intersect = new HashSet<TSource>(second, comparer);
                IMoveNextResult<TSource> frozen = null;

                var e = await first.GetEnumerator(ct2);
                if (e.IsFrozen) return e;

                return new _AsyncEnumerator<TSource>(async () =>
                {
                    if (frozen != null) return frozen;

                    while (true)
                    {
                        var x = await e.MoveNext(ct2);
                        if (x.IsValue)
                        {
                            if (!distinct.Add(x.Value) || !intersect.Contains(x.Value)) continue;
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

        public static IAsyncEnumerable<TSource> Intersect<TSource>(this IAsyncEnumerable<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer, CancellationToken ct = default(CancellationToken))
        {
            if (first == null) throw new ArgumentNullException(nameof(first));
            if (second == null) throw new ArgumentNullException(nameof(second));
            if (ct.IsCancellationRequested) return FrozenEnumerable<TSource>.Canceled;

            return new _AsyncEnumerable<TSource>(async ct2 =>
            {
                var distinct = new HashSet<TSource>(comparer);
                var intersect = new HashSet<TSource>(second, comparer);
                IMoveNextResult<TSource> frozen = null;

                var e = await first.GetEnumerator(ct2);
                if (e.IsFrozen) return e;

                return new _AsyncEnumerator<TSource>(async () =>
                {
                    if (frozen != null) return frozen;

                    while (true)
                    {
                        var x = await e.MoveNext(ct2);
                        if (x.IsValue)
                        {
                            if (!distinct.Add(x.Value) || !intersect.Contains(x.Value)) continue;
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
