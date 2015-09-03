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
        public static async Task<TSource> Next<TSource>(this IAsyncEnumerable<TSource> source, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");
            ct.ThrowIfCancellationRequested();
            
            var e = source.GetEnumerator(ct).Result;
            switch (e.Status)
            {
                case MoveNextStatus.Canceled:
                    throw new OperationCanceledException();

                case MoveNextStatus.Completed:
                    throw new InvalidOperationException();

                case MoveNextStatus.Faulted:
                    throw e.Exception;
            }

            var x = await e.MoveNext(ct);
            if (x.IsValue) return x.Value;
            x.ThrowIfCanceledOrFaulted();
            throw new InvalidOperationException();
        }
    }
}
