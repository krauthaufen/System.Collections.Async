using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Collections.Async.Tests
{
    [TestClass]
    public class MaxTests
    {
        #region Exceptions
        
        [TestMethod]
        public void ThrowsWhenSourceIsNull1()
        {
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.MaxAsync((IAsyncEnumerable<decimal>)null, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.MaxAsync((IAsyncEnumerable<double>)null, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.MaxAsync((IAsyncEnumerable<float>)null, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.MaxAsync((IAsyncEnumerable<int>)null, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.MaxAsync((IAsyncEnumerable<long>)null, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.MaxAsync((IAsyncEnumerable<uint>)null, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.MaxAsync((IAsyncEnumerable<ulong>)null, CancellationToken.None).Wait()
                );


            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.MaxAsync((IAsyncEnumerable<decimal?>)null, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.MaxAsync((IAsyncEnumerable<double?>)null, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.MaxAsync((IAsyncEnumerable<float?>)null, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.MaxAsync((IAsyncEnumerable<int?>)null, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.MaxAsync((IAsyncEnumerable<long?>)null, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.MaxAsync((IAsyncEnumerable<uint?>)null, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.MaxAsync((IAsyncEnumerable<ulong?>)null, CancellationToken.None).Wait()
                );
        }

        [TestMethod]
        public void ThrowsWhenSourceIsNull2()
        {
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.MaxAsync((IAsyncEnumerable<decimal>)null, x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.MaxAsync((IAsyncEnumerable<double>)null, x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.MaxAsync((IAsyncEnumerable<float>)null, x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.MaxAsync((IAsyncEnumerable<int>)null, x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.MaxAsync((IAsyncEnumerable<long>)null, x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.MaxAsync((IAsyncEnumerable<uint>)null, x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.MaxAsync((IAsyncEnumerable<ulong>)null, x => x, CancellationToken.None).Wait()
                );


            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.MaxAsync((IAsyncEnumerable<decimal?>)null, x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.MaxAsync((IAsyncEnumerable<double?>)null, x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.MaxAsync((IAsyncEnumerable<float?>)null, x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.MaxAsync((IAsyncEnumerable<int?>)null, x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.MaxAsync((IAsyncEnumerable<long?>)null, x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.MaxAsync((IAsyncEnumerable<uint?>)null, x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.MaxAsync((IAsyncEnumerable<ulong?>)null, x => x, CancellationToken.None).Wait()
                );
        }

        [TestMethod]
        public void ThrowsWhenSourceIsEmpty1()
        {
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.MaxAsync(AsyncEnumerable.Empty<decimal>(), CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.MaxAsync(AsyncEnumerable.Empty<double>(), CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.MaxAsync(AsyncEnumerable.Empty<float>(), CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.MaxAsync(AsyncEnumerable.Empty<int>(), CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.MaxAsync(AsyncEnumerable.Empty<long>(), CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.MaxAsync(AsyncEnumerable.Empty<uint>(), CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.MaxAsync(AsyncEnumerable.Empty<ulong>(), CancellationToken.None).Wait()
                );


            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.MaxAsync(AsyncEnumerable.Empty<decimal?>(), CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.MaxAsync(AsyncEnumerable.Empty<double?>(), CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.MaxAsync(AsyncEnumerable.Empty<float?>(), CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.MaxAsync(AsyncEnumerable.Empty<int?>(), CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.MaxAsync(AsyncEnumerable.Empty<long?>(), CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.MaxAsync(AsyncEnumerable.Empty<uint?>(), CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.MaxAsync(AsyncEnumerable.Empty<ulong?>(), CancellationToken.None).Wait()
                );
        }

        [TestMethod]
        public void ThrowsWhenSourceIsEmpty2()
        {
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.MaxAsync(AsyncEnumerable.Empty<decimal>(), x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.MaxAsync(AsyncEnumerable.Empty<double>(), x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.MaxAsync(AsyncEnumerable.Empty<float>(), x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.MaxAsync(AsyncEnumerable.Empty<int>(), x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.MaxAsync(AsyncEnumerable.Empty<long>(), x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.MaxAsync(AsyncEnumerable.Empty<uint>(), x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.MaxAsync(AsyncEnumerable.Empty<ulong>(), x => x, CancellationToken.None).Wait()
                );


            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.MaxAsync(AsyncEnumerable.Empty<decimal>(), x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.MaxAsync(AsyncEnumerable.Empty<double>(), x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.MaxAsync(AsyncEnumerable.Empty<float>(), x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.MaxAsync(AsyncEnumerable.Empty<int>(), x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.MaxAsync(AsyncEnumerable.Empty<long>(), x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.MaxAsync(AsyncEnumerable.Empty<uint>(), x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.MaxAsync(AsyncEnumerable.Empty<ulong>(), x => x, CancellationToken.None).Wait()
                );
        }

        [TestMethod]
        public void ThrowsWhenPredicateIsNull()
        {
            TestHelpers.ThrowsAggregateArgumentNullException(() =>
            {
                var xs = AsyncEnumerable.FromValues(new decimal[0]);
                AsyncEnumerable.MaxAsync(xs, (Func<decimal, decimal>)null, CancellationToken.None).Wait();
            });
            TestHelpers.ThrowsAggregateArgumentNullException(() =>
            {
                var xs = AsyncEnumerable.FromValues(new double[0]);
                AsyncEnumerable.MaxAsync(xs, (Func<double, double>)null, CancellationToken.None).Wait();
            });
            TestHelpers.ThrowsAggregateArgumentNullException(() =>
            {
                var xs = AsyncEnumerable.FromValues(new float[0]);
                AsyncEnumerable.MaxAsync(xs, (Func<float, float>)null, CancellationToken.None).Wait();
            });
            TestHelpers.ThrowsAggregateArgumentNullException(() =>
            {
                var xs = AsyncEnumerable.FromValues(new int[0]);
                AsyncEnumerable.MaxAsync(xs, (Func<int, int>)null, CancellationToken.None).Wait();
            });
            TestHelpers.ThrowsAggregateArgumentNullException(() =>
            {
                var xs = AsyncEnumerable.FromValues(new long[0]);
                AsyncEnumerable.MaxAsync(xs, (Func<long, long>)null, CancellationToken.None).Wait();
            });
            TestHelpers.ThrowsAggregateArgumentNullException(() =>
            {
                var xs = AsyncEnumerable.FromValues(new uint[0]);
                AsyncEnumerable.MaxAsync(xs, (Func<uint, uint>)null, CancellationToken.None).Wait();
            });
            TestHelpers.ThrowsAggregateArgumentNullException(() =>
            {
                var xs = AsyncEnumerable.FromValues(new ulong[0]);
                AsyncEnumerable.MaxAsync(xs, (Func<ulong, ulong>)null, CancellationToken.None).Wait();
            });


            TestHelpers.ThrowsAggregateArgumentNullException(() =>
            {
                var xs = AsyncEnumerable.FromValues(new decimal?[0]);
                AsyncEnumerable.MaxAsync(xs, (Func<decimal?, decimal?>)null, CancellationToken.None).Wait();
            });
            TestHelpers.ThrowsAggregateArgumentNullException(() =>
            {
                var xs = AsyncEnumerable.FromValues(new double?[0]);
                AsyncEnumerable.MaxAsync(xs, (Func<double?, double?>)null, CancellationToken.None).Wait();
            });
            TestHelpers.ThrowsAggregateArgumentNullException(() =>
            {
                var xs = AsyncEnumerable.FromValues(new float?[0]);
                AsyncEnumerable.MaxAsync(xs, (Func<float?, float?>)null, CancellationToken.None).Wait();
            });
            TestHelpers.ThrowsAggregateArgumentNullException(() =>
            {
                var xs = AsyncEnumerable.FromValues(new int?[0]);
                AsyncEnumerable.MaxAsync(xs, (Func<int?, int?>)null, CancellationToken.None).Wait();
            });
            TestHelpers.ThrowsAggregateArgumentNullException(() =>
            {
                var xs = AsyncEnumerable.FromValues(new long?[0]);
                AsyncEnumerable.MaxAsync(xs, (Func<long?, long?>)null, CancellationToken.None).Wait();
            });
            TestHelpers.ThrowsAggregateArgumentNullException(() =>
            {
                var xs = AsyncEnumerable.FromValues(new uint?[0]);
                AsyncEnumerable.MaxAsync(xs, (Func<uint?, uint?>)null, CancellationToken.None).Wait();
            });
            TestHelpers.ThrowsAggregateArgumentNullException(() =>
            {
                var xs = AsyncEnumerable.FromValues(new ulong?[0]);
                AsyncEnumerable.MaxAsync(xs, (Func<ulong?, ulong?>)null, CancellationToken.None).Wait();
            });
        }

        #endregion
        
        #region Cancelled

        private void _MaxFailsWhenCancelled(Action action)
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
        public void MaxFailsWhenCancelled()
        {
            _MaxFailsWhenCancelled(() => Assert.IsTrue(AsyncEnumerable.Empty<decimal>().MaxAsync(x => x, Helper.CANCELLED).Result == 0));
            _MaxFailsWhenCancelled(() => Assert.IsTrue(AsyncEnumerable.Empty<double>().MaxAsync(x => x, Helper.CANCELLED).Result == 0));
            _MaxFailsWhenCancelled(() => Assert.IsTrue(AsyncEnumerable.Empty<float>().MaxAsync(x => x, Helper.CANCELLED).Result == 0));
            _MaxFailsWhenCancelled(() => Assert.IsTrue(AsyncEnumerable.Empty<int>().MaxAsync(x => x, Helper.CANCELLED).Result == 0));
            _MaxFailsWhenCancelled(() => Assert.IsTrue(AsyncEnumerable.Empty<long>().MaxAsync(x => x, Helper.CANCELLED).Result == 0));
            _MaxFailsWhenCancelled(() => Assert.IsTrue(AsyncEnumerable.Empty<uint>().MaxAsync(x => x, Helper.CANCELLED).Result == 0));
            _MaxFailsWhenCancelled(() => Assert.IsTrue(AsyncEnumerable.Empty<ulong>().MaxAsync(x => x, Helper.CANCELLED).Result == 0));

            _MaxFailsWhenCancelled(() => Assert.IsTrue(AsyncEnumerable.Empty<decimal?>().MaxAsync(x => x, Helper.CANCELLED).Result == 0));
            _MaxFailsWhenCancelled(() => Assert.IsTrue(AsyncEnumerable.Empty<double?>().MaxAsync(x => x, Helper.CANCELLED).Result == 0));
            _MaxFailsWhenCancelled(() => Assert.IsTrue(AsyncEnumerable.Empty<float?>().MaxAsync(x => x, Helper.CANCELLED).Result == 0));
            _MaxFailsWhenCancelled(() => Assert.IsTrue(AsyncEnumerable.Empty<int?>().MaxAsync(x => x, Helper.CANCELLED).Result == 0));
            _MaxFailsWhenCancelled(() => Assert.IsTrue(AsyncEnumerable.Empty<long?>().MaxAsync(x => x, Helper.CANCELLED).Result == 0));
            _MaxFailsWhenCancelled(() => Assert.IsTrue(AsyncEnumerable.Empty<uint?>().MaxAsync(x => x, Helper.CANCELLED).Result == 0));
            _MaxFailsWhenCancelled(() => Assert.IsTrue(AsyncEnumerable.Empty<ulong?>().MaxAsync(x => x, Helper.CANCELLED).Result == 0));
        }

        #endregion

        #region Values

        [TestMethod]
        public void MaxDecimalValues()
        {
            var xs = AsyncEnumerable.FromValues(new decimal[] { 1, 2, 6, 4 });
            Assert.IsTrue(xs.MaxAsync(CancellationToken.None).Result == 6);
            Assert.IsTrue(xs.MaxAsync(x => x, CancellationToken.None).Result == 6);
        }
        [TestMethod]
        public void MaxDoubleValues()
        {
            var xs = AsyncEnumerable.FromValues(new double[] { 1, 2, 6, 4 });
            Assert.IsTrue(xs.MaxAsync(CancellationToken.None).Result == 6);
            Assert.IsTrue(xs.MaxAsync(x => x, CancellationToken.None).Result == 6);
        }
        [TestMethod]
        public void MaxFloatValues()
        {
            var xs = AsyncEnumerable.FromValues(new float[] { 1, 2, 6, 4 });
            Assert.IsTrue(xs.MaxAsync(CancellationToken.None).Result == 6);
            Assert.IsTrue(xs.MaxAsync(x => x, CancellationToken.None).Result == 6);
        }
        [TestMethod]
        public void MaxIntValues()
        {
            var xs = AsyncEnumerable.FromValues(new int[] { 1, 2, 6, 4 });
            Assert.IsTrue(xs.MaxAsync(CancellationToken.None).Result == 6);
            Assert.IsTrue(xs.MaxAsync(x => x, CancellationToken.None).Result == 6);
        }
        [TestMethod]
        public void MaxLongValues()
        {
            var xs = AsyncEnumerable.FromValues(new long[] { 1, 2, 6, 4 });
            Assert.IsTrue(xs.MaxAsync(CancellationToken.None).Result == 6);
            Assert.IsTrue(xs.MaxAsync(x => x, CancellationToken.None).Result == 6);
        }
        [TestMethod]
        public void MaxUIntValues()
        {
            var xs = AsyncEnumerable.FromValues(new uint[] { 1, 2, 6, 4 });
            Assert.IsTrue(xs.MaxAsync(CancellationToken.None).Result == 6);
            Assert.IsTrue(xs.MaxAsync(x => x, CancellationToken.None).Result == 6);
        }
        [TestMethod]
        public void MaxULongValues()
        {
            var xs = AsyncEnumerable.FromValues(new ulong[] { 1, 2, 6, 4 });
            Assert.IsTrue(xs.MaxAsync(CancellationToken.None).Result == 6);
            Assert.IsTrue(xs.MaxAsync(x => x, CancellationToken.None).Result == 6);
        }


        [TestMethod]
        public void MaxNullableDecimalValues()
        {
            var xs = AsyncEnumerable.FromValues(new decimal?[] { 1, 2, 6, 4 });
            Assert.IsTrue(xs.MaxAsync(CancellationToken.None).Result == 6);
            Assert.IsTrue(xs.MaxAsync(x => x, CancellationToken.None).Result == 6);
        }
        [TestMethod]
        public void MaxNullableDoubleValues()
        {
            var xs = AsyncEnumerable.FromValues(new double?[] { 1, 2, 6, 4 });
            Assert.IsTrue(xs.MaxAsync(CancellationToken.None).Result == 6);
            Assert.IsTrue(xs.MaxAsync(x => x, CancellationToken.None).Result == 6);
        }
        [TestMethod]
        public void MaxNullableFloatValues()
        {
            var xs = AsyncEnumerable.FromValues(new float?[] { 1, 2, 6, 4 });
            Assert.IsTrue(xs.MaxAsync(CancellationToken.None).Result == 6);
            Assert.IsTrue(xs.MaxAsync(x => x, CancellationToken.None).Result == 6);
        }
        [TestMethod]
        public void MaxNullableIntValues()
        {
            var xs = AsyncEnumerable.FromValues(new int?[] { 1, 2, 6, 4 });
            Assert.IsTrue(xs.MaxAsync(CancellationToken.None).Result == 6);
            Assert.IsTrue(xs.MaxAsync(x => x, CancellationToken.None).Result == 6);
        }
        [TestMethod]
        public void MaxNullableLongValues()
        {
            var xs = AsyncEnumerable.FromValues(new long?[] { 1, 2, 6, 4 });
            Assert.IsTrue(xs.MaxAsync(CancellationToken.None).Result == 6);
            Assert.IsTrue(xs.MaxAsync(x => x, CancellationToken.None).Result == 6);
        }
        [TestMethod]
        public void MaxNullableUIntValues()
        {
            var xs = AsyncEnumerable.FromValues(new uint?[] { 1, 2, 6, 4 });
            Assert.IsTrue(xs.MaxAsync(CancellationToken.None).Result == 6);
            Assert.IsTrue(xs.MaxAsync(x => x, CancellationToken.None).Result == 6);
        }
        [TestMethod]
        public void MaxNullableULongValues()
        {
            var xs = AsyncEnumerable.FromValues(new ulong?[] { 1, 2, 6, 4 });
            Assert.IsTrue(xs.MaxAsync(CancellationToken.None).Result == 6);
            Assert.IsTrue(xs.MaxAsync(x => x, CancellationToken.None).Result == 6);
        }

        #endregion
    }
}
