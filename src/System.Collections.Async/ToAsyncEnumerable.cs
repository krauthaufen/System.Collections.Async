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
                        return Tuple.Create(await x, true);
                    }
                    else
                    {
                        return Tuple.Create(default(TResult), false);
                    }
                });
            });
        }
    }
}
