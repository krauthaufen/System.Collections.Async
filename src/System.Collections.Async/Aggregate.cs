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
        public static async Task<TSource> Aggregate<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, TSource, TSource> func, CancellationToken ct)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (func == null) throw new ArgumentNullException("func");

            var e = await source.GetEnumerator(ct);
            ct.ThrowIfCancellationRequested();

            var x = await e.MoveNext(ct);
            x.ThrowIfCanceledOrFaulted();
            if (x.IsCompleted) throw new InvalidOperationException();
            var aggregate = x.Value; // seed value for aggregate is first value

            while (x.IsValue)
            {
                ct.ThrowIfCancellationRequested();
                aggregate = func(aggregate, x.Value);
                x = await e.MoveNext(ct);
            }
            x.ThrowIfCanceledOrFaulted();
            return aggregate;
        }

        public static async Task<TAccumulate> Aggregate<TSource, TAccumulate>(this IAsyncEnumerable<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func, CancellationToken ct)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (func == null) throw new ArgumentNullException("func");

            var e = await source.GetEnumerator(ct);
            ct.ThrowIfCancellationRequested();

            var aggregate = seed;
            var x = await e.MoveNext(ct);
            while (x.IsValue)
            {
                ct.ThrowIfCancellationRequested();
                aggregate = func(aggregate, x.Value);
                x = await e.MoveNext(ct);
            }
            x.ThrowIfCanceledOrFaulted();
            return aggregate;
        }

        public static async Task<TResult> Aggregate<TSource, TAccumulate, TResult>(this IAsyncEnumerable<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func, Func<TAccumulate, TResult> resultSelector, CancellationToken ct)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (func == null) throw new ArgumentNullException("func");

            var e = await source.GetEnumerator(ct);
            ct.ThrowIfCancellationRequested();

            var aggregate = seed;
            var x = await e.MoveNext(ct);
            while (x.IsValue)
            {
                ct.ThrowIfCancellationRequested();
                aggregate = func(aggregate, x.Value);
                x = await e.MoveNext(ct);
            }
            x.ThrowIfCanceledOrFaulted();
            return resultSelector(aggregate);
        }
    }
}
