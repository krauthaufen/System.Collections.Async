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
        public static async Task<TSource> ElementAtOrDefault<TSource>(this IAsyncEnumerable<TSource> source, int index, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (index < 0) throw new ArgumentOutOfRangeException(nameof(index), index, "Negative index.");
            ct.ThrowIfCancellationRequested();

            var e = await source.GetEnumerator(ct);
            switch (e.Status)
            {
                case MoveNextStatus.Canceled:
                    throw new OperationCanceledException();
                case MoveNextStatus.Faulted:
                    throw e.Exception;
            }

            var i = 0;
            var x = await e.MoveNext(ct);
            while (x.IsValue)
            {
                ct.ThrowIfCancellationRequested();
                if (i++ == index) return x.Value;
                x = await e.MoveNext(ct);
            }

            switch (x.Status)
            {
                case MoveNextStatus.Canceled:
                    throw new OperationCanceledException();
                case MoveNextStatus.Faulted:
                    throw x.Exception;
                case MoveNextStatus.Completed:
                    return default(TSource);
            }

            throw new InvalidOperationException();
        }
    }
}
