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
        public static async Task<decimal> SumAsync(this IAsyncEnumerable<decimal> source, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");

            var e = await source.GetEnumerator(ct);
            ct.ThrowIfCancellationRequested();

            var result = (decimal)0;
            var x = await e.MoveNext(ct);
            while (x.IsValue)
            {
                ct.ThrowIfCancellationRequested();
                result += x.Value;
                x = await e.MoveNext(ct);
            }
            x.ThrowIfCancelledOrFaulted();
            return result;
        }
        public static async Task<decimal?> SumAsync(this IAsyncEnumerable<decimal?> source, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");

            var e = await source.GetEnumerator(ct);
            ct.ThrowIfCancellationRequested();

            var result = (decimal?)0;
            var x = await e.MoveNext(ct);
            while (x.IsValue)
            {
                ct.ThrowIfCancellationRequested();
                result += x.Value;
                x = await e.MoveNext(ct);
            }
            x.ThrowIfCancelledOrFaulted();
            return result;
        }
        public static async Task<double> SumAsync(this IAsyncEnumerable<double> source, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");

            var e = await source.GetEnumerator(ct);
            ct.ThrowIfCancellationRequested();

            var result = (double)0;
            var x = await e.MoveNext(ct);
            while (x.IsValue)
            {
                ct.ThrowIfCancellationRequested();
                result += x.Value;
                x = await e.MoveNext(ct);
            }
            x.ThrowIfCancelledOrFaulted();
            return result;
        }
        public static async Task<double?> SumAsync(this IAsyncEnumerable<double?> source, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");

            var e = await source.GetEnumerator(ct);
            ct.ThrowIfCancellationRequested();

            var result = (double?)0;
            var x = await e.MoveNext(ct);
            while (x.IsValue)
            {
                ct.ThrowIfCancellationRequested();
                result += x.Value;
                x = await e.MoveNext(ct);
            }
            x.ThrowIfCancelledOrFaulted();
            return result;
        }
        public static async Task<float> SumAsync(this IAsyncEnumerable<float> source, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");

            var e = await source.GetEnumerator(ct);
            ct.ThrowIfCancellationRequested();

            var result = (float)0;
            var x = await e.MoveNext(ct);
            while (x.IsValue)
            {
                ct.ThrowIfCancellationRequested();
                result += x.Value;
                x = await e.MoveNext(ct);
            }
            x.ThrowIfCancelledOrFaulted();
            return result;
        }
        public static async Task<float?> SumAsync(this IAsyncEnumerable<float?> source, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");

            var e = await source.GetEnumerator(ct);
            ct.ThrowIfCancellationRequested();

            var result = (float?)0;
            var x = await e.MoveNext(ct);
            while (x.IsValue)
            {
                ct.ThrowIfCancellationRequested();
                result += x.Value;
                x = await e.MoveNext(ct);
            }
            x.ThrowIfCancelledOrFaulted();
            return result;
        }
        public static async Task<int> SumAsync(this IAsyncEnumerable<int> source, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");

            var e = await source.GetEnumerator(ct);
            ct.ThrowIfCancellationRequested();

            var result = (int)0;
            var x = await e.MoveNext(ct);
            while (x.IsValue)
            {
                ct.ThrowIfCancellationRequested();
                result += x.Value;
                x = await e.MoveNext(ct);
            }
            x.ThrowIfCancelledOrFaulted();
            return result;
        }
        public static async Task<int?> SumAsync(this IAsyncEnumerable<int?> source, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");

            var e = await source.GetEnumerator(ct);
            ct.ThrowIfCancellationRequested();

            var result = (int?)0;
            var x = await e.MoveNext(ct);
            while (x.IsValue)
            {
                ct.ThrowIfCancellationRequested();
                result += x.Value;
                x = await e.MoveNext(ct);
            }
            x.ThrowIfCancelledOrFaulted();
            return result;
        }
        public static async Task<long> SumAsync(this IAsyncEnumerable<long> source, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");

            var e = await source.GetEnumerator(ct);
            ct.ThrowIfCancellationRequested();

            var result = (long)0;
            var x = await e.MoveNext(ct);
            while (x.IsValue)
            {
                ct.ThrowIfCancellationRequested();
                result += x.Value;
                x = await e.MoveNext(ct);
            }
            x.ThrowIfCancelledOrFaulted();
            return result;
        }
        public static async Task<long?> SumAsync(this IAsyncEnumerable<long?> source, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");

            var e = await source.GetEnumerator(ct);
            ct.ThrowIfCancellationRequested();

            var result = (long?)0;
            var x = await e.MoveNext(ct);
            while (x.IsValue)
            {
                ct.ThrowIfCancellationRequested();
                result += x.Value;
                x = await e.MoveNext(ct);
            }
            x.ThrowIfCancelledOrFaulted();
            return result;
        }
        public static async Task<uint> SumAsync(this IAsyncEnumerable<uint> source, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");

            var e = await source.GetEnumerator(ct);
            ct.ThrowIfCancellationRequested();

            var result = (uint)0;
            var x = await e.MoveNext(ct);
            while (x.IsValue)
            {
                ct.ThrowIfCancellationRequested();
                result += x.Value;
                x = await e.MoveNext(ct);
            }
            x.ThrowIfCancelledOrFaulted();
            return result;
        }
        public static async Task<uint?> SumAsync(this IAsyncEnumerable<uint?> source, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");

            var e = await source.GetEnumerator(ct);
            ct.ThrowIfCancellationRequested();

            var result = (uint?)0;
            var x = await e.MoveNext(ct);
            while (x.IsValue)
            {
                ct.ThrowIfCancellationRequested();
                result += x.Value;
                x = await e.MoveNext(ct);
            }
            x.ThrowIfCancelledOrFaulted();
            return result;
        }
        public static async Task<ulong> SumAsync(this IAsyncEnumerable<ulong> source, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");

            var e = await source.GetEnumerator(ct);
            ct.ThrowIfCancellationRequested();

            var result = (ulong)0;
            var x = await e.MoveNext(ct);
            while (x.IsValue)
            {
                ct.ThrowIfCancellationRequested();
                result += x.Value;
                x = await e.MoveNext(ct);
            }
            x.ThrowIfCancelledOrFaulted();
            return result;
        }
        public static async Task<ulong?> SumAsync(this IAsyncEnumerable<ulong?> source, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");

            var e = await source.GetEnumerator(ct);
            ct.ThrowIfCancellationRequested();

            var result = (ulong?)0;
            var x = await e.MoveNext(ct);
            while (x.IsValue)
            {
                ct.ThrowIfCancellationRequested();
                result += x.Value;
                x = await e.MoveNext(ct);
            }
            x.ThrowIfCancelledOrFaulted();
            return result;
        }

        public static async Task<decimal> SumAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, decimal> selector, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");
            if (selector == null) throw new ArgumentNullException("selector");

            var e = await source.GetEnumerator(ct);
            ct.ThrowIfCancellationRequested();

            var result = (decimal)0;
            var x = await e.MoveNext(ct);
            while (x.IsValue)
            {
                ct.ThrowIfCancellationRequested();
                result += selector(x.Value);
                x = await e.MoveNext(ct);
            }
            x.ThrowIfCancelledOrFaulted();
            return result;
        }
        public static async Task<decimal?> SumAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, decimal?> selector, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");
            if (selector == null) throw new ArgumentNullException("selector");

            var e = await source.GetEnumerator(ct);
            ct.ThrowIfCancellationRequested();

            var result = (decimal?)0;
            var x = await e.MoveNext(ct);
            while (x.IsValue)
            {
                ct.ThrowIfCancellationRequested();
                result += selector(x.Value);
                x = await e.MoveNext(ct);
            }
            x.ThrowIfCancelledOrFaulted();
            return result;
        }
        public static async Task<double> SumAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, double> selector, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");
            if (selector == null) throw new ArgumentNullException("selector");

            var e = await source.GetEnumerator(ct);
            ct.ThrowIfCancellationRequested();

            var result = (double)0;
            var x = await e.MoveNext(ct);
            while (x.IsValue)
            {
                ct.ThrowIfCancellationRequested();
                result += selector(x.Value);
                x = await e.MoveNext(ct);
            }
            x.ThrowIfCancelledOrFaulted();
            return result;
        }
        public static async Task<double?> SumAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, double?> selector, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");
            if (selector == null) throw new ArgumentNullException("selector");

            var e = await source.GetEnumerator(ct);
            ct.ThrowIfCancellationRequested();

            var result = (double?)0;
            var x = await e.MoveNext(ct);
            while (x.IsValue)
            {
                ct.ThrowIfCancellationRequested();
                result += selector(x.Value);
                x = await e.MoveNext(ct);
            }
            x.ThrowIfCancelledOrFaulted();
            return result;
        }
        public static async Task<float> SumAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, float> selector, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");
            if (selector == null) throw new ArgumentNullException("selector");

            var e = await source.GetEnumerator(ct);
            ct.ThrowIfCancellationRequested();

            var result = (float)0;
            var x = await e.MoveNext(ct);
            while (x.IsValue)
            {
                ct.ThrowIfCancellationRequested();
                result += selector(x.Value);
                x = await e.MoveNext(ct);
            }
            x.ThrowIfCancelledOrFaulted();
            return result;
        }
        public static async Task<float?> SumAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, float?> selector, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");
            if (selector == null) throw new ArgumentNullException("selector");

            var e = await source.GetEnumerator(ct);
            ct.ThrowIfCancellationRequested();

            var result = (float?)0;
            var x = await e.MoveNext(ct);
            while (x.IsValue)
            {
                ct.ThrowIfCancellationRequested();
                result += selector(x.Value);
                x = await e.MoveNext(ct);
            }
            x.ThrowIfCancelledOrFaulted();
            return result;
        }
        public static async Task<int> SumAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, int> selector, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");
            if (selector == null) throw new ArgumentNullException("selector");

            var e = await source.GetEnumerator(ct);
            ct.ThrowIfCancellationRequested();

            var result = (int)0;
            var x = await e.MoveNext(ct);
            while (x.IsValue)
            {
                ct.ThrowIfCancellationRequested();
                result += selector(x.Value);
                x = await e.MoveNext(ct);
            }
            x.ThrowIfCancelledOrFaulted();
            return result;
        }
        public static async Task<int?> SumAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, int?> selector, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");
            if (selector == null) throw new ArgumentNullException("selector");

            var e = await source.GetEnumerator(ct);
            ct.ThrowIfCancellationRequested();

            var result = (int?)0;
            var x = await e.MoveNext(ct);
            while (x.IsValue)
            {
                ct.ThrowIfCancellationRequested();
                result += selector(x.Value);
                x = await e.MoveNext(ct);
            }
            x.ThrowIfCancelledOrFaulted();
            return result;
        }
        public static async Task<long> SumAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, long> selector, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");
            if (selector == null) throw new ArgumentNullException("selector");

            var e = await source.GetEnumerator(ct);
            ct.ThrowIfCancellationRequested();

            var result = (long)0;
            var x = await e.MoveNext(ct);
            while (x.IsValue)
            {
                ct.ThrowIfCancellationRequested();
                result += selector(x.Value);
                x = await e.MoveNext(ct);
            }
            x.ThrowIfCancelledOrFaulted();
            return result;
        }
        public static async Task<long?> SumAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, long?> selector, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");
            if (selector == null) throw new ArgumentNullException("selector");

            var e = await source.GetEnumerator(ct);
            ct.ThrowIfCancellationRequested();

            var result = (long?)0;
            var x = await e.MoveNext(ct);
            while (x.IsValue)
            {
                ct.ThrowIfCancellationRequested();
                result += selector(x.Value);
                x = await e.MoveNext(ct);
            }
            x.ThrowIfCancelledOrFaulted();
            return result;
        }
        public static async Task<uint> SumAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, uint> selector, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");
            if (selector == null) throw new ArgumentNullException("selector");

            var e = await source.GetEnumerator(ct);
            ct.ThrowIfCancellationRequested();

            var result = (uint)0;
            var x = await e.MoveNext(ct);
            while (x.IsValue)
            {
                ct.ThrowIfCancellationRequested();
                result += selector(x.Value);
                x = await e.MoveNext(ct);
            }
            x.ThrowIfCancelledOrFaulted();
            return result;
        }
        public static async Task<uint?> SumAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, uint?> selector, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");
            if (selector == null) throw new ArgumentNullException("selector");

            var e = await source.GetEnumerator(ct);
            ct.ThrowIfCancellationRequested();

            var result = (uint?)0;
            var x = await e.MoveNext(ct);
            while (x.IsValue)
            {
                ct.ThrowIfCancellationRequested();
                result += selector(x.Value);
                x = await e.MoveNext(ct);
            }
            x.ThrowIfCancelledOrFaulted();
            return result;
        }
        public static async Task<ulong> SumAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, ulong> selector, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");
            if (selector == null) throw new ArgumentNullException("selector");

            var e = await source.GetEnumerator(ct);
            ct.ThrowIfCancellationRequested();

            var result = (ulong)0;
            var x = await e.MoveNext(ct);
            while (x.IsValue)
            {
                ct.ThrowIfCancellationRequested();
                result += selector(x.Value);
                x = await e.MoveNext(ct);
            }
            x.ThrowIfCancelledOrFaulted();
            return result;
        }
        public static async Task<ulong?> SumAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, ulong?> selector, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");
            if (selector == null) throw new ArgumentNullException("selector");

            var e = await source.GetEnumerator(ct);
            ct.ThrowIfCancellationRequested();

            var result = (ulong?)0;
            var x = await e.MoveNext(ct);
            while (x.IsValue)
            {
                ct.ThrowIfCancellationRequested();
                result += selector(x.Value);
                x = await e.MoveNext(ct);
            }
            x.ThrowIfCancelledOrFaulted();
            return result;
        }
    }
}
