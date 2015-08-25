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
        public static async Task ForEachAsync<T>(this IAsyncEnumerable<T> source, Action<T> action, CancellationToken ct)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (action == null) throw new ArgumentNullException("action");

            var e = await source.GetEnumerator(ct);
            while (await e.MoveNext(ct))
            {
                action(e.Current);
            }
        }
    }
}
