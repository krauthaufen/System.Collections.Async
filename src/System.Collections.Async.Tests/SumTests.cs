using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Collections.Async.Tests
{
    [TestClass]
    public class SumTests
    {
        #region Exceptions
        
        [TestMethod]
        public void ThrowsWhenSourceIsNull1()
        {
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.Sum((IAsyncEnumerable<decimal>)null, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.Sum((IAsyncEnumerable<double>)null, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.Sum((IAsyncEnumerable<float>)null, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.Sum((IAsyncEnumerable<int>)null, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.Sum((IAsyncEnumerable<long>)null, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.Sum((IAsyncEnumerable<uint>)null, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.Sum((IAsyncEnumerable<ulong>)null, CancellationToken.None).Wait()
                );


            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.Sum((IAsyncEnumerable<decimal?>)null, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.Sum((IAsyncEnumerable<double?>)null, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.Sum((IAsyncEnumerable<float?>)null, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.Sum((IAsyncEnumerable<int?>)null, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.Sum((IAsyncEnumerable<long?>)null, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.Sum((IAsyncEnumerable<uint?>)null, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.Sum((IAsyncEnumerable<ulong?>)null, CancellationToken.None).Wait()
                );
        }

        [TestMethod]
        public void ThrowsWhenSourceIsNull2()
        {
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.Sum((IAsyncEnumerable<decimal>)null, x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.Sum((IAsyncEnumerable<double>)null, x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.Sum((IAsyncEnumerable<float>)null, x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.Sum((IAsyncEnumerable<int>)null, x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.Sum((IAsyncEnumerable<long>)null, x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.Sum((IAsyncEnumerable<uint>)null, x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.Sum((IAsyncEnumerable<ulong>)null, x => x, CancellationToken.None).Wait()
                );


            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.Sum((IAsyncEnumerable<decimal?>)null, x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.Sum((IAsyncEnumerable<double?>)null, x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.Sum((IAsyncEnumerable<float?>)null, x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.Sum((IAsyncEnumerable<int?>)null, x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.Sum((IAsyncEnumerable<long?>)null, x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.Sum((IAsyncEnumerable<uint?>)null, x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.Sum((IAsyncEnumerable<ulong?>)null, x => x, CancellationToken.None).Wait()
                );
        }
        
        [TestMethod]
        public void ThrowsWhenPredicateIsNull()
        {
            TestHelpers.ThrowsAggregateArgumentNullException(() =>
            {
                var xs = AsyncEnumerable.FromValues(new decimal[0]);
                AsyncEnumerable.Sum(xs, (Func<decimal, decimal>)null, CancellationToken.None).Wait();
            });
            TestHelpers.ThrowsAggregateArgumentNullException(() =>
            {
                var xs = AsyncEnumerable.FromValues(new double[0]);
                AsyncEnumerable.Sum(xs, (Func<double, double>)null, CancellationToken.None).Wait();
            });
            TestHelpers.ThrowsAggregateArgumentNullException(() =>
            {
                var xs = AsyncEnumerable.FromValues(new float[0]);
                AsyncEnumerable.Sum(xs, (Func<float, float>)null, CancellationToken.None).Wait();
            });
            TestHelpers.ThrowsAggregateArgumentNullException(() =>
            {
                var xs = AsyncEnumerable.FromValues(new int[0]);
                AsyncEnumerable.Sum(xs, (Func<int, int>)null, CancellationToken.None).Wait();
            });
            TestHelpers.ThrowsAggregateArgumentNullException(() =>
            {
                var xs = AsyncEnumerable.FromValues(new long[0]);
                AsyncEnumerable.Sum(xs, (Func<long, long>)null, CancellationToken.None).Wait();
            });
            TestHelpers.ThrowsAggregateArgumentNullException(() =>
            {
                var xs = AsyncEnumerable.FromValues(new uint[0]);
                AsyncEnumerable.Sum(xs, (Func<uint, uint>)null, CancellationToken.None).Wait();
            });
            TestHelpers.ThrowsAggregateArgumentNullException(() =>
            {
                var xs = AsyncEnumerable.FromValues(new ulong[0]);
                AsyncEnumerable.Sum(xs, (Func<ulong, ulong>)null, CancellationToken.None).Wait();
            });


            TestHelpers.ThrowsAggregateArgumentNullException(() =>
            {
                var xs = AsyncEnumerable.FromValues(new decimal?[0]);
                AsyncEnumerable.Sum(xs, (Func<decimal?, decimal?>)null, CancellationToken.None).Wait();
            });
            TestHelpers.ThrowsAggregateArgumentNullException(() =>
            {
                var xs = AsyncEnumerable.FromValues(new double?[0]);
                AsyncEnumerable.Sum(xs, (Func<double?, double?>)null, CancellationToken.None).Wait();
            });
            TestHelpers.ThrowsAggregateArgumentNullException(() =>
            {
                var xs = AsyncEnumerable.FromValues(new float?[0]);
                AsyncEnumerable.Sum(xs, (Func<float?, float?>)null, CancellationToken.None).Wait();
            });
            TestHelpers.ThrowsAggregateArgumentNullException(() =>
            {
                var xs = AsyncEnumerable.FromValues(new int?[0]);
                AsyncEnumerable.Sum(xs, (Func<int?, int?>)null, CancellationToken.None).Wait();
            });
            TestHelpers.ThrowsAggregateArgumentNullException(() =>
            {
                var xs = AsyncEnumerable.FromValues(new long?[0]);
                AsyncEnumerable.Sum(xs, (Func<long?, long?>)null, CancellationToken.None).Wait();
            });
            TestHelpers.ThrowsAggregateArgumentNullException(() =>
            {
                var xs = AsyncEnumerable.FromValues(new uint?[0]);
                AsyncEnumerable.Sum(xs, (Func<uint?, uint?>)null, CancellationToken.None).Wait();
            });
            TestHelpers.ThrowsAggregateArgumentNullException(() =>
            {
                var xs = AsyncEnumerable.FromValues(new ulong?[0]);
                AsyncEnumerable.Sum(xs, (Func<ulong?, ulong?>)null, CancellationToken.None).Wait();
            });
        }

        #endregion

        #region Empty

        [TestMethod]
        public void SumEmpty()
        {
            Assert.IsTrue(AsyncEnumerable.Empty<decimal>().Sum(x => x, CancellationToken.None).Result == 0);
            Assert.IsTrue(AsyncEnumerable.Empty<double>().Sum(x => x, CancellationToken.None).Result == 0);
            Assert.IsTrue(AsyncEnumerable.Empty<float>().Sum(x => x, CancellationToken.None).Result == 0);
            Assert.IsTrue(AsyncEnumerable.Empty<int>().Sum(x => x, CancellationToken.None).Result == 0);
            Assert.IsTrue(AsyncEnumerable.Empty<long>().Sum(x => x, CancellationToken.None).Result == 0);
            Assert.IsTrue(AsyncEnumerable.Empty<uint>().Sum(x => x, CancellationToken.None).Result == 0);
            Assert.IsTrue(AsyncEnumerable.Empty<ulong>().Sum(x => x, CancellationToken.None).Result == 0);
        }

        [TestMethod]
        public void SumNullableEmpty()
        {
            Assert.IsTrue(AsyncEnumerable.Empty<decimal?>().Sum(x => x, CancellationToken.None).Result == 0);
            Assert.IsTrue(AsyncEnumerable.Empty<double?>().Sum(x => x, CancellationToken.None).Result == 0);
            Assert.IsTrue(AsyncEnumerable.Empty<float?>().Sum(x => x, CancellationToken.None).Result == 0);
            Assert.IsTrue(AsyncEnumerable.Empty<int?>().Sum(x => x, CancellationToken.None).Result == 0);
            Assert.IsTrue(AsyncEnumerable.Empty<long?>().Sum(x => x, CancellationToken.None).Result == 0);
            Assert.IsTrue(AsyncEnumerable.Empty<uint?>().Sum(x => x, CancellationToken.None).Result == 0);
            Assert.IsTrue(AsyncEnumerable.Empty<ulong?>().Sum(x => x, CancellationToken.None).Result == 0);
        }

        #endregion

        #region Cancelled

        private void _SumFailsWhenCancelled(Action action)
        {
            try
            {
                action();
            }
            catch
            {
                Assert.IsTrue(Helper.CANCELLED.IsCancellationRequested);
            }
        }

        [TestMethod]
        public void SumFailsWhenCancelled()
        {
            _SumFailsWhenCancelled(() => Assert.IsTrue(AsyncEnumerable.Empty<decimal>().Sum(x => x, Helper.CANCELLED).Result == 0));
            _SumFailsWhenCancelled(() => Assert.IsTrue(AsyncEnumerable.Empty<double>().Sum(x => x, Helper.CANCELLED).Result == 0));
            _SumFailsWhenCancelled(() => Assert.IsTrue(AsyncEnumerable.Empty<float>().Sum(x => x, Helper.CANCELLED).Result == 0));
            _SumFailsWhenCancelled(() => Assert.IsTrue(AsyncEnumerable.Empty<int>().Sum(x => x, Helper.CANCELLED).Result == 0));
            _SumFailsWhenCancelled(() => Assert.IsTrue(AsyncEnumerable.Empty<long>().Sum(x => x, Helper.CANCELLED).Result == 0));
            _SumFailsWhenCancelled(() => Assert.IsTrue(AsyncEnumerable.Empty<uint>().Sum(x => x, Helper.CANCELLED).Result == 0));
            _SumFailsWhenCancelled(() => Assert.IsTrue(AsyncEnumerable.Empty<ulong>().Sum(x => x, Helper.CANCELLED).Result == 0));

            _SumFailsWhenCancelled(() => Assert.IsTrue(AsyncEnumerable.Empty<decimal?>().Sum(x => x, Helper.CANCELLED).Result == 0));
            _SumFailsWhenCancelled(() => Assert.IsTrue(AsyncEnumerable.Empty<double?>().Sum(x => x, Helper.CANCELLED).Result == 0));
            _SumFailsWhenCancelled(() => Assert.IsTrue(AsyncEnumerable.Empty<float?>().Sum(x => x, Helper.CANCELLED).Result == 0));
            _SumFailsWhenCancelled(() => Assert.IsTrue(AsyncEnumerable.Empty<int?>().Sum(x => x, Helper.CANCELLED).Result == 0));
            _SumFailsWhenCancelled(() => Assert.IsTrue(AsyncEnumerable.Empty<long?>().Sum(x => x, Helper.CANCELLED).Result == 0));
            _SumFailsWhenCancelled(() => Assert.IsTrue(AsyncEnumerable.Empty<uint?>().Sum(x => x, Helper.CANCELLED).Result == 0));
            _SumFailsWhenCancelled(() => Assert.IsTrue(AsyncEnumerable.Empty<ulong?>().Sum(x => x, Helper.CANCELLED).Result == 0));
        }

        #endregion

        #region Values

        [TestMethod]
        public void SumDecimalValues()
        {
            var xs = AsyncEnumerable.FromValues(new decimal[] { 1, 2, 3, 4 });
            Assert.IsTrue(xs.Sum(CancellationToken.None).Result == 10);
            Assert.IsTrue(xs.Sum(x => x, CancellationToken.None).Result == 10);
        }
        [TestMethod]
        public void SumDoubleValues()
        {
            var xs = AsyncEnumerable.FromValues(new double[] { 1, 2, 3, 4 });
            Assert.IsTrue(xs.Sum(CancellationToken.None).Result == 10);
            Assert.IsTrue(xs.Sum(x => x, CancellationToken.None).Result == 10);
        }
        [TestMethod]
        public void SumFloatValues()
        {
            var xs = AsyncEnumerable.FromValues(new float[] { 1, 2, 3, 4 });
            Assert.IsTrue(xs.Sum(CancellationToken.None).Result == 10);
            Assert.IsTrue(xs.Sum(x => x, CancellationToken.None).Result == 10);
        }
        [TestMethod]
        public void SumIntValues()
        {
            var xs = AsyncEnumerable.FromValues(new int[] { 1, 2, 3, 4 });
            Assert.IsTrue(xs.Sum(CancellationToken.None).Result == 10);
            Assert.IsTrue(xs.Sum(x => x, CancellationToken.None).Result == 10);
        }
        [TestMethod]
        public void SumLongValues()
        {
            var xs = AsyncEnumerable.FromValues(new long[] { 1, 2, 3, 4 });
            Assert.IsTrue(xs.Sum(CancellationToken.None).Result == 10);
            Assert.IsTrue(xs.Sum(x => x, CancellationToken.None).Result == 10);
        }
        [TestMethod]
        public void SumUIntValues()
        {
            var xs = AsyncEnumerable.FromValues(new uint[] { 1, 2, 3, 4 });
            Assert.IsTrue(xs.Sum(CancellationToken.None).Result == 10);
            Assert.IsTrue(xs.Sum(x => x, CancellationToken.None).Result == 10);
        }
        [TestMethod]
        public void SumULongValues()
        {
            var xs = AsyncEnumerable.FromValues(new ulong[] { 1, 2, 3, 4 });
            Assert.IsTrue(xs.Sum(CancellationToken.None).Result == 10);
            Assert.IsTrue(xs.Sum(x => x, CancellationToken.None).Result == 10);
        }


        [TestMethod]
        public void SumNullableDecimalValues()
        {
            var xs = AsyncEnumerable.FromValues(new decimal?[] { 1, 2, 3, 4 });
            Assert.IsTrue(xs.Sum(CancellationToken.None).Result == 10);
            Assert.IsTrue(xs.Sum(x => x, CancellationToken.None).Result == 10);
        }
        [TestMethod]
        public void SumNullableDoubleValues()
        {
            var xs = AsyncEnumerable.FromValues(new double?[] { 1, 2, 3, 4 });
            Assert.IsTrue(xs.Sum(CancellationToken.None).Result == 10);
            Assert.IsTrue(xs.Sum(x => x, CancellationToken.None).Result == 10);
        }
        [TestMethod]
        public void SumNullableFloatValues()
        {
            var xs = AsyncEnumerable.FromValues(new float?[] { 1, 2, 3, 4 });
            Assert.IsTrue(xs.Sum(CancellationToken.None).Result == 10);
            Assert.IsTrue(xs.Sum(x => x, CancellationToken.None).Result == 10);
        }
        [TestMethod]
        public void SumNullableIntValues()
        {
            var xs = AsyncEnumerable.FromValues(new int?[] { 1, 2, 3, 4 });
            Assert.IsTrue(xs.Sum(CancellationToken.None).Result == 10);
            Assert.IsTrue(xs.Sum(x => x, CancellationToken.None).Result == 10);
        }
        [TestMethod]
        public void SumNullableLongValues()
        {
            var xs = AsyncEnumerable.FromValues(new long?[] { 1, 2, 3, 4 });
            Assert.IsTrue(xs.Sum(CancellationToken.None).Result == 10);
            Assert.IsTrue(xs.Sum(x => x, CancellationToken.None).Result == 10);
        }
        [TestMethod]
        public void SumNullableUIntValues()
        {
            var xs = AsyncEnumerable.FromValues(new uint?[] { 1, 2, 3, 4 });
            Assert.IsTrue(xs.Sum(CancellationToken.None).Result == 10);
            Assert.IsTrue(xs.Sum(x => x, CancellationToken.None).Result == 10);
        }
        [TestMethod]
        public void SumNullableULongValues()
        {
            var xs = AsyncEnumerable.FromValues(new ulong?[] { 1, 2, 3, 4 });
            Assert.IsTrue(xs.Sum(CancellationToken.None).Result == 10);
            Assert.IsTrue(xs.Sum(x => x, CancellationToken.None).Result == 10);
        }

        #endregion
    }
}
