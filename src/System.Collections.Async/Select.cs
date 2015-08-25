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
        public static IAsyncEnumerable<TResult> SelectAsync<TSource, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, TResult> selector, CancellationToken ct)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (selector == null) throw new ArgumentNullException("selector");

            return new _AsyncEnumerable<TResult>(async ct2 =>
            {
                var e = await source.GetEnumerator(ct2);
                return new _AsyncEnumerator<TResult>(async () =>
                {
                    if (await e.MoveNext(ct))
                    {
                        var x = selector(e.Current);
                        return Tuple.Create(x, true);
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
