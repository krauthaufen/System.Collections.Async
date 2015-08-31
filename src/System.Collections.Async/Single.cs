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
        public static async Task<TSource> Single<TSource>(this IAsyncEnumerable<TSource> source, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");
            ct.ThrowIfCancellationRequested();

            var e = await source.GetEnumerator(ct);
            if (e.Status != MoveNextStatus.None) throw new InvalidOperationException();

            var x = await e.MoveNext(ct);
            if (x.IsValue)
            {
                var result = x.Value;
                x = await e.MoveNext(ct);
                if (x.Status == MoveNextStatus.Completed)
                {
                    return result;
                }
            }
            throw new InvalidOperationException();
        }
    }
}
