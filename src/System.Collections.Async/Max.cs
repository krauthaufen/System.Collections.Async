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
            if (!await e.MoveNext(ct)) throw new InvalidOperationException();
            var result = e.Current;
            while (await e.MoveNext(ct))
            {
                var x = e.Current;
                if (x > result) result = x;
            }
            return result;
        }
        public static async Task<decimal?> MaxAsync(this IAsyncEnumerable<decimal?> source, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");

            var e = await source.GetEnumerator(ct);
            if (!await e.MoveNext(ct)) throw new InvalidOperationException();
            var result = e.Current;
            while (await e.MoveNext(ct))
            {
                var x = e.Current;
                if (x > result) result = x;
            }
            return result;
        }
        public static async Task<double> MaxAsync(this IAsyncEnumerable<double> source, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");

            var e = await source.GetEnumerator(ct);
            if (!await e.MoveNext(ct)) throw new InvalidOperationException();
            var result = e.Current;
            while (await e.MoveNext(ct))
            {
                var x = e.Current;
                if (x > result) result = x;
            }
            return result;
        }
        public static async Task<double?> MaxAsync(this IAsyncEnumerable<double?> source, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");

            var e = await source.GetEnumerator(ct);
            if (!await e.MoveNext(ct)) throw new InvalidOperationException();
            var result = e.Current;
            while (await e.MoveNext(ct))
            {
                var x = e.Current;
                if (x > result) result = x;
            }
            return result;
        }
        public static async Task<float> MaxAsync(this IAsyncEnumerable<float> source, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");

            var e = await source.GetEnumerator(ct);
            if (!await e.MoveNext(ct)) throw new InvalidOperationException();
            var result = e.Current;
            while (await e.MoveNext(ct))
            {
                var x = e.Current;
                if (x > result) result = x;
            }
            return result;
        }
        public static async Task<float?> MaxAsync(this IAsyncEnumerable<float?> source, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");

            var e = await source.GetEnumerator(ct);
            if (!await e.MoveNext(ct)) throw new InvalidOperationException();
            var result = e.Current;
            while (await e.MoveNext(ct))
            {
                var x = e.Current;
                if (x > result) result = x;
            }
            return result;
        }
        public static async Task<int> MaxAsync(this IAsyncEnumerable<int> source, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");

            var e = await source.GetEnumerator(ct);
            if (!await e.MoveNext(ct)) throw new InvalidOperationException();
            var result = e.Current;
            while (await e.MoveNext(ct))
            {
                var x = e.Current;
                if (x > result) result = x;
            }
            return result;
        }
        public static async Task<int?> MaxAsync(this IAsyncEnumerable<int?> source, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");

            var e = await source.GetEnumerator(ct);
            if (!await e.MoveNext(ct)) throw new InvalidOperationException();
            var result = e.Current;
            while (await e.MoveNext(ct))
            {
                var x = e.Current;
                if (x > result) result = x;
            }
            return result;
        }
        public static async Task<long> MaxAsync(this IAsyncEnumerable<long> source, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");

            var e = await source.GetEnumerator(ct);
            if (!await e.MoveNext(ct)) throw new InvalidOperationException();
            var result = e.Current;
            while (await e.MoveNext(ct))
            {
                var x = e.Current;
                if (x > result) result = x;
            }
            return result;
        }
        public static async Task<long?> MaxAsync(this IAsyncEnumerable<long?> source, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");

            var e = await source.GetEnumerator(ct);
            if (!await e.MoveNext(ct)) throw new InvalidOperationException();
            var result = e.Current;
            while (await e.MoveNext(ct))
            {
                var x = e.Current;
                if (x > result) result = x;
            }
            return result;
        }

        public static async Task<decimal> MaxAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, decimal> selector, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");
            if (selector == null) throw new ArgumentNullException("selector");

            var e = await source.GetEnumerator(ct);
            if (!await e.MoveNext(ct)) throw new InvalidOperationException();
            var result = selector(e.Current);
            while (await e.MoveNext(ct))
            {
                var x = selector(e.Current);
                if (x > result) result = x;
            }
            return result;
        }
        public static async Task<decimal?> MaxAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, decimal?> selector, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");
            if (selector == null) throw new ArgumentNullException("selector");

            var e = await source.GetEnumerator(ct);
            if (!await e.MoveNext(ct)) throw new InvalidOperationException();
            var result = selector(e.Current);
            while (await e.MoveNext(ct))
            {
                var x = selector(e.Current);
                if (x > result) result = x;
            }
            return result;
        }
        public static async Task<double> MaxAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, double> selector, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");
            if (selector == null) throw new ArgumentNullException("selector");

            var e = await source.GetEnumerator(ct);
            if (!await e.MoveNext(ct)) throw new InvalidOperationException();
            var result = selector(e.Current);
            while (await e.MoveNext(ct))
            {
                var x = selector(e.Current);
                if (x > result) result = x;
            }
            return result;
        }
        public static async Task<double?> MaxAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, double?> selector, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");
            if (selector == null) throw new ArgumentNullException("selector");

            var e = await source.GetEnumerator(ct);
            if (!await e.MoveNext(ct)) throw new InvalidOperationException();
            var result = selector(e.Current);
            while (await e.MoveNext(ct))
            {
                var x = selector(e.Current);
                if (x > result) result = x;
            }
            return result;
        }
        public static async Task<float> MaxAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, float> selector, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");
            if (selector == null) throw new ArgumentNullException("selector");

            var e = await source.GetEnumerator(ct);
            if (!await e.MoveNext(ct)) throw new InvalidOperationException();
            var result = selector(e.Current);
            while (await e.MoveNext(ct))
            {
                var x = selector(e.Current);
                if (x > result) result = x;
            }
            return result;
        }
        public static async Task<float?> MaxAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, float?> selector, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");
            if (selector == null) throw new ArgumentNullException("selector");

            var e = await source.GetEnumerator(ct);
            if (!await e.MoveNext(ct)) throw new InvalidOperationException();
            var result = selector(e.Current);
            while (await e.MoveNext(ct))
            {
                var x = selector(e.Current);
                if (x > result) result = x;
            }
            return result;
        }
        public static async Task<int> MaxAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, int> selector, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");
            if (selector == null) throw new ArgumentNullException("selector");

            var e = await source.GetEnumerator(ct);
            if (!await e.MoveNext(ct)) throw new InvalidOperationException();
            var result = selector(e.Current);
            while (await e.MoveNext(ct))
            {
                var x = selector(e.Current);
                if (x > result) result = x;
            }
            return result;
        }
        public static async Task<int?> MaxAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, int?> selector, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");
            if (selector == null) throw new ArgumentNullException("selector");

            var e = await source.GetEnumerator(ct);
            if (!await e.MoveNext(ct)) throw new InvalidOperationException();
            var result = selector(e.Current);
            while (await e.MoveNext(ct))
            {
                var x = selector(e.Current);
                if (x > result) result = x;
            }
            return result;
        }
        public static async Task<long> MaxAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, long> selector, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");
            if (selector == null) throw new ArgumentNullException("selector");

            var e = await source.GetEnumerator(ct);
            if (!await e.MoveNext(ct)) throw new InvalidOperationException();
            var result = selector(e.Current);
            while (await e.MoveNext(ct))
            {
                var x = selector(e.Current);
                if (x > result) result = x;
            }
            return result;
        }
        public static async Task<long?> MaxAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, long?> selector, CancellationToken ct = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException("source");
            if (selector == null) throw new ArgumentNullException("selector");

            var e = await source.GetEnumerator(ct);
            if (!await e.MoveNext(ct)) throw new InvalidOperationException();
            var result = selector(e.Current);
            while (await e.MoveNext(ct))
            {
                var x = selector(e.Current);
                if (x > result) result = x;
            }
            return result;
        }
    }
}
