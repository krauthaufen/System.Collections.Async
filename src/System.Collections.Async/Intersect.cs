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
            if (first == null) throw new ArgumentNullException("first");
            if (second == null) throw new ArgumentNullException("second");

            return new _AsyncEnumerable<TSource>(async ct2 =>
            {
                IEqualityComparer<TSource> comparer = EqualityComparer<TSource>.Default;

                var distinct = new HashSet<TSource>(comparer);
                var intersect = new HashSet<TSource>(comparer);
                var s = await second.GetEnumerator(ct2);
                while (await s.MoveNext(ct2)) intersect.Add(s.Current);

                var e = await first.GetEnumerator(ct2);
                return new _AsyncEnumerator<TSource>(async () =>
                {
                    while (true)
                    {
                        if (await e.MoveNext(ct))
                        {
                            if (!distinct.Add(e.Current) || !intersect.Contains(e.Current)) continue;
                            return Tuple.Create(e.Current, true);
                        }
                        else
                        {
                            return Tuple.Create(default(TSource), false);
                        }
                    }
                });
            });
        }

        public static IAsyncEnumerable<TSource> Intersect<TSource>(this IAsyncEnumerable<TSource> first, IAsyncEnumerable<TSource> second, IEqualityComparer<TSource> comparer, CancellationToken ct = default(CancellationToken))
        {
            if (first == null) throw new ArgumentNullException("first");
            if (second == null) throw new ArgumentNullException("second");

            return new _AsyncEnumerable<TSource>(async ct2 =>
            {
                var distinct = new HashSet<TSource>(comparer);
                var intersect = new HashSet<TSource>(comparer);
                var s = await second.GetEnumerator(ct2);
                while (await s.MoveNext(ct2)) intersect.Add(s.Current);

                var e = await first.GetEnumerator(ct2);
                return new _AsyncEnumerator<TSource>(async () =>
                {
                    while (true)
                    {
                        if (await e.MoveNext(ct))
                        {
                            if (!distinct.Add(e.Current) || !intersect.Contains(e.Current)) continue;
                            return Tuple.Create(e.Current, true);
                        }
                        else
                        {
                            return Tuple.Create(default(TSource), false);
                        }
                    }
                });
            });
        }

        public static IAsyncEnumerable<TSource> Intersect<TSource>(this IAsyncEnumerable<TSource> first, IEnumerable<TSource> second, CancellationToken ct = default(CancellationToken))
        {
            if (first == null) throw new ArgumentNullException("first");
            if (second == null) throw new ArgumentNullException("second");
            
            return new _AsyncEnumerable<TSource>(async ct2 =>
            {
                var comparer = EqualityComparer<TSource>.Default;

                var distinct = new HashSet<TSource>(comparer);
                var intersect = new HashSet<TSource>(second, comparer);

                var e = await first.GetEnumerator(ct2);
                return new _AsyncEnumerator<TSource>(async () =>
                {
                    while (true)
                    {
                        if (await e.MoveNext(ct))
                        {
                            if (!distinct.Add(e.Current) || !intersect.Contains(e.Current)) continue;
                            return Tuple.Create(e.Current, true);
                        }
                        else
                        {
                            return Tuple.Create(default(TSource), false);
                        }
                    }
                });
            });
        }

        public static IAsyncEnumerable<TSource> Intersect<TSource>(this IAsyncEnumerable<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer, CancellationToken ct = default(CancellationToken))
        {
            if (first == null) throw new ArgumentNullException("first");
            if (second == null) throw new ArgumentNullException("second");

            return new _AsyncEnumerable<TSource>(async ct2 =>
            {
                var distinct = new HashSet<TSource>(comparer);
                var intersect = new HashSet<TSource>(second, comparer);

                var e = await first.GetEnumerator(ct2);
                return new _AsyncEnumerator<TSource>(async () =>
                {
                    while (true)
                    {
                        if (await e.MoveNext(ct))
                        {
                            if (!distinct.Add(e.Current) || !intersect.Contains(e.Current)) continue;
                            return Tuple.Create(e.Current, true);
                        }
                        else
                        {
                            return Tuple.Create(default(TSource), false);
                        }
                    }
                });
            });
        }
    }
}
