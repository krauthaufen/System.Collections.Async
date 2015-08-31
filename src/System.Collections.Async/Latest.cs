using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System.Collections.Async
{
    public interface ILatestValue<T>
    {
        IMoveNextResult<T> Item { get; }
    }

    public static partial class AsyncEnumerable
    {
        private class _LatestValue<T> : ILatestValue<T>
        {
            public IMoveNextResult<T> Item { get; set; }
        }

        public static ILatestValue<TSource> Latest<TSource>(this IAsyncEnumerable<TSource> source, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");

            if (ct.IsCancellationRequested) return new _LatestValue<TSource> { Item = MoveNext.Canceled<TSource>() };

            var result = new _LatestValue<TSource> { Item = MoveNext.None<TSource>() };
            var e = source.GetEnumerator(ct).Result;
            switch (e.Status)
            {
                case MoveNextStatus.Canceled:
                    result.Item = MoveNext.Canceled<TSource>();
                    return result;

                case MoveNextStatus.Completed:
                    result.Item = MoveNext.Completed<TSource>();
                    return result;

                case MoveNextStatus.Faulted:
                    result.Item = MoveNext.Faulted<TSource>(e.Exception);
                    return result;
            }

            Task.Run(async () =>
            {
                var x = await e.MoveNext(ct);
                while (x.IsValue)
                {
                    result.Item = x;
                    x = await e.MoveNext(ct);
                }
                result.Item = x;
            });

            return result;
        }
    }
}
