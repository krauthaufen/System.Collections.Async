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
        public static async Task<TSource[]> ToArrayAsync<TSource>(this IAsyncEnumerable<TSource> source, CancellationToken ct)
        {
            if (source == null) throw new ArgumentNullException("source");

            return (await source.ToListAsync(CancellationToken.None)).ToArray();
        }
    }
}
