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
        public static IAsyncEnumerable<TSource> ToAsyncEnumerable<TSource>(this IEnumerable<Task<TSource>> source)
        {
            if (source == null) throw new ArgumentNullException("source");

            return new _AsyncEnumerable<TSource>(ct2 =>
            {
                var e = source.GetEnumerator();
                return new _AsyncEnumerator<TSource>(async () =>
                {
                    if (e.MoveNext())
                    {
                        return MoveNext.Value(await e.Current);
                    }
                    else
                    {
                        return MoveNext.Completed<TSource>();
                    }
                });
            });
        }

        public static IAsyncEnumerable<TSource> ToAsyncEnumerable<TSource>(this Task<TSource> source)
        {
            if (source == null) throw new ArgumentNullException("source");

            return new _AsyncEnumerable<TSource>(ct2 =>
            {
                var done = false;
                return new _AsyncEnumerator<TSource>(async () =>
                {
                    if (done)
                    {
                        return MoveNext.Completed<TSource>();
                    }
                    else
                    {
                        done = true;
                        return MoveNext.Value(await source);
                    }
                });
            });
        }

        public static IAsyncEnumerable<TResult> ToAsyncEnumerable<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, Task<TResult>> selector)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (selector == null) throw new ArgumentNullException("selector");

            return new _AsyncEnumerable<TResult>(ct2 =>
            {
                var e = source.GetEnumerator();
                return new _AsyncEnumerator<TResult>(async () =>
                {
                    if (e.MoveNext())
                    {
                        var x = selector(e.Current);
                        return MoveNext.Value(await x);
                    }
                    else
                    {
                        return MoveNext.Completed<TResult>();
                    }
                });
            });
        }
    }
}
