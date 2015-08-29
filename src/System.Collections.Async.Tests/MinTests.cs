using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Collections.Async.Tests
{
    [TestClass]
    public class MinTests
    {
        #region Exceptions
        
        [TestMethod]
        public void ThrowsWhenSourceIsNull1()
        {
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.MinAsync((IAsyncEnumerable<decimal>)null, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.MinAsync((IAsyncEnumerable<double>)null, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.MinAsync((IAsyncEnumerable<float>)null, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.MinAsync((IAsyncEnumerable<int>)null, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.MinAsync((IAsyncEnumerable<long>)null, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.MinAsync((IAsyncEnumerable<uint>)null, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.MinAsync((IAsyncEnumerable<ulong>)null, CancellationToken.None).Wait()
                );


            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.MinAsync((IAsyncEnumerable<decimal?>)null, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.MinAsync((IAsyncEnumerable<double?>)null, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.MinAsync((IAsyncEnumerable<float?>)null, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.MinAsync((IAsyncEnumerable<int?>)null, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.MinAsync((IAsyncEnumerable<long?>)null, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.MinAsync((IAsyncEnumerable<uint?>)null, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.MinAsync((IAsyncEnumerable<ulong?>)null, CancellationToken.None).Wait()
                );
        }

        [TestMethod]
        public void ThrowsWhenSourceIsNull2()
        {
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.MinAsync((IAsyncEnumerable<decimal>)null, x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.MinAsync((IAsyncEnumerable<double>)null, x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.MinAsync((IAsyncEnumerable<float>)null, x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.MinAsync((IAsyncEnumerable<int>)null, x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.MinAsync((IAsyncEnumerable<long>)null, x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.MinAsync((IAsyncEnumerable<uint>)null, x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.MinAsync((IAsyncEnumerable<ulong>)null, x => x, CancellationToken.None).Wait()
                );


            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.MinAsync((IAsyncEnumerable<decimal?>)null, x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.MinAsync((IAsyncEnumerable<double?>)null, x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.MinAsync((IAsyncEnumerable<float?>)null, x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.MinAsync((IAsyncEnumerable<int?>)null, x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.MinAsync((IAsyncEnumerable<long?>)null, x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.MinAsync((IAsyncEnumerable<uint?>)null, x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.MinAsync((IAsyncEnumerable<ulong?>)null, x => x, CancellationToken.None).Wait()
                );
        }

        [TestMethod]
        public void ThrowsWhenSourceIsEmpty1()
        {
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.MinAsync(AsyncEnumerable.Empty<decimal>(), CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.MinAsync(AsyncEnumerable.Empty<double>(), CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.MinAsync(AsyncEnumerable.Empty<float>(), CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.MinAsync(AsyncEnumerable.Empty<int>(), CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.MinAsync(AsyncEnumerable.Empty<long>(), CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.MinAsync(AsyncEnumerable.Empty<uint>(), CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.MinAsync(AsyncEnumerable.Empty<ulong>(), CancellationToken.None).Wait()
                );


            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.MinAsync(AsyncEnumerable.Empty<decimal?>(), CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.MinAsync(AsyncEnumerable.Empty<double?>(), CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.MinAsync(AsyncEnumerable.Empty<float?>(), CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.MinAsync(AsyncEnumerable.Empty<int?>(), CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.MinAsync(AsyncEnumerable.Empty<long?>(), CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.MinAsync(AsyncEnumerable.Empty<uint?>(), CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.MinAsync(AsyncEnumerable.Empty<ulong?>(), CancellationToken.None).Wait()
                );
        }

        [TestMethod]
        public void ThrowsWhenSourceIsEmpty2()
        {
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.MinAsync(AsyncEnumerable.Empty<decimal>(), x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.MinAsync(AsyncEnumerable.Empty<double>(), x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.MinAsync(AsyncEnumerable.Empty<float>(), x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.MinAsync(AsyncEnumerable.Empty<int>(), x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.MinAsync(AsyncEnumerable.Empty<long>(), x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.MinAsync(AsyncEnumerable.Empty<uint>(), x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.MinAsync(AsyncEnumerable.Empty<ulong>(), x => x, CancellationToken.None).Wait()
                );


            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.MinAsync(AsyncEnumerable.Empty<decimal>(), x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.MinAsync(AsyncEnumerable.Empty<double>(), x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.MinAsync(AsyncEnumerable.Empty<float>(), x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.MinAsync(AsyncEnumerable.Empty<int>(), x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.MinAsync(AsyncEnumerable.Empty<long>(), x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.MinAsync(AsyncEnumerable.Empty<uint>(), x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.MinAsync(AsyncEnumerable.Empty<ulong>(), x => x, CancellationToken.None).Wait()
                );
        }

        [TestMethod]
        public void ThrowsWhenPredicateIsNull()
        {
            TestHelpers.ThrowsAggregateArgumentNullException(() =>
            {
                var xs = AsyncEnumerable.FromValues(new decimal[0]);
                AsyncEnumerable.MinAsync(xs, (Func<decimal, decimal>)null, CancellationToken.None).Wait();
            });
            TestHelpers.ThrowsAggregateArgumentNullException(() =>
            {
                var xs = AsyncEnumerable.FromValues(new double[0]);
                AsyncEnumerable.MinAsync(xs, (Func<double, double>)null, CancellationToken.None).Wait();
            });
            TestHelpers.ThrowsAggregateArgumentNullException(() =>
            {
                var xs = AsyncEnumerable.FromValues(new float[0]);
                AsyncEnumerable.MinAsync(xs, (Func<float, float>)null, CancellationToken.None).Wait();
            });
            TestHelpers.ThrowsAggregateArgumentNullException(() =>
            {
                var xs = AsyncEnumerable.FromValues(new int[0]);
                AsyncEnumerable.MinAsync(xs, (Func<int, int>)null, CancellationToken.None).Wait();
            });
            TestHelpers.ThrowsAggregateArgumentNullException(() =>
            {
                var xs = AsyncEnumerable.FromValues(new long[0]);
                AsyncEnumerable.MinAsync(xs, (Func<long, long>)null, CancellationToken.None).Wait();
            });
            TestHelpers.ThrowsAggregateArgumentNullException(() =>
            {
                var xs = AsyncEnumerable.FromValues(new uint[0]);
                AsyncEnumerable.MinAsync(xs, (Func<uint, uint>)null, CancellationToken.None).Wait();
            });
            TestHelpers.ThrowsAggregateArgumentNullException(() =>
            {
                var xs = AsyncEnumerable.FromValues(new ulong[0]);
                AsyncEnumerable.MinAsync(xs, (Func<ulong, ulong>)null, CancellationToken.None).Wait();
            });


            TestHelpers.ThrowsAggregateArgumentNullException(() =>
            {
                var xs = AsyncEnumerable.FromValues(new decimal?[0]);
                AsyncEnumerable.MinAsync(xs, (Func<decimal?, decimal?>)null, CancellationToken.None).Wait();
            });
            TestHelpers.ThrowsAggregateArgumentNullException(() =>
            {
                var xs = AsyncEnumerable.FromValues(new double?[0]);
                AsyncEnumerable.MinAsync(xs, (Func<double?, double?>)null, CancellationToken.None).Wait();
            });
            TestHelpers.ThrowsAggregateArgumentNullException(() =>
            {
                var xs = AsyncEnumerable.FromValues(new float?[0]);
                AsyncEnumerable.MinAsync(xs, (Func<float?, float?>)null, CancellationToken.None).Wait();
            });
            TestHelpers.ThrowsAggregateArgumentNullException(() =>
            {
                var xs = AsyncEnumerable.FromValues(new int?[0]);
                AsyncEnumerable.MinAsync(xs, (Func<int?, int?>)null, CancellationToken.None).Wait();
            });
            TestHelpers.ThrowsAggregateArgumentNullException(() =>
            {
                var xs = AsyncEnumerable.FromValues(new long?[0]);
                AsyncEnumerable.MinAsync(xs, (Func<long?, long?>)null, CancellationToken.None).Wait();
            });
            TestHelpers.ThrowsAggregateArgumentNullException(() =>
            {
                var xs = AsyncEnumerable.FromValues(new uint?[0]);
                AsyncEnumerable.MinAsync(xs, (Func<uint?, uint?>)null, CancellationToken.None).Wait();
            });
            TestHelpers.ThrowsAggregateArgumentNullException(() =>
            {
                var xs = AsyncEnumerable.FromValues(new ulong?[0]);
                AsyncEnumerable.MinAsync(xs, (Func<ulong?, ulong?>)null, CancellationToken.None).Wait();
            });
        }

        #endregion
        
        #region Cancelled

        private void _MinFailsWhenCancelled(Action action)
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
        public void MinFailsWhenCancelled()
        {
            _MinFailsWhenCancelled(() => Assert.IsTrue(AsyncEnumerable.Empty<decimal>().MinAsync(x => x, Helper.CANCELLED).Result == 0));
            _MinFailsWhenCancelled(() => Assert.IsTrue(AsyncEnumerable.Empty<double>().MinAsync(x => x, Helper.CANCELLED).Result == 0));
            _MinFailsWhenCancelled(() => Assert.IsTrue(AsyncEnumerable.Empty<float>().MinAsync(x => x, Helper.CANCELLED).Result == 0));
            _MinFailsWhenCancelled(() => Assert.IsTrue(AsyncEnumerable.Empty<int>().MinAsync(x => x, Helper.CANCELLED).Result == 0));
            _MinFailsWhenCancelled(() => Assert.IsTrue(AsyncEnumerable.Empty<long>().MinAsync(x => x, Helper.CANCELLED).Result == 0));
            _MinFailsWhenCancelled(() => Assert.IsTrue(AsyncEnumerable.Empty<uint>().MinAsync(x => x, Helper.CANCELLED).Result == 0));
            _MinFailsWhenCancelled(() => Assert.IsTrue(AsyncEnumerable.Empty<ulong>().MinAsync(x => x, Helper.CANCELLED).Result == 0));

            _MinFailsWhenCancelled(() => Assert.IsTrue(AsyncEnumerable.Empty<decimal?>().MinAsync(x => x, Helper.CANCELLED).Result == 0));
            _MinFailsWhenCancelled(() => Assert.IsTrue(AsyncEnumerable.Empty<double?>().MinAsync(x => x, Helper.CANCELLED).Result == 0));
            _MinFailsWhenCancelled(() => Assert.IsTrue(AsyncEnumerable.Empty<float?>().MinAsync(x => x, Helper.CANCELLED).Result == 0));
            _MinFailsWhenCancelled(() => Assert.IsTrue(AsyncEnumerable.Empty<int?>().MinAsync(x => x, Helper.CANCELLED).Result == 0));
            _MinFailsWhenCancelled(() => Assert.IsTrue(AsyncEnumerable.Empty<long?>().MinAsync(x => x, Helper.CANCELLED).Result == 0));
            _MinFailsWhenCancelled(() => Assert.IsTrue(AsyncEnumerable.Empty<uint?>().MinAsync(x => x, Helper.CANCELLED).Result == 0));
            _MinFailsWhenCancelled(() => Assert.IsTrue(AsyncEnumerable.Empty<ulong?>().MinAsync(x => x, Helper.CANCELLED).Result == 0));
        }

        #endregion

        #region Values

        [TestMethod]
        public void MinDecimalValues()
        {
            var xs = AsyncEnumerable.FromValues(new decimal[] { 5, 2, 3, 4 });
            Assert.IsTrue(xs.MinAsync(CancellationToken.None).Result == 2);
            Assert.IsTrue(xs.MinAsync(x => x, CancellationToken.None).Result == 2);
        }
        [TestMethod]
        public void MinDoubleValues()
        {
            var xs = AsyncEnumerable.FromValues(new double[] { 5, 2, 3, 4 });
            Assert.IsTrue(xs.MinAsync(CancellationToken.None).Result == 2);
            Assert.IsTrue(xs.MinAsync(x => x, CancellationToken.None).Result == 2);
        }
        [TestMethod]
        public void MinFloatValues()
        {
            var xs = AsyncEnumerable.FromValues(new float[] { 5, 2, 3, 4 });
            Assert.IsTrue(xs.MinAsync(CancellationToken.None).Result == 2);
            Assert.IsTrue(xs.MinAsync(x => x, CancellationToken.None).Result == 2);
        }
        [TestMethod]
        public void MinIntValues()
        {
            var xs = AsyncEnumerable.FromValues(new int[] { 5, 2, 3, 4 });
            Assert.IsTrue(xs.MinAsync(CancellationToken.None).Result == 2);
            Assert.IsTrue(xs.MinAsync(x => x, CancellationToken.None).Result == 2);
        }
        [TestMethod]
        public void MinLongValues()
        {
            var xs = AsyncEnumerable.FromValues(new long[] { 5, 2, 3, 4 });
            Assert.IsTrue(xs.MinAsync(CancellationToken.None).Result == 2);
            Assert.IsTrue(xs.MinAsync(x => x, CancellationToken.None).Result == 2);
        }
        [TestMethod]
        public void MinUIntValues()
        {
            var xs = AsyncEnumerable.FromValues(new uint[] { 5, 2, 3, 4 });
            Assert.IsTrue(xs.MinAsync(CancellationToken.None).Result == 2);
            Assert.IsTrue(xs.MinAsync(x => x, CancellationToken.None).Result == 2);
        }
        [TestMethod]
        public void MinULongValues()
        {
            var xs = AsyncEnumerable.FromValues(new ulong[] { 5, 2, 3, 4 });
            Assert.IsTrue(xs.MinAsync(CancellationToken.None).Result == 2);
            Assert.IsTrue(xs.MinAsync(x => x, CancellationToken.None).Result == 2);
        }


        [TestMethod]
        public void MinNullableDecimalValues()
        {
            var xs = AsyncEnumerable.FromValues(new decimal?[] { 5, 2, 3, 4 });
            Assert.IsTrue(xs.MinAsync(CancellationToken.None).Result == 2);
            Assert.IsTrue(xs.MinAsync(x => x, CancellationToken.None).Result == 2);
        }
        [TestMethod]
        public void MinNullableDoubleValues()
        {
            var xs = AsyncEnumerable.FromValues(new double?[] { 5, 2, 3, 4 });
            Assert.IsTrue(xs.MinAsync(CancellationToken.None).Result == 2);
            Assert.IsTrue(xs.MinAsync(x => x, CancellationToken.None).Result == 2);
        }
        [TestMethod]
        public void MinNullableFloatValues()
        {
            var xs = AsyncEnumerable.FromValues(new float?[] { 5, 2, 3, 4 });
            Assert.IsTrue(xs.MinAsync(CancellationToken.None).Result == 2);
            Assert.IsTrue(xs.MinAsync(x => x, CancellationToken.None).Result == 2);
        }
        [TestMethod]
        public void MinNullableIntValues()
        {
            var xs = AsyncEnumerable.FromValues(new int?[] { 5, 2, 3, 4 });
            Assert.IsTrue(xs.MinAsync(CancellationToken.None).Result == 2);
            Assert.IsTrue(xs.MinAsync(x => x, CancellationToken.None).Result == 2);
        }
        [TestMethod]
        public void MinNullableLongValues()
        {
            var xs = AsyncEnumerable.FromValues(new long?[] { 5, 2, 3, 4 });
            Assert.IsTrue(xs.MinAsync(CancellationToken.None).Result == 2);
            Assert.IsTrue(xs.MinAsync(x => x, CancellationToken.None).Result == 2);
        }
        [TestMethod]
        public void MinNullableUIntValues()
        {
            var xs = AsyncEnumerable.FromValues(new uint?[] { 5, 2, 3, 4 });
            Assert.IsTrue(xs.MinAsync(CancellationToken.None).Result == 2);
            Assert.IsTrue(xs.MinAsync(x => x, CancellationToken.None).Result == 2);
        }
        [TestMethod]
        public void MinNullableULongValues()
        {
            var xs = AsyncEnumerable.FromValues(new ulong?[] { 5, 2, 3, 4 });
            Assert.IsTrue(xs.MinAsync(CancellationToken.None).Result == 2);
            Assert.IsTrue(xs.MinAsync(x => x, CancellationToken.None).Result == 2);
        }

        #endregion
    }
}
