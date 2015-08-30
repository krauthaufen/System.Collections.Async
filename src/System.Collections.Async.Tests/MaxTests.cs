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
                () => AsyncEnumerable.Max((IAsyncEnumerable<decimal>)null, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.Max((IAsyncEnumerable<double>)null, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.Max((IAsyncEnumerable<float>)null, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.Max((IAsyncEnumerable<int>)null, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.Max((IAsyncEnumerable<long>)null, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.Max((IAsyncEnumerable<uint>)null, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.Max((IAsyncEnumerable<ulong>)null, CancellationToken.None).Wait()
                );


            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.Max((IAsyncEnumerable<decimal?>)null, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.Max((IAsyncEnumerable<double?>)null, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.Max((IAsyncEnumerable<float?>)null, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.Max((IAsyncEnumerable<int?>)null, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.Max((IAsyncEnumerable<long?>)null, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.Max((IAsyncEnumerable<uint?>)null, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.Max((IAsyncEnumerable<ulong?>)null, CancellationToken.None).Wait()
                );
        }

        [TestMethod]
        public void ThrowsWhenSourceIsNull2()
        {
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.Max((IAsyncEnumerable<decimal>)null, x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.Max((IAsyncEnumerable<double>)null, x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.Max((IAsyncEnumerable<float>)null, x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.Max((IAsyncEnumerable<int>)null, x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.Max((IAsyncEnumerable<long>)null, x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.Max((IAsyncEnumerable<uint>)null, x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.Max((IAsyncEnumerable<ulong>)null, x => x, CancellationToken.None).Wait()
                );


            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.Max((IAsyncEnumerable<decimal?>)null, x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.Max((IAsyncEnumerable<double?>)null, x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.Max((IAsyncEnumerable<float?>)null, x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.Max((IAsyncEnumerable<int?>)null, x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.Max((IAsyncEnumerable<long?>)null, x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.Max((IAsyncEnumerable<uint?>)null, x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.Max((IAsyncEnumerable<ulong?>)null, x => x, CancellationToken.None).Wait()
                );
        }

        [TestMethod]
        public void ThrowsWhenSourceIsEmpty1()
        {
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.Max(AsyncEnumerable.Empty<decimal>(), CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.Max(AsyncEnumerable.Empty<double>(), CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.Max(AsyncEnumerable.Empty<float>(), CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.Max(AsyncEnumerable.Empty<int>(), CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.Max(AsyncEnumerable.Empty<long>(), CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.Max(AsyncEnumerable.Empty<uint>(), CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.Max(AsyncEnumerable.Empty<ulong>(), CancellationToken.None).Wait()
                );


            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.Max(AsyncEnumerable.Empty<decimal?>(), CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.Max(AsyncEnumerable.Empty<double?>(), CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.Max(AsyncEnumerable.Empty<float?>(), CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.Max(AsyncEnumerable.Empty<int?>(), CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.Max(AsyncEnumerable.Empty<long?>(), CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.Max(AsyncEnumerable.Empty<uint?>(), CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.Max(AsyncEnumerable.Empty<ulong?>(), CancellationToken.None).Wait()
                );
        }

        [TestMethod]
        public void ThrowsWhenSourceIsEmpty2()
        {
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.Max(AsyncEnumerable.Empty<decimal>(), x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.Max(AsyncEnumerable.Empty<double>(), x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.Max(AsyncEnumerable.Empty<float>(), x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.Max(AsyncEnumerable.Empty<int>(), x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.Max(AsyncEnumerable.Empty<long>(), x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.Max(AsyncEnumerable.Empty<uint>(), x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.Max(AsyncEnumerable.Empty<ulong>(), x => x, CancellationToken.None).Wait()
                );


            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.Max(AsyncEnumerable.Empty<decimal>(), x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.Max(AsyncEnumerable.Empty<double>(), x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.Max(AsyncEnumerable.Empty<float>(), x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.Max(AsyncEnumerable.Empty<int>(), x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.Max(AsyncEnumerable.Empty<long>(), x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.Max(AsyncEnumerable.Empty<uint>(), x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.Max(AsyncEnumerable.Empty<ulong>(), x => x, CancellationToken.None).Wait()
                );
        }

        [TestMethod]
        public void ThrowsWhenPredicateIsNull()
        {
            TestHelpers.ThrowsAggregateArgumentNullException(() =>
            {
                var xs = AsyncEnumerable.FromValues(new decimal[0]);
                AsyncEnumerable.Max(xs, (Func<decimal, decimal>)null, CancellationToken.None).Wait();
            });
            TestHelpers.ThrowsAggregateArgumentNullException(() =>
            {
                var xs = AsyncEnumerable.FromValues(new double[0]);
                AsyncEnumerable.Max(xs, (Func<double, double>)null, CancellationToken.None).Wait();
            });
            TestHelpers.ThrowsAggregateArgumentNullException(() =>
            {
                var xs = AsyncEnumerable.FromValues(new float[0]);
                AsyncEnumerable.Max(xs, (Func<float, float>)null, CancellationToken.None).Wait();
            });
            TestHelpers.ThrowsAggregateArgumentNullException(() =>
            {
                var xs = AsyncEnumerable.FromValues(new int[0]);
                AsyncEnumerable.Max(xs, (Func<int, int>)null, CancellationToken.None).Wait();
            });
            TestHelpers.ThrowsAggregateArgumentNullException(() =>
            {
                var xs = AsyncEnumerable.FromValues(new long[0]);
                AsyncEnumerable.Max(xs, (Func<long, long>)null, CancellationToken.None).Wait();
            });
            TestHelpers.ThrowsAggregateArgumentNullException(() =>
            {
                var xs = AsyncEnumerable.FromValues(new uint[0]);
                AsyncEnumerable.Max(xs, (Func<uint, uint>)null, CancellationToken.None).Wait();
            });
            TestHelpers.ThrowsAggregateArgumentNullException(() =>
            {
                var xs = AsyncEnumerable.FromValues(new ulong[0]);
                AsyncEnumerable.Max(xs, (Func<ulong, ulong>)null, CancellationToken.None).Wait();
            });


            TestHelpers.ThrowsAggregateArgumentNullException(() =>
            {
                var xs = AsyncEnumerable.FromValues(new decimal?[0]);
                AsyncEnumerable.Max(xs, (Func<decimal?, decimal?>)null, CancellationToken.None).Wait();
            });
            TestHelpers.ThrowsAggregateArgumentNullException(() =>
            {
                var xs = AsyncEnumerable.FromValues(new double?[0]);
                AsyncEnumerable.Max(xs, (Func<double?, double?>)null, CancellationToken.None).Wait();
            });
            TestHelpers.ThrowsAggregateArgumentNullException(() =>
            {
                var xs = AsyncEnumerable.FromValues(new float?[0]);
                AsyncEnumerable.Max(xs, (Func<float?, float?>)null, CancellationToken.None).Wait();
            });
            TestHelpers.ThrowsAggregateArgumentNullException(() =>
            {
                var xs = AsyncEnumerable.FromValues(new int?[0]);
                AsyncEnumerable.Max(xs, (Func<int?, int?>)null, CancellationToken.None).Wait();
            });
            TestHelpers.ThrowsAggregateArgumentNullException(() =>
            {
                var xs = AsyncEnumerable.FromValues(new long?[0]);
                AsyncEnumerable.Max(xs, (Func<long?, long?>)null, CancellationToken.None).Wait();
            });
            TestHelpers.ThrowsAggregateArgumentNullException(() =>
            {
                var xs = AsyncEnumerable.FromValues(new uint?[0]);
                AsyncEnumerable.Max(xs, (Func<uint?, uint?>)null, CancellationToken.None).Wait();
            });
            TestHelpers.ThrowsAggregateArgumentNullException(() =>
            {
                var xs = AsyncEnumerable.FromValues(new ulong?[0]);
                AsyncEnumerable.Max(xs, (Func<ulong?, ulong?>)null, CancellationToken.None).Wait();
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
            _MaxFailsWhenCancelled(() => Assert.IsTrue(AsyncEnumerable.Empty<decimal>().Max(x => x, Helper.CANCELLED).Result == 0));
            _MaxFailsWhenCancelled(() => Assert.IsTrue(AsyncEnumerable.Empty<double>().Max(x => x, Helper.CANCELLED).Result == 0));
            _MaxFailsWhenCancelled(() => Assert.IsTrue(AsyncEnumerable.Empty<float>().Max(x => x, Helper.CANCELLED).Result == 0));
            _MaxFailsWhenCancelled(() => Assert.IsTrue(AsyncEnumerable.Empty<int>().Max(x => x, Helper.CANCELLED).Result == 0));
            _MaxFailsWhenCancelled(() => Assert.IsTrue(AsyncEnumerable.Empty<long>().Max(x => x, Helper.CANCELLED).Result == 0));
            _MaxFailsWhenCancelled(() => Assert.IsTrue(AsyncEnumerable.Empty<uint>().Max(x => x, Helper.CANCELLED).Result == 0));
            _MaxFailsWhenCancelled(() => Assert.IsTrue(AsyncEnumerable.Empty<ulong>().Max(x => x, Helper.CANCELLED).Result == 0));

            _MaxFailsWhenCancelled(() => Assert.IsTrue(AsyncEnumerable.Empty<decimal?>().Max(x => x, Helper.CANCELLED).Result == 0));
            _MaxFailsWhenCancelled(() => Assert.IsTrue(AsyncEnumerable.Empty<double?>().Max(x => x, Helper.CANCELLED).Result == 0));
            _MaxFailsWhenCancelled(() => Assert.IsTrue(AsyncEnumerable.Empty<float?>().Max(x => x, Helper.CANCELLED).Result == 0));
            _MaxFailsWhenCancelled(() => Assert.IsTrue(AsyncEnumerable.Empty<int?>().Max(x => x, Helper.CANCELLED).Result == 0));
            _MaxFailsWhenCancelled(() => Assert.IsTrue(AsyncEnumerable.Empty<long?>().Max(x => x, Helper.CANCELLED).Result == 0));
            _MaxFailsWhenCancelled(() => Assert.IsTrue(AsyncEnumerable.Empty<uint?>().Max(x => x, Helper.CANCELLED).Result == 0));
            _MaxFailsWhenCancelled(() => Assert.IsTrue(AsyncEnumerable.Empty<ulong?>().Max(x => x, Helper.CANCELLED).Result == 0));
        }

        #endregion

        #region Values

        [TestMethod]
        public void MaxDecimalValues()
        {
            var xs = AsyncEnumerable.FromValues(new decimal[] { 1, 2, 6, 4 });
            Assert.IsTrue(xs.Max(CancellationToken.None).Result == 6);
            Assert.IsTrue(xs.Max(x => x, CancellationToken.None).Result == 6);
        }
        [TestMethod]
        public void MaxDoubleValues()
        {
            var xs = AsyncEnumerable.FromValues(new double[] { 1, 2, 6, 4 });
            Assert.IsTrue(xs.Max(CancellationToken.None).Result == 6);
            Assert.IsTrue(xs.Max(x => x, CancellationToken.None).Result == 6);
        }
        [TestMethod]
        public void MaxFloatValues()
        {
            var xs = AsyncEnumerable.FromValues(new float[] { 1, 2, 6, 4 });
            Assert.IsTrue(xs.Max(CancellationToken.None).Result == 6);
            Assert.IsTrue(xs.Max(x => x, CancellationToken.None).Result == 6);
        }
        [TestMethod]
        public void MaxIntValues()
        {
            var xs = AsyncEnumerable.FromValues(new int[] { 1, 2, 6, 4 });
            Assert.IsTrue(xs.Max(CancellationToken.None).Result == 6);
            Assert.IsTrue(xs.Max(x => x, CancellationToken.None).Result == 6);
        }
        [TestMethod]
        public void MaxLongValues()
        {
            var xs = AsyncEnumerable.FromValues(new long[] { 1, 2, 6, 4 });
            Assert.IsTrue(xs.Max(CancellationToken.None).Result == 6);
            Assert.IsTrue(xs.Max(x => x, CancellationToken.None).Result == 6);
        }
        [TestMethod]
        public void MaxUIntValues()
        {
            var xs = AsyncEnumerable.FromValues(new uint[] { 1, 2, 6, 4 });
            Assert.IsTrue(xs.Max(CancellationToken.None).Result == 6);
            Assert.IsTrue(xs.Max(x => x, CancellationToken.None).Result == 6);
        }
        [TestMethod]
        public void MaxULongValues()
        {
            var xs = AsyncEnumerable.FromValues(new ulong[] { 1, 2, 6, 4 });
            Assert.IsTrue(xs.Max(CancellationToken.None).Result == 6);
            Assert.IsTrue(xs.Max(x => x, CancellationToken.None).Result == 6);
        }


        [TestMethod]
        public void MaxNullableDecimalValues()
        {
            var xs = AsyncEnumerable.FromValues(new decimal?[] { 1, 2, 6, 4 });
            Assert.IsTrue(xs.Max(CancellationToken.None).Result == 6);
            Assert.IsTrue(xs.Max(x => x, CancellationToken.None).Result == 6);
        }
        [TestMethod]
        public void MaxNullableDoubleValues()
        {
            var xs = AsyncEnumerable.FromValues(new double?[] { 1, 2, 6, 4 });
            Assert.IsTrue(xs.Max(CancellationToken.None).Result == 6);
            Assert.IsTrue(xs.Max(x => x, CancellationToken.None).Result == 6);
        }
        [TestMethod]
        public void MaxNullableFloatValues()
        {
            var xs = AsyncEnumerable.FromValues(new float?[] { 1, 2, 6, 4 });
            Assert.IsTrue(xs.Max(CancellationToken.None).Result == 6);
            Assert.IsTrue(xs.Max(x => x, CancellationToken.None).Result == 6);
        }
        [TestMethod]
        public void MaxNullableIntValues()
        {
            var xs = AsyncEnumerable.FromValues(new int?[] { 1, 2, 6, 4 });
            Assert.IsTrue(xs.Max(CancellationToken.None).Result == 6);
            Assert.IsTrue(xs.Max(x => x, CancellationToken.None).Result == 6);
        }
        [TestMethod]
        public void MaxNullableLongValues()
        {
            var xs = AsyncEnumerable.FromValues(new long?[] { 1, 2, 6, 4 });
            Assert.IsTrue(xs.Max(CancellationToken.None).Result == 6);
            Assert.IsTrue(xs.Max(x => x, CancellationToken.None).Result == 6);
        }
        [TestMethod]
        public void MaxNullableUIntValues()
        {
            var xs = AsyncEnumerable.FromValues(new uint?[] { 1, 2, 6, 4 });
            Assert.IsTrue(xs.Max(CancellationToken.None).Result == 6);
            Assert.IsTrue(xs.Max(x => x, CancellationToken.None).Result == 6);
        }
        [TestMethod]
        public void MaxNullableULongValues()
        {
            var xs = AsyncEnumerable.FromValues(new ulong?[] { 1, 2, 6, 4 });
            Assert.IsTrue(xs.Max(CancellationToken.None).Result == 6);
            Assert.IsTrue(xs.Max(x => x, CancellationToken.None).Result == 6);
        }

        #endregion
    }
}
