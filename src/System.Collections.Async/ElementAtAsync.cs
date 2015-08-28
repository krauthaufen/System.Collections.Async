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
        public static async Task<TSource> ElementAtAsync<TSource>(this IAsyncEnumerable<TSource> source, int index, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");
            if (index < 0) throw new ArgumentOutOfRangeException("index", index, "Negative index.");

            var i = 0;

            var e = await source.GetEnumerator(ct);
            while (await e.MoveNext(ct))
            {
                if (i++ == index) return e.Current;
            }
            throw new ArgumentOutOfRangeException("index", index, "Index is greater than number of elements in the sequence.");
        }
    }
}
