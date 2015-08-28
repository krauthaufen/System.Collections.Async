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
        public static async Task<decimal> MinAsync(this IAsyncEnumerable<decimal> source, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");
            
            var e = await source.GetEnumerator(ct);
            if (!await e.MoveNext(ct)) throw new InvalidOperationException();
            var result = e.Current;
            while (await e.MoveNext(ct))
            {
                var x = e.Current;
                if (x < result) result = x;
            }
            return result;
        }
        public static async Task<decimal?> MinAsync(this IAsyncEnumerable<decimal?> source, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");

            var e = await source.GetEnumerator(ct);
            if (!await e.MoveNext(ct)) throw new InvalidOperationException();
            var result = e.Current;
            while (await e.MoveNext(ct))
            {
                var x = e.Current;
                if (x < result) result = x;
            }
            return result;
        }
        public static async Task<double> MinAsync(this IAsyncEnumerable<double> source, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");

            var e = await source.GetEnumerator(ct);
            if (!await e.MoveNext(ct)) throw new InvalidOperationException();
            var result = e.Current;
            while (await e.MoveNext(ct))
            {
                var x = e.Current;
                if (x < result) result = x;
            }
            return result;
        }
        public static async Task<double?> MinAsync(this IAsyncEnumerable<double?> source, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");

            var e = await source.GetEnumerator(ct);
            if (!await e.MoveNext(ct)) throw new InvalidOperationException();
            var result = e.Current;
            while (await e.MoveNext(ct))
            {
                var x = e.Current;
                if (x < result) result = x;
            }
            return result;
        }
        public static async Task<float> MinAsync(this IAsyncEnumerable<float> source, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");

            var e = await source.GetEnumerator(ct);
            if (!await e.MoveNext(ct)) throw new InvalidOperationException();
            var result = e.Current;
            while (await e.MoveNext(ct))
            {
                var x = e.Current;
                if (x < result) result = x;
            }
            return result;
        }
        public static async Task<float?> MinAsync(this IAsyncEnumerable<float?> source, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");

            var e = await source.GetEnumerator(ct);
            if (!await e.MoveNext(ct)) throw new InvalidOperationException();
            var result = e.Current;
            while (await e.MoveNext(ct))
            {
                var x = e.Current;
                if (x < result) result = x;
            }
            return result;
        }
        public static async Task<int> MinAsync(this IAsyncEnumerable<int> source, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");

            var e = await source.GetEnumerator(ct);
            if (!await e.MoveNext(ct)) throw new InvalidOperationException();
            var result = e.Current;
            while (await e.MoveNext(ct))
            {
                var x = e.Current;
                if (x < result) result = x;
            }
            return result;
        }
        public static async Task<int?> MinAsync(this IAsyncEnumerable<int?> source, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");

            var e = await source.GetEnumerator(ct);
            if (!await e.MoveNext(ct)) throw new InvalidOperationException();
            var result = e.Current;
            while (await e.MoveNext(ct))
            {
                var x = e.Current;
                if (x < result) result = x;
            }
            return result;
        }
        public static async Task<long> MinAsync(this IAsyncEnumerable<long> source, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");

            var e = await source.GetEnumerator(ct);
            if (!await e.MoveNext(ct)) throw new InvalidOperationException();
            var result = e.Current;
            while (await e.MoveNext(ct))
            {
                var x = e.Current;
                if (x < result) result = x;
            }
            return result;
        }
        public static async Task<long?> MinAsync(this IAsyncEnumerable<long?> source, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");

            var e = await source.GetEnumerator(ct);
            if (!await e.MoveNext(ct)) throw new InvalidOperationException();
            var result = e.Current;
            while (await e.MoveNext(ct))
            {
                var x = e.Current;
                if (x < result) result = x;
            }
            return result;
        }

        public static async Task<decimal> MinAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, decimal> selector, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");
            if (selector == null) throw new ArgumentNullException("selector");

            var e = await source.GetEnumerator(ct);
            if (!await e.MoveNext(ct)) throw new InvalidOperationException();
            var result = selector(e.Current);
            while (await e.MoveNext(ct))
            {
                var x = selector(e.Current);
                if (x < result) result = x;
            }
            return result;
        }
        public static async Task<decimal?> MinAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, decimal?> selector, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");
            if (selector == null) throw new ArgumentNullException("selector");

            var e = await source.GetEnumerator(ct);
            if (!await e.MoveNext(ct)) throw new InvalidOperationException();
            var result = selector(e.Current);
            while (await e.MoveNext(ct))
            {
                var x = selector(e.Current);
                if (x < result) result = x;
            }
            return result;
        }
        public static async Task<double> MinAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, double> selector, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");
            if (selector == null) throw new ArgumentNullException("selector");

            var e = await source.GetEnumerator(ct);
            if (!await e.MoveNext(ct)) throw new InvalidOperationException();
            var result = selector(e.Current);
            while (await e.MoveNext(ct))
            {
                var x = selector(e.Current);
                if (x < result) result = x;
            }
            return result;
        }
        public static async Task<double?> MinAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, double?> selector, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");
            if (selector == null) throw new ArgumentNullException("selector");

            var e = await source.GetEnumerator(ct);
            if (!await e.MoveNext(ct)) throw new InvalidOperationException();
            var result = selector(e.Current);
            while (await e.MoveNext(ct))
            {
                var x = selector(e.Current);
                if (x < result) result = x;
            }
            return result;
        }
        public static async Task<float> MinAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, float> selector, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");
            if (selector == null) throw new ArgumentNullException("selector");

            var e = await source.GetEnumerator(ct);
            if (!await e.MoveNext(ct)) throw new InvalidOperationException();
            var result = selector(e.Current);
            while (await e.MoveNext(ct))
            {
                var x = selector(e.Current);
                if (x < result) result = x;
            }
            return result;
        }
        public static async Task<float?> MinAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, float?> selector, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");
            if (selector == null) throw new ArgumentNullException("selector");

            var e = await source.GetEnumerator(ct);
            if (!await e.MoveNext(ct)) throw new InvalidOperationException();
            var result = selector(e.Current);
            while (await e.MoveNext(ct))
            {
                var x = selector(e.Current);
                if (x < result) result = x;
            }
            return result;
        }
        public static async Task<int> MinAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, int> selector, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");
            if (selector == null) throw new ArgumentNullException("selector");

            var e = await source.GetEnumerator(ct);
            if (!await e.MoveNext(ct)) throw new InvalidOperationException();
            var result = selector(e.Current);
            while (await e.MoveNext(ct))
            {
                var x = selector(e.Current);
                if (x < result) result = x;
            }
            return result;
        }
        public static async Task<int?> MinAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, int?> selector, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");
            if (selector == null) throw new ArgumentNullException("selector");

            var e = await source.GetEnumerator(ct);
            if (!await e.MoveNext(ct)) throw new InvalidOperationException();
            var result = selector(e.Current);
            while (await e.MoveNext(ct))
            {
                var x = selector(e.Current);
                if (x < result) result = x;
            }
            return result;
        }
        public static async Task<long> MinAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, long> selector, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");
            if (selector == null) throw new ArgumentNullException("selector");

            var e = await source.GetEnumerator(ct);
            if (!await e.MoveNext(ct)) throw new InvalidOperationException();
            var result = selector(e.Current);
            while (await e.MoveNext(ct))
            {
                var x = selector(e.Current);
                if (x < result) result = x;
            }
            return result;
        }
        public static async Task<long?> MinAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, long?> selector, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");
            if (selector == null) throw new ArgumentNullException("selector");

            var e = await source.GetEnumerator(ct);
            if (!await e.MoveNext(ct)) throw new InvalidOperationException();
            var result = selector(e.Current);
            while (await e.MoveNext(ct))
            {
                var x = selector(e.Current);
                if (x < result) result = x;
            }
            return result;
        }
    }
}
