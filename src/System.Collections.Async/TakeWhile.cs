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
        public static IAsyncEnumerable<TSource> TakeWhileAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate, CancellationToken ct)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (predicate == null) throw new ArgumentNullException("predicate");

            return new _AsyncEnumerable<TSource>(async ct2 =>
            {
                var taking = true;
                var e = await source.GetEnumerator(ct2);
                return new _AsyncEnumerator<TSource>(async () =>
                {
                    if (await e.MoveNext(ct) && taking && predicate(e.Current))
                    {
                        return Tuple.Create(e.Current, true);
                    }
                    else
                    {
                        taking = false;
                        return Tuple.Create(default(TSource), false);
                    }
                });
            });
        }

        public static IAsyncEnumerable<TSource> TakeWhileAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, int, bool> predicate, CancellationToken ct)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (predicate == null) throw new ArgumentNullException("predicate");

            return new _AsyncEnumerable<TSource>(async ct2 =>
            {
                int i = 0;
                var taking = true;
                var e = await source.GetEnumerator(ct2);
                return new _AsyncEnumerator<TSource>(async () =>
                {
                    if (await e.MoveNext(ct) && taking && predicate(e.Current, i++))
                    {
                        return Tuple.Create(e.Current, true);
                    }
                    else
                    {
                        taking = false;
                        return Tuple.Create(default(TSource), false);
                    }
                });
            });
        }
    }
}
