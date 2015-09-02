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
                () => AsyncEnumerable.Min((IAsyncEnumerable<decimal>)null, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.Min((IAsyncEnumerable<double>)null, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.Min((IAsyncEnumerable<float>)null, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.Min((IAsyncEnumerable<int>)null, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.Min((IAsyncEnumerable<long>)null, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.Min((IAsyncEnumerable<uint>)null, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.Min((IAsyncEnumerable<ulong>)null, CancellationToken.None).Wait()
                );


            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.Min((IAsyncEnumerable<decimal?>)null, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.Min((IAsyncEnumerable<double?>)null, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.Min((IAsyncEnumerable<float?>)null, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.Min((IAsyncEnumerable<int?>)null, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.Min((IAsyncEnumerable<long?>)null, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.Min((IAsyncEnumerable<uint?>)null, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.Min((IAsyncEnumerable<ulong?>)null, CancellationToken.None).Wait()
                );
        }

        [TestMethod]
        public void ThrowsWhenSourceIsNull2()
        {
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.Min((IAsyncEnumerable<decimal>)null, x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.Min((IAsyncEnumerable<double>)null, x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.Min((IAsyncEnumerable<float>)null, x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.Min((IAsyncEnumerable<int>)null, x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.Min((IAsyncEnumerable<long>)null, x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.Min((IAsyncEnumerable<uint>)null, x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.Min((IAsyncEnumerable<ulong>)null, x => x, CancellationToken.None).Wait()
                );


            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.Min((IAsyncEnumerable<decimal?>)null, x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.Min((IAsyncEnumerable<double?>)null, x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.Min((IAsyncEnumerable<float?>)null, x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.Min((IAsyncEnumerable<int?>)null, x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.Min((IAsyncEnumerable<long?>)null, x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.Min((IAsyncEnumerable<uint?>)null, x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateArgumentNullException(
                () => AsyncEnumerable.Min((IAsyncEnumerable<ulong?>)null, x => x, CancellationToken.None).Wait()
                );
        }

        [TestMethod]
        public void ThrowsWhenSourceIsEmpty1()
        {
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.Min(AsyncEnumerable.Empty<decimal>(), CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.Min(AsyncEnumerable.Empty<double>(), CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.Min(AsyncEnumerable.Empty<float>(), CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.Min(AsyncEnumerable.Empty<int>(), CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.Min(AsyncEnumerable.Empty<long>(), CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.Min(AsyncEnumerable.Empty<uint>(), CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.Min(AsyncEnumerable.Empty<ulong>(), CancellationToken.None).Wait()
                );


            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.Min(AsyncEnumerable.Empty<decimal?>(), CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.Min(AsyncEnumerable.Empty<double?>(), CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.Min(AsyncEnumerable.Empty<float?>(), CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.Min(AsyncEnumerable.Empty<int?>(), CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.Min(AsyncEnumerable.Empty<long?>(), CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.Min(AsyncEnumerable.Empty<uint?>(), CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.Min(AsyncEnumerable.Empty<ulong?>(), CancellationToken.None).Wait()
                );
        }

        [TestMethod]
        public void ThrowsWhenSourceIsEmpty2()
        {
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.Min(AsyncEnumerable.Empty<decimal>(), x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.Min(AsyncEnumerable.Empty<double>(), x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.Min(AsyncEnumerable.Empty<float>(), x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.Min(AsyncEnumerable.Empty<int>(), x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.Min(AsyncEnumerable.Empty<long>(), x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.Min(AsyncEnumerable.Empty<uint>(), x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.Min(AsyncEnumerable.Empty<ulong>(), x => x, CancellationToken.None).Wait()
                );


            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.Min(AsyncEnumerable.Empty<decimal>(), x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.Min(AsyncEnumerable.Empty<double>(), x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.Min(AsyncEnumerable.Empty<float>(), x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.Min(AsyncEnumerable.Empty<int>(), x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.Min(AsyncEnumerable.Empty<long>(), x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.Min(AsyncEnumerable.Empty<uint>(), x => x, CancellationToken.None).Wait()
                );
            TestHelpers.ThrowsAggregateInvalidOperationException(
                () => AsyncEnumerable.Min(AsyncEnumerable.Empty<ulong>(), x => x, CancellationToken.None).Wait()
                );
        }

        [TestMethod]
        public void ThrowsWhenPredicateIsNull()
        {
            TestHelpers.ThrowsAggregateArgumentNullException(() =>
            {
                var xs = AsyncEnumerable.FromValues(new decimal[0]);
                AsyncEnumerable.Min(xs, (Func<decimal, decimal>)null, CancellationToken.None).Wait();
            });
            TestHelpers.ThrowsAggregateArgumentNullException(() =>
            {
                var xs = AsyncEnumerable.FromValues(new double[0]);
                AsyncEnumerable.Min(xs, (Func<double, double>)null, CancellationToken.None).Wait();
            });
            TestHelpers.ThrowsAggregateArgumentNullException(() =>
            {
                var xs = AsyncEnumerable.FromValues(new float[0]);
                AsyncEnumerable.Min(xs, (Func<float, float>)null, CancellationToken.None).Wait();
            });
            TestHelpers.ThrowsAggregateArgumentNullException(() =>
            {
                var xs = AsyncEnumerable.FromValues(new int[0]);
                AsyncEnumerable.Min(xs, (Func<int, int>)null, CancellationToken.None).Wait();
            });
            TestHelpers.ThrowsAggregateArgumentNullException(() =>
            {
                var xs = AsyncEnumerable.FromValues(new long[0]);
                AsyncEnumerable.Min(xs, (Func<long, long>)null, CancellationToken.None).Wait();
            });
            TestHelpers.ThrowsAggregateArgumentNullException(() =>
            {
                var xs = AsyncEnumerable.FromValues(new uint[0]);
                AsyncEnumerable.Min(xs, (Func<uint, uint>)null, CancellationToken.None).Wait();
            });
            TestHelpers.ThrowsAggregateArgumentNullException(() =>
            {
                var xs = AsyncEnumerable.FromValues(new ulong[0]);
                AsyncEnumerable.Min(xs, (Func<ulong, ulong>)null, CancellationToken.None).Wait();
            });


            TestHelpers.ThrowsAggregateArgumentNullException(() =>
            {
                var xs = AsyncEnumerable.FromValues(new decimal?[0]);
                AsyncEnumerable.Min(xs, (Func<decimal?, decimal?>)null, CancellationToken.None).Wait();
            });
            TestHelpers.ThrowsAggregateArgumentNullException(() =>
            {
                var xs = AsyncEnumerable.FromValues(new double?[0]);
                AsyncEnumerable.Min(xs, (Func<double?, double?>)null, CancellationToken.None).Wait();
            });
            TestHelpers.ThrowsAggregateArgumentNullException(() =>
            {
                var xs = AsyncEnumerable.FromValues(new float?[0]);
                AsyncEnumerable.Min(xs, (Func<float?, float?>)null, CancellationToken.None).Wait();
            });
            TestHelpers.ThrowsAggregateArgumentNullException(() =>
            {
                var xs = AsyncEnumerable.FromValues(new int?[0]);
                AsyncEnumerable.Min(xs, (Func<int?, int?>)null, CancellationToken.None).Wait();
            });
            TestHelpers.ThrowsAggregateArgumentNullException(() =>
            {
                var xs = AsyncEnumerable.FromValues(new long?[0]);
                AsyncEnumerable.Min(xs, (Func<long?, long?>)null, CancellationToken.None).Wait();
            });
            TestHelpers.ThrowsAggregateArgumentNullException(() =>
            {
                var xs = AsyncEnumerable.FromValues(new uint?[0]);
                AsyncEnumerable.Min(xs, (Func<uint?, uint?>)null, CancellationToken.None).Wait();
            });
            TestHelpers.ThrowsAggregateArgumentNullException(() =>
            {
                var xs = AsyncEnumerable.FromValues(new ulong?[0]);
                AsyncEnumerable.Min(xs, (Func<ulong?, ulong?>)null, CancellationToken.None).Wait();
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
            }
        }

        [TestMethod]
        public void MinFailsWhenCancelled()
        {
            var ct = new CancellationToken(true);
            _MinFailsWhenCancelled(() => Assert.IsTrue(AsyncEnumerable.Empty<decimal>().Min(x => x, ct).Result == 0));
            _MinFailsWhenCancelled(() => Assert.IsTrue(AsyncEnumerable.Empty<double>().Min(x => x, ct).Result == 0));
            _MinFailsWhenCancelled(() => Assert.IsTrue(AsyncEnumerable.Empty<float>().Min(x => x, ct).Result == 0));
            _MinFailsWhenCancelled(() => Assert.IsTrue(AsyncEnumerable.Empty<int>().Min(x => x, ct).Result == 0));
            _MinFailsWhenCancelled(() => Assert.IsTrue(AsyncEnumerable.Empty<long>().Min(x => x, ct).Result == 0));
            _MinFailsWhenCancelled(() => Assert.IsTrue(AsyncEnumerable.Empty<uint>().Min(x => x, ct).Result == 0));
            _MinFailsWhenCancelled(() => Assert.IsTrue(AsyncEnumerable.Empty<ulong>().Min(x => x, ct).Result == 0));

            _MinFailsWhenCancelled(() => Assert.IsTrue(AsyncEnumerable.Empty<decimal?>().Min(x => x, ct).Result == 0));
            _MinFailsWhenCancelled(() => Assert.IsTrue(AsyncEnumerable.Empty<double?>().Min(x => x, ct).Result == 0));
            _MinFailsWhenCancelled(() => Assert.IsTrue(AsyncEnumerable.Empty<float?>().Min(x => x, ct).Result == 0));
            _MinFailsWhenCancelled(() => Assert.IsTrue(AsyncEnumerable.Empty<int?>().Min(x => x, ct).Result == 0));
            _MinFailsWhenCancelled(() => Assert.IsTrue(AsyncEnumerable.Empty<long?>().Min(x => x, ct).Result == 0));
            _MinFailsWhenCancelled(() => Assert.IsTrue(AsyncEnumerable.Empty<uint?>().Min(x => x, ct).Result == 0));
            _MinFailsWhenCancelled(() => Assert.IsTrue(AsyncEnumerable.Empty<ulong?>().Min(x => x, ct).Result == 0));
        }

        #endregion

        #region Values

        [TestMethod]
        public void MinDecimalValues()
        {
            var xs = AsyncEnumerable.FromValues(new decimal[] { 5, 2, 3, 4 });
            Assert.IsTrue(xs.Min(CancellationToken.None).Result == 2);
            Assert.IsTrue(xs.Min(x => x, CancellationToken.None).Result == 2);
        }
        [TestMethod]
        public void MinDoubleValues()
        {
            var xs = AsyncEnumerable.FromValues(new double[] { 5, 2, 3, 4 });
            Assert.IsTrue(xs.Min(CancellationToken.None).Result == 2);
            Assert.IsTrue(xs.Min(x => x, CancellationToken.None).Result == 2);
        }
        [TestMethod]
        public void MinFloatValues()
        {
            var xs = AsyncEnumerable.FromValues(new float[] { 5, 2, 3, 4 });
            Assert.IsTrue(xs.Min(CancellationToken.None).Result == 2);
            Assert.IsTrue(xs.Min(x => x, CancellationToken.None).Result == 2);
        }
        [TestMethod]
        public void MinIntValues()
        {
            var xs = AsyncEnumerable.FromValues(new int[] { 5, 2, 3, 4 });
            Assert.IsTrue(xs.Min(CancellationToken.None).Result == 2);
            Assert.IsTrue(xs.Min(x => x, CancellationToken.None).Result == 2);
        }
        [TestMethod]
        public void MinLongValues()
        {
            var xs = AsyncEnumerable.FromValues(new long[] { 5, 2, 3, 4 });
            Assert.IsTrue(xs.Min(CancellationToken.None).Result == 2);
            Assert.IsTrue(xs.Min(x => x, CancellationToken.None).Result == 2);
        }
        [TestMethod]
        public void MinUIntValues()
        {
            var xs = AsyncEnumerable.FromValues(new uint[] { 5, 2, 3, 4 });
            Assert.IsTrue(xs.Min(CancellationToken.None).Result == 2);
            Assert.IsTrue(xs.Min(x => x, CancellationToken.None).Result == 2);
        }
        [TestMethod]
        public void MinULongValues()
        {
            var xs = AsyncEnumerable.FromValues(new ulong[] { 5, 2, 3, 4 });
            Assert.IsTrue(xs.Min(CancellationToken.None).Result == 2);
            Assert.IsTrue(xs.Min(x => x, CancellationToken.None).Result == 2);
        }


        [TestMethod]
        public void MinNullableDecimalValues()
        {
            var xs = AsyncEnumerable.FromValues(new decimal?[] { 5, 2, 3, 4 });
            Assert.IsTrue(xs.Min(CancellationToken.None).Result == 2);
            Assert.IsTrue(xs.Min(x => x, CancellationToken.None).Result == 2);
        }
        [TestMethod]
        public void MinNullableDoubleValues()
        {
            var xs = AsyncEnumerable.FromValues(new double?[] { 5, 2, 3, 4 });
            Assert.IsTrue(xs.Min(CancellationToken.None).Result == 2);
            Assert.IsTrue(xs.Min(x => x, CancellationToken.None).Result == 2);
        }
        [TestMethod]
        public void MinNullableFloatValues()
        {
            var xs = AsyncEnumerable.FromValues(new float?[] { 5, 2, 3, 4 });
            Assert.IsTrue(xs.Min(CancellationToken.None).Result == 2);
            Assert.IsTrue(xs.Min(x => x, CancellationToken.None).Result == 2);
        }
        [TestMethod]
        public void MinNullableIntValues()
        {
            var xs = AsyncEnumerable.FromValues(new int?[] { 5, 2, 3, 4 });
            Assert.IsTrue(xs.Min(CancellationToken.None).Result == 2);
            Assert.IsTrue(xs.Min(x => x, CancellationToken.None).Result == 2);
        }
        [TestMethod]
        public void MinNullableLongValues()
        {
            var xs = AsyncEnumerable.FromValues(new long?[] { 5, 2, 3, 4 });
            Assert.IsTrue(xs.Min(CancellationToken.None).Result == 2);
            Assert.IsTrue(xs.Min(x => x, CancellationToken.None).Result == 2);
        }
        [TestMethod]
        public void MinNullableUIntValues()
        {
            var xs = AsyncEnumerable.FromValues(new uint?[] { 5, 2, 3, 4 });
            Assert.IsTrue(xs.Min(CancellationToken.None).Result == 2);
            Assert.IsTrue(xs.Min(x => x, CancellationToken.None).Result == 2);
        }
        [TestMethod]
        public void MinNullableULongValues()
        {
            var xs = AsyncEnumerable.FromValues(new ulong?[] { 5, 2, 3, 4 });
            Assert.IsTrue(xs.Min(CancellationToken.None).Result == 2);
            Assert.IsTrue(xs.Min(x => x, CancellationToken.None).Result == 2);
        }

        #endregion
    }
}
