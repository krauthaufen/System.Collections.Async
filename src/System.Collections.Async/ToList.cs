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
        public static async Task<List<TSource>> ToListAsync<TSource>(this IAsyncEnumerable<TSource> source, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");

            var result = new List<TSource>();
            var e = await source.GetEnumerator(ct);
            while (await e.MoveNext(ct))
            {
                result.Add(e.Current);
            }
            return result;
        }
    }
}
