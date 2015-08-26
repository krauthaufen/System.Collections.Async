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
        public static async Task<decimal> SumAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, decimal> selector, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");
            if (selector == null) throw new ArgumentNullException("selector");

            decimal result = 0;
            var e = await source.GetEnumerator(ct);
            while (await e.MoveNext(ct)) result += selector(e.Current);
            return result;
        }
        public static async Task<double> SumAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, double> selector, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");
            if (selector == null) throw new ArgumentNullException("selector");

            double result = 0;
            var e = await source.GetEnumerator(ct);
            while (await e.MoveNext(ct)) result += selector(e.Current);
            return result;
        }
        public static async Task<float> SumAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, float> selector, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");
            if (selector == null) throw new ArgumentNullException("selector");

            float result = 0;
            var e = await source.GetEnumerator(ct);
            while (await e.MoveNext(ct)) result += selector(e.Current);
            return result;
        }
        public static async Task<int> SumAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, int> selector, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");
            if (selector == null) throw new ArgumentNullException("selector");

            int result = 0;
            var e = await source.GetEnumerator(ct);
            while (await e.MoveNext(ct)) result += selector(e.Current);
            return result;
        }
        public static async Task<long> SumAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, long> selector, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");
            if (selector == null) throw new ArgumentNullException("selector");

            long result = 0;
            var e = await source.GetEnumerator(ct);
            while (await e.MoveNext(ct)) result += selector(e.Current);
            return result;
        }
        public static async Task<uint> SumAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, uint> selector, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");
            if (selector == null) throw new ArgumentNullException("selector");

            uint result = 0;
            var e = await source.GetEnumerator(ct);
            while (await e.MoveNext(ct)) result += selector(e.Current);
            return result;
        }
        public static async Task<ulong> SumAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, ulong> selector, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");
            if (selector == null) throw new ArgumentNullException("selector");

            ulong result = 0;
            var e = await source.GetEnumerator(ct);
            while (await e.MoveNext(ct)) result += selector(e.Current);
            return result;
        }
    }
}
