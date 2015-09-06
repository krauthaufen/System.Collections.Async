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
        public static async Task<TSource> LastOrDefault<TSource>(this IAsyncEnumerable<TSource> source, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            ct.ThrowIfCancellationRequested();

            var e = await source.GetEnumerator(ct);
            switch (e.Status)
            {
                case MoveNextStatus.Canceled:
                    throw new OperationCanceledException();
                case MoveNextStatus.Faulted:
                    throw e.Exception;
                case MoveNextStatus.Completed:
                    return default(TSource);
            }

            IMoveNextResult<TSource> result = null;
            var x = await e.MoveNext(ct);
            while (x.IsValue)
            {
                ct.ThrowIfCancellationRequested();
                result = x;
                x = await e.MoveNext(ct);
            }

            switch (x.Status)
            {
                case MoveNextStatus.Canceled:
                    throw new OperationCanceledException();
                case MoveNextStatus.Faulted:
                    throw x.Exception;
                case MoveNextStatus.Completed:
                    return result != null ? result.Value : default(TSource);
            }

            throw new InvalidOperationException();
        }

        public static async Task<TSource> LastOrDefault<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            ct.ThrowIfCancellationRequested();

            var e = await source.GetEnumerator(ct);
            switch (e.Status)
            {
                case MoveNextStatus.Canceled:
                    throw new OperationCanceledException();
                case MoveNextStatus.Faulted:
                    throw e.Exception;
                case MoveNextStatus.Completed:
                    return default(TSource);
            }

            IMoveNextResult<TSource> result = null;
            var x = await e.MoveNext(ct);
            while (x.IsValue)
            {
                ct.ThrowIfCancellationRequested();
                if (predicate(x.Value)) result = x;
                x = await e.MoveNext(ct);
            }

            switch (x.Status)
            {
                case MoveNextStatus.Canceled:
                    throw new OperationCanceledException();
                case MoveNextStatus.Faulted:
                    throw x.Exception;
                case MoveNextStatus.Completed:
                    return result != null ? result.Value : default(TSource);
            }

            throw new InvalidOperationException();
        }
    }
}
