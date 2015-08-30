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
        public static IAsyncEnumerable<TSource> ToAsyncEnumerable<TSource>(this Task<TSource> source)
        {
            if (source == null) throw new ArgumentNullException("source");

            return new _AsyncEnumerable<TSource>(ct =>
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

        public static IAsyncEnumerable<TSource> ToAsyncEnumerable<TSource>(this IEnumerable<Task<TSource>> source)
        {
            if (source == null) throw new ArgumentNullException("source");

            return new _AsyncEnumerable<TSource>(ct =>
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
    }
}
