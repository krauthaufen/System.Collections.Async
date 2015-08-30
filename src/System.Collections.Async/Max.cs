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
        public static async Task<decimal> MaxAsync(this IAsyncEnumerable<decimal> source, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");
            
            var e = await source.GetEnumerator(ct);
            var x = await e.MoveNext(ct);

            x.ThrowIfCancelledOrFaulted();
            if (x.IsCompleted) throw new InvalidOperationException();

            var result = x.Value;
            while ((x = await e.MoveNext(ct)).IsValue)
            {
                if (x.Value > result) result = x.Value;
            }
            x.ThrowIfCancelledOrFaulted();
            return result;
        }
        public static async Task<decimal?> MaxAsync(this IAsyncEnumerable<decimal?> source, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");

            var e = await source.GetEnumerator(ct);
            var x = await e.MoveNext(ct);

            x.ThrowIfCancelledOrFaulted();
            if (x.IsCompleted) throw new InvalidOperationException();

            var result = x.Value;
            while ((x = await e.MoveNext(ct)).IsValue)
            {
                if (x.Value > result) result = x.Value;
            }
            x.ThrowIfCancelledOrFaulted();
            return result;
        }
        public static async Task<double> MaxAsync(this IAsyncEnumerable<double> source, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");

            var e = await source.GetEnumerator(ct);
            var x = await e.MoveNext(ct);

            x.ThrowIfCancelledOrFaulted();
            if (x.IsCompleted) throw new InvalidOperationException();

            var result = x.Value;
            while ((x = await e.MoveNext(ct)).IsValue)
            {
                if (x.Value > result) result = x.Value;
            }
            x.ThrowIfCancelledOrFaulted();
            return result;
        }
        public static async Task<double?> MaxAsync(this IAsyncEnumerable<double?> source, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");

            var e = await source.GetEnumerator(ct);
            var x = await e.MoveNext(ct);

            x.ThrowIfCancelledOrFaulted();
            if (x.IsCompleted) throw new InvalidOperationException();

            var result = x.Value;
            while ((x = await e.MoveNext(ct)).IsValue)
            {
                if (x.Value > result) result = x.Value;
            }
            x.ThrowIfCancelledOrFaulted();
            return result;
        }
        public static async Task<float> MaxAsync(this IAsyncEnumerable<float> source, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");

            var e = await source.GetEnumerator(ct);
            var x = await e.MoveNext(ct);

            x.ThrowIfCancelledOrFaulted();
            if (x.IsCompleted) throw new InvalidOperationException();

            var result = x.Value;
            while ((x = await e.MoveNext(ct)).IsValue)
            {
                if (x.Value > result) result = x.Value;
            }
            x.ThrowIfCancelledOrFaulted();
            return result;
        }
        public static async Task<float?> MaxAsync(this IAsyncEnumerable<float?> source, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");

            var e = await source.GetEnumerator(ct);
            var x = await e.MoveNext(ct);

            x.ThrowIfCancelledOrFaulted();
            if (x.IsCompleted) throw new InvalidOperationException();

            var result = x.Value;
            while ((x = await e.MoveNext(ct)).IsValue)
            {
                if (x.Value > result) result = x.Value;
            }
            x.ThrowIfCancelledOrFaulted();
            return result;
        }
        public static async Task<int> MaxAsync(this IAsyncEnumerable<int> source, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");

            var e = await source.GetEnumerator(ct);
            var x = await e.MoveNext(ct);

            x.ThrowIfCancelledOrFaulted();
            if (x.IsCompleted) throw new InvalidOperationException();

            var result = x.Value;
            while ((x = await e.MoveNext(ct)).IsValue)
            {
                if (x.Value > result) result = x.Value;
            }
            x.ThrowIfCancelledOrFaulted();
            return result;
        }
        public static async Task<int?> MaxAsync(this IAsyncEnumerable<int?> source, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");

            var e = await source.GetEnumerator(ct);
            var x = await e.MoveNext(ct);

            x.ThrowIfCancelledOrFaulted();
            if (x.IsCompleted) throw new InvalidOperationException();

            var result = x.Value;
            while ((x = await e.MoveNext(ct)).IsValue)
            {
                if (x.Value > result) result = x.Value;
            }
            x.ThrowIfCancelledOrFaulted();
            return result;
        }
        public static async Task<long> MaxAsync(this IAsyncEnumerable<long> source, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");

            var e = await source.GetEnumerator(ct);
            var x = await e.MoveNext(ct);

            x.ThrowIfCancelledOrFaulted();
            if (x.IsCompleted) throw new InvalidOperationException();

            var result = x.Value;
            while ((x = await e.MoveNext(ct)).IsValue)
            {
                if (x.Value > result) result = x.Value;
            }
            x.ThrowIfCancelledOrFaulted();
            return result;
        }
        public static async Task<long?> MaxAsync(this IAsyncEnumerable<long?> source, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");

            var e = await source.GetEnumerator(ct);
            var x = await e.MoveNext(ct);

            x.ThrowIfCancelledOrFaulted();
            if (x.IsCompleted) throw new InvalidOperationException();

            var result = x.Value;
            while ((x = await e.MoveNext(ct)).IsValue)
            {
                if (x.Value > result) result = x.Value;
            }
            x.ThrowIfCancelledOrFaulted();
            return result;
        }
        public static async Task<uint> MaxAsync(this IAsyncEnumerable<uint> source, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");

            var e = await source.GetEnumerator(ct);
            var x = await e.MoveNext(ct);

            x.ThrowIfCancelledOrFaulted();
            if (x.IsCompleted) throw new InvalidOperationException();

            var result = x.Value;
            while ((x = await e.MoveNext(ct)).IsValue)
            {
                if (x.Value > result) result = x.Value;
            }
            x.ThrowIfCancelledOrFaulted();
            return result;
        }
        public static async Task<uint?> MaxAsync(this IAsyncEnumerable<uint?> source, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");

            var e = await source.GetEnumerator(ct);
            var x = await e.MoveNext(ct);

            x.ThrowIfCancelledOrFaulted();
            if (x.IsCompleted) throw new InvalidOperationException();

            var result = x.Value;
            while ((x = await e.MoveNext(ct)).IsValue)
            {
                if (x.Value > result) result = x.Value;
            }
            x.ThrowIfCancelledOrFaulted();
            return result;
        }
        public static async Task<ulong> MaxAsync(this IAsyncEnumerable<ulong> source, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");

            var e = await source.GetEnumerator(ct);
            var x = await e.MoveNext(ct);

            x.ThrowIfCancelledOrFaulted();
            if (x.IsCompleted) throw new InvalidOperationException();

            var result = x.Value;
            while ((x = await e.MoveNext(ct)).IsValue)
            {
                if (x.Value > result) result = x.Value;
            }
            x.ThrowIfCancelledOrFaulted();
            return result;
        }
        public static async Task<ulong?> MaxAsync(this IAsyncEnumerable<ulong?> source, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");

            var e = await source.GetEnumerator(ct);
            var x = await e.MoveNext(ct);

            x.ThrowIfCancelledOrFaulted();
            if (x.IsCompleted) throw new InvalidOperationException();

            var result = x.Value;
            while ((x = await e.MoveNext(ct)).IsValue)
            {
                if (x.Value > result) result = x.Value;
            }
            x.ThrowIfCancelledOrFaulted();
            return result;
        }


        public static async Task<decimal> MaxAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, decimal> selector, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");
            if (selector == null) throw new ArgumentNullException("selector");

            var e = await source.GetEnumerator(ct);
            var x = await e.MoveNext(ct);

            x.ThrowIfCancelledOrFaulted();
            if (x.IsCompleted) throw new InvalidOperationException();

            var result = selector(x.Value);
            while ((x = await e.MoveNext(ct)).IsValue)
            {
                var v = selector(x.Value);
                if (v > result) result = v;
            }
            x.ThrowIfCancelledOrFaulted();
            return result;
        }
        public static async Task<decimal?> MaxAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, decimal?> selector, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");
            if (selector == null) throw new ArgumentNullException("selector");

            var e = await source.GetEnumerator(ct);
            var x = await e.MoveNext(ct);

            x.ThrowIfCancelledOrFaulted();
            if (x.IsCompleted) throw new InvalidOperationException();

            var result = selector(x.Value);
            while ((x = await e.MoveNext(ct)).IsValue)
            {
                var v = selector(x.Value);
                if (v > result) result = v;
            }
            x.ThrowIfCancelledOrFaulted();
            return result;
        }
        public static async Task<double> MaxAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, double> selector, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");
            if (selector == null) throw new ArgumentNullException("selector");

            var e = await source.GetEnumerator(ct);
            var x = await e.MoveNext(ct);

            x.ThrowIfCancelledOrFaulted();
            if (x.IsCompleted) throw new InvalidOperationException();

            var result = selector(x.Value);
            while ((x = await e.MoveNext(ct)).IsValue)
            {
                var v = selector(x.Value);
                if (v > result) result = v;
            }
            x.ThrowIfCancelledOrFaulted();
            return result;
        }
        public static async Task<double?> MaxAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, double?> selector, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");
            if (selector == null) throw new ArgumentNullException("selector");

            var e = await source.GetEnumerator(ct);
            var x = await e.MoveNext(ct);

            x.ThrowIfCancelledOrFaulted();
            if (x.IsCompleted) throw new InvalidOperationException();

            var result = selector(x.Value);
            while ((x = await e.MoveNext(ct)).IsValue)
            {
                var v = selector(x.Value);
                if (v > result) result = v;
            }
            x.ThrowIfCancelledOrFaulted();
            return result;
        }
        public static async Task<float> MaxAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, float> selector, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");
            if (selector == null) throw new ArgumentNullException("selector");

            var e = await source.GetEnumerator(ct);
            var x = await e.MoveNext(ct);

            x.ThrowIfCancelledOrFaulted();
            if (x.IsCompleted) throw new InvalidOperationException();

            var result = selector(x.Value);
            while ((x = await e.MoveNext(ct)).IsValue)
            {
                var v = selector(x.Value);
                if (v > result) result = v;
            }
            x.ThrowIfCancelledOrFaulted();
            return result;
        }
        public static async Task<float?> MaxAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, float?> selector, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");
            if (selector == null) throw new ArgumentNullException("selector");

            var e = await source.GetEnumerator(ct);
            var x = await e.MoveNext(ct);

            x.ThrowIfCancelledOrFaulted();
            if (x.IsCompleted) throw new InvalidOperationException();

            var result = selector(x.Value);
            while ((x = await e.MoveNext(ct)).IsValue)
            {
                var v = selector(x.Value);
                if (v > result) result = v;
            }
            x.ThrowIfCancelledOrFaulted();
            return result;
        }
        public static async Task<int> MaxAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, int> selector, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");
            if (selector == null) throw new ArgumentNullException("selector");

            var e = await source.GetEnumerator(ct);
            var x = await e.MoveNext(ct);

            x.ThrowIfCancelledOrFaulted();
            if (x.IsCompleted) throw new InvalidOperationException();

            var result = selector(x.Value);
            while ((x = await e.MoveNext(ct)).IsValue)
            {
                var v = selector(x.Value);
                if (v > result) result = v;
            }
            x.ThrowIfCancelledOrFaulted();
            return result;
        }
        public static async Task<int?> MaxAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, int?> selector, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");
            if (selector == null) throw new ArgumentNullException("selector");

            var e = await source.GetEnumerator(ct);
            var x = await e.MoveNext(ct);

            x.ThrowIfCancelledOrFaulted();
            if (x.IsCompleted) throw new InvalidOperationException();

            var result = selector(x.Value);
            while ((x = await e.MoveNext(ct)).IsValue)
            {
                var v = selector(x.Value);
                if (v > result) result = v;
            }
            x.ThrowIfCancelledOrFaulted();
            return result;
        }
        public static async Task<long> MaxAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, long> selector, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");
            if (selector == null) throw new ArgumentNullException("selector");

            var e = await source.GetEnumerator(ct);
            var x = await e.MoveNext(ct);

            x.ThrowIfCancelledOrFaulted();
            if (x.IsCompleted) throw new InvalidOperationException();

            var result = selector(x.Value);
            while ((x = await e.MoveNext(ct)).IsValue)
            {
                var v = selector(x.Value);
                if (v > result) result = v;
            }
            x.ThrowIfCancelledOrFaulted();
            return result;
        }
        public static async Task<long?> MaxAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, long?> selector, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");
            if (selector == null) throw new ArgumentNullException("selector");

            var e = await source.GetEnumerator(ct);
            var x = await e.MoveNext(ct);

            x.ThrowIfCancelledOrFaulted();
            if (x.IsCompleted) throw new InvalidOperationException();

            var result = selector(x.Value);
            while ((x = await e.MoveNext(ct)).IsValue)
            {
                var v = selector(x.Value);
                if (v > result) result = v;
            }
            x.ThrowIfCancelledOrFaulted();
            return result;
        }
        public static async Task<uint> MaxAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, uint> selector, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");
            if (selector == null) throw new ArgumentNullException("selector");

            var e = await source.GetEnumerator(ct);
            var x = await e.MoveNext(ct);

            x.ThrowIfCancelledOrFaulted();
            if (x.IsCompleted) throw new InvalidOperationException();

            var result = selector(x.Value);
            while ((x = await e.MoveNext(ct)).IsValue)
            {
                var v = selector(x.Value);
                if (v > result) result = v;
            }
            x.ThrowIfCancelledOrFaulted();
            return result;
        }
        public static async Task<uint?> MaxAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, uint?> selector, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");
            if (selector == null) throw new ArgumentNullException("selector");

            var e = await source.GetEnumerator(ct);
            var x = await e.MoveNext(ct);

            x.ThrowIfCancelledOrFaulted();
            if (x.IsCompleted) throw new InvalidOperationException();

            var result = selector(x.Value);
            while ((x = await e.MoveNext(ct)).IsValue)
            {
                var v = selector(x.Value);
                if (v > result) result = v;
            }
            x.ThrowIfCancelledOrFaulted();
            return result;
        }
        public static async Task<ulong> MaxAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, ulong> selector, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");
            if (selector == null) throw new ArgumentNullException("selector");

            var e = await source.GetEnumerator(ct);
            var x = await e.MoveNext(ct);

            x.ThrowIfCancelledOrFaulted();
            if (x.IsCompleted) throw new InvalidOperationException();

            var result = selector(x.Value);
            while ((x = await e.MoveNext(ct)).IsValue)
            {
                var v = selector(x.Value);
                if (v > result) result = v;
            }
            x.ThrowIfCancelledOrFaulted();
            return result;
        }
        public static async Task<ulong?> MaxAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, ulong?> selector, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");
            if (selector == null) throw new ArgumentNullException("selector");

            var e = await source.GetEnumerator(ct);
            var x = await e.MoveNext(ct);

            x.ThrowIfCancelledOrFaulted();
            if (x.IsCompleted) throw new InvalidOperationException();

            var result = selector(x.Value);
            while ((x = await e.MoveNext(ct)).IsValue)
            {
                var v = selector(x.Value);
                if (v > result) result = v;
            }
            x.ThrowIfCancelledOrFaulted();
            return result;
        }
    }
}
