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
        public void ThrowsWhenDecimalSourceIsNull()
        {
            try
            {
                AsyncEnumerable.SumAsync<decimal>(null, x => x, CancellationToken.None).Wait();
                Assert.Fail();
            }
            catch (Exception e)
            {
                var a = e as AggregateException;
                if (a == null || a.InnerExceptions.Count != 1 || !(a.InnerException is ArgumentNullException))
                    Assert.Fail();
            }
        }
        [TestMethod]
        public void ThrowsWhenDecimalPredicateIsNull()
        {
            try
            {
                var xs = AsyncEnumerable.FromValues(new decimal[] { 10, 20, 30, 40, 50 });
                AsyncEnumerable.SumAsync(xs, (Func<decimal, decimal>)null, CancellationToken.None).Wait();
                Assert.Fail();
            }
            catch (Exception e)
            {
                var a = e as AggregateException;
                if (a == null || a.InnerExceptions.Count != 1 || !(a.InnerException is ArgumentNullException))
                {
                    Assert.Fail();
                }
            }
        }
        
        [TestMethod]
        public void ThrowsWhenDoubleSourceIsNull()
        {
            try
            {
                AsyncEnumerable.SumAsync<double>(null, x => x, CancellationToken.None).Wait();
                Assert.Fail();
            }
            catch (Exception e)
            {
                var a = e as AggregateException;
                if (a == null || a.InnerExceptions.Count != 1 || !(a.InnerException is ArgumentNullException))
                {
                    Assert.Fail();
                }
            }
        }
        [TestMethod]
        public void ThrowsWhenDoublePredicateIsNull()
        {
            try
            {
                var xs = AsyncEnumerable.FromValues(new double[] { 10, 20, 30, 40, 50 });
                AsyncEnumerable.SumAsync(xs, (Func<double, double>)null, CancellationToken.None).Wait();
                Assert.Fail();
            }
            catch (Exception e)
            {
                var a = e as AggregateException;
                if (a == null || a.InnerExceptions.Count != 1 || !(a.InnerException is ArgumentNullException))
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod]
        public void ThrowsWhenFloatSourceIsNull()
        {
            try
            {
                AsyncEnumerable.SumAsync<float>(null, x => x, CancellationToken.None).Wait();
                Assert.Fail();
            }
            catch (Exception e)
            {
                var a = e as AggregateException;
                if (a == null || a.InnerExceptions.Count != 1 || !(a.InnerException is ArgumentNullException))
                {
                    Assert.Fail();
                }
            }
        }
        [TestMethod]
        public void ThrowsWhenFloatPredicateIsNull()
        {
            try
            {
                var xs = AsyncEnumerable.FromValues(new float[] { 10, 20, 30, 40, 50 });
                AsyncEnumerable.SumAsync(xs, (Func<float, float>)null, CancellationToken.None).Wait();
                Assert.Fail();
            }
            catch (Exception e)
            {
                var a = e as AggregateException;
                if (a == null || a.InnerExceptions.Count != 1 || !(a.InnerException is ArgumentNullException))
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod]
        public void ThrowsWhenIntSourceIsNull()
        {
            try
            {
                AsyncEnumerable.SumAsync<int>(null, x => x, CancellationToken.None).Wait();
                Assert.Fail();
            }
            catch (Exception e)
            {
                var a = e as AggregateException;
                if (a == null || a.InnerExceptions.Count != 1 || !(a.InnerException is ArgumentNullException))
                {
                    Assert.Fail();
                }
            }
        }
        [TestMethod]
        public void ThrowsWhenIntPredicateIsNull()
        {
            try
            {
                var xs = AsyncEnumerable.FromValues(new int[] { 10, 20, 30, 40, 50 });
                AsyncEnumerable.SumAsync(xs, (Func<int, int>)null, CancellationToken.None).Wait();
                Assert.Fail();
            }
            catch (Exception e)
            {
                var a = e as AggregateException;
                if (a == null || a.InnerExceptions.Count != 1 || !(a.InnerException is ArgumentNullException))
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod]
        public void ThrowsWhenLongSourceIsNull()
        {
            try
            {
                AsyncEnumerable.SumAsync<long>(null, x => x, CancellationToken.None).Wait();
                Assert.Fail();
            }
            catch (Exception e)
            {
                var a = e as AggregateException;
                if (a == null || a.InnerExceptions.Count != 1 || !(a.InnerException is ArgumentNullException))
                {
                    Assert.Fail();
                }
            }
        }
        [TestMethod]
        public void ThrowsWhenLongPredicateIsNull()
        {
            try
            {
                var xs = AsyncEnumerable.FromValues(new long[] { 10, 20, 30, 40, 50 });
                AsyncEnumerable.SumAsync(xs, (Func<long, long>)null, CancellationToken.None).Wait();
                Assert.Fail();
            }
            catch (Exception e)
            {
                var a = e as AggregateException;
                if (a == null || a.InnerExceptions.Count != 1 || !(a.InnerException is ArgumentNullException))
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod]
        public void ThrowsWhenUIntSourceIsNull()
        {
            try
            {
                AsyncEnumerable.SumAsync<uint>(null, x => x, CancellationToken.None).Wait();
                Assert.Fail();
            }
            catch (Exception e)
            {
                var a = e as AggregateException;
                if (a == null || a.InnerExceptions.Count != 1 || !(a.InnerException is ArgumentNullException))
                {
                    Assert.Fail();
                }
            }
        }
        [TestMethod]
        public void ThrowsWhenUIntPredicateIsNull()
        {
            try
            {
                var xs = AsyncEnumerable.FromValues(new uint[] { 10, 20, 30, 40, 50 });
                AsyncEnumerable.SumAsync(xs, (Func<uint, uint>)null, CancellationToken.None).Wait();
                Assert.Fail();
            }
            catch (Exception e)
            {
                var a = e as AggregateException;
                if (a == null || a.InnerExceptions.Count != 1 || !(a.InnerException is ArgumentNullException))
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod]
        public void ThrowsWhenULongSourceIsNull()
        {
            try
            {
                AsyncEnumerable.SumAsync<ulong>(null, x => x, CancellationToken.None).Wait();
                Assert.Fail();
            }
            catch (Exception e)
            {
                var a = e as AggregateException;
                if (a == null || a.InnerExceptions.Count != 1 || !(a.InnerException is ArgumentNullException))
                {
                    Assert.Fail();
                }
            }
        }
        [TestMethod]
        public void ThrowsWhenULongPredicateIsNull()
        {
            try
            {
                var xs = AsyncEnumerable.FromValues(new ulong[] { 10, 20, 30, 40, 50 });
                AsyncEnumerable.SumAsync(xs, (Func<ulong, ulong>)null, CancellationToken.None).Wait();
                Assert.Fail();
            }
            catch (Exception e)
            {
                var a = e as AggregateException;
                if (a == null || a.InnerExceptions.Count != 1 || !(a.InnerException is ArgumentNullException))
                {
                    Assert.Fail();
                }
            }
        }

        #endregion

        #region Empty

        [TestMethod]
        public void SumDecimalEmpty()
        {
            Assert.IsTrue(AsyncEnumerable.Empty<decimal>().SumAsync(x => x, CancellationToken.None).Result == 0);
        }
        [TestMethod]
        public void SumDoubleEmpty()
        {
            Assert.IsTrue(AsyncEnumerable.Empty<double>().SumAsync(x => x, CancellationToken.None).Result == 0);
        }
        [TestMethod]
        public void SumFloatEmpty()
        {
            Assert.IsTrue(AsyncEnumerable.Empty<float>().SumAsync(x => x, CancellationToken.None).Result == 0);
        }
        [TestMethod]
        public void SumIntEmpty()
        {
            Assert.IsTrue(AsyncEnumerable.Empty<int>().SumAsync(x => x, CancellationToken.None).Result == 0);
        }
        [TestMethod]
        public void SumLongEmpty()
        {
            Assert.IsTrue(AsyncEnumerable.Empty<long>().SumAsync(x => x, CancellationToken.None).Result == 0);
        }
        [TestMethod]
        public void SumUIntEmpty()
        {
            Assert.IsTrue(AsyncEnumerable.Empty<uint>().SumAsync(x => x, CancellationToken.None).Result == 0);
        }
        [TestMethod]
        public void SumULongEmpty()
        {
            Assert.IsTrue(AsyncEnumerable.Empty<ulong>().SumAsync(x => x, CancellationToken.None).Result == 0);
        }

        #endregion

        #region Cancelled

        [TestMethod]
        public void SumDecimalFailsWhenCancelled()
        {
            try
            {
                Assert.IsTrue(AsyncEnumerable.Empty<decimal>().SumAsync(x => x, Helper.CANCELLED).Result == 0);
            }
            catch
            {
                Assert.IsTrue(Helper.CANCELLED.IsCancellationRequested);
            }
        }
        [TestMethod]
        public void SumDoubleFailsWhenCancelled()
        {
            try
            {
                Assert.IsTrue(AsyncEnumerable.Empty<double>().SumAsync(x => x, Helper.CANCELLED).Result == 0);
            }
            catch
            {
                Assert.IsTrue(Helper.CANCELLED.IsCancellationRequested);
            }
        }
        [TestMethod]
        public void SumFloatFailsWhenCancelled()
        {
            try
            {
                Assert.IsTrue(AsyncEnumerable.Empty<float>().SumAsync(x => x, Helper.CANCELLED).Result == 0);
            }
            catch
            {
                Assert.IsTrue(Helper.CANCELLED.IsCancellationRequested);
            }
        }
        [TestMethod]
        public void SumIntFailsWhenCancelled()
        {
            try
            {
                Assert.IsTrue(AsyncEnumerable.Empty<int>().SumAsync(x => x, Helper.CANCELLED).Result == 0);
            }
            catch
            {
                Assert.IsTrue(Helper.CANCELLED.IsCancellationRequested);
            }
        }
        [TestMethod]
        public void SumLongFailsWhenCancelled()
        {
            try
            {
                Assert.IsTrue(AsyncEnumerable.Empty<long>().SumAsync(x => x, Helper.CANCELLED).Result == 0);
            }
            catch
            {
                Assert.IsTrue(Helper.CANCELLED.IsCancellationRequested);
            }
        }
        [TestMethod]
        public void SumUIntFailsWhenCancelled()
        {
            try
            {
                Assert.IsTrue(AsyncEnumerable.Empty<uint>().SumAsync(x => x, Helper.CANCELLED).Result == 0);
            }
            catch
            {
                Assert.IsTrue(Helper.CANCELLED.IsCancellationRequested);
            }
        }
        [TestMethod]
        public void SumULongFailsWhenCancelled()
        {
            try
            {
                Assert.IsTrue(AsyncEnumerable.Empty<ulong>().SumAsync(x => x, Helper.CANCELLED).Result == 0);
            }
            catch
            {
                Assert.IsTrue(Helper.CANCELLED.IsCancellationRequested);
            }
        }

        #endregion

        #region Values

        [TestMethod]
        public void SumDecimalValues()
        {
            var xs = AsyncEnumerable.FromValues(new decimal[] { 1, 2, 3, 4 });
            Assert.IsTrue(xs.SumAsync(x => x, CancellationToken.None).Result == 10);
        }
        [TestMethod]
        public void SumDoubleValues()
        {
            var xs = AsyncEnumerable.FromValues(new double[] { 1, 2, 3, 4 });
            Assert.IsTrue(xs.SumAsync(x => x, CancellationToken.None).Result == 10);
        }
        [TestMethod]
        public void SumFloatValues()
        {
            var xs = AsyncEnumerable.FromValues(new float[] { 1, 2, 3, 4 });
            Assert.IsTrue(xs.SumAsync(x => x, CancellationToken.None).Result == 10);
        }
        [TestMethod]
        public void SumIntValues()
        {
            var xs = AsyncEnumerable.FromValues(new int[] { 1, 2, 3, 4 });
            Assert.IsTrue(xs.SumAsync(x => x, CancellationToken.None).Result == 10);
        }
        [TestMethod]
        public void SumLongValues()
        {
            var xs = AsyncEnumerable.FromValues(new long[] { 1, 2, 3, 4 });
            Assert.IsTrue(xs.SumAsync(x => x, CancellationToken.None).Result == 10);
        }
        [TestMethod]
        public void SumUIntValues()
        {
            var xs = AsyncEnumerable.FromValues(new uint[] { 1, 2, 3, 4 });
            Assert.IsTrue(xs.SumAsync(x => x, CancellationToken.None).Result == 10);
        }
        [TestMethod]
        public void SumULongValues()
        {
            var xs = AsyncEnumerable.FromValues(new ulong[] { 1, 2, 3, 4 });
            Assert.IsTrue(xs.SumAsync(x => x, CancellationToken.None).Result == 10);
        }

        #endregion
    }
}
