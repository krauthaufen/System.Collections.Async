using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Collections.Async.Tests
{
    [TestClass]
    public class RangeTests
    {
        [TestMethod]
        public void ThrowsIfCountIsNegative()
        {
            try
            {
                AsyncEnumerable.RangeAsync(0, -1, CancellationToken.None);
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException)
            {
            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void ThrowsIfAnyElementWouldExceedIntMaxValue()
        {
            try
            {
                AsyncEnumerable.RangeAsync(int.MaxValue, 2, CancellationToken.None);
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException)
            {
            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void NearMaxValueTest1()
        {
            var xs = AsyncEnumerable.RangeAsync(int.MaxValue, 0, CancellationToken.None);
            Assert.IsTrue(!xs.AnyAsync(CancellationToken.None).Result);
        }

        [TestMethod]
        public void NearMaxValueTest2()
        {
            var xs = AsyncEnumerable.RangeAsync(int.MaxValue, 1, CancellationToken.None).ToArrayAsync(CancellationToken.None).Result;
            Assert.IsTrue(xs.Length == 1 && xs[0] == int.MaxValue);
        }

        [TestMethod]
        public void RangeTest1()
        {
            var xs = AsyncEnumerable.RangeAsync(10, 3, CancellationToken.None).ToArrayAsync(CancellationToken.None).Result;
            Assert.IsTrue(xs.Length == 3 && xs[0] == 10 && xs[1] == 11 && xs[2] == 12);
        }

        [TestMethod]
        public void RangeTest2()
        {
            var xs = AsyncEnumerable.RangeAsync(10, 1000, CancellationToken.None);
            Assert.IsTrue(xs.CountAsync(CancellationToken.None).Result == 1000);
        }
    }
}
