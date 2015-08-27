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
        public static async Task<TSource> AggregateAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, TSource, TSource> func, CancellationToken ct)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (func == null) throw new ArgumentNullException("func");
            
            var e = await source.GetEnumerator(ct);
            if (!await e.MoveNext(ct)) throw new InvalidOperationException();
            var aggregate = e.Current; // seed value for aggregate is first value

            while (await e.MoveNext(ct))
            {
                aggregate = func(aggregate, e.Current);
            }
            return aggregate;
        }

        public static async Task<TAccumulate> AggregateAsync<TSource, TAccumulate>(this IAsyncEnumerable<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func, CancellationToken ct)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (func == null) throw new ArgumentNullException("func");

            var e = await source.GetEnumerator(ct);
            var aggregate = seed;

            while (await e.MoveNext(ct))
            {
                aggregate = func(aggregate, e.Current);
            }
            return aggregate;
        }

        public static async Task<TResult> AggregateAsync<TSource, TAccumulate, TResult>(this IAsyncEnumerable<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func, Func<TAccumulate, TResult> resultSelector, CancellationToken ct)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (func == null) throw new ArgumentNullException("func");

            var e = await source.GetEnumerator(ct);
            var aggregate = seed;

            while (await e.MoveNext(ct))
            {
                aggregate = func(aggregate, e.Current);
            }
            return resultSelector(aggregate);
        }
    }
}
