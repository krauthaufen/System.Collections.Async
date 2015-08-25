using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Collections.Async.Tests
{
    [TestClass]
    public class DistinctTests
    {
        [TestMethod]
        public void ThrowsWhenSourceIsNull()
        {
            try
            {
                AsyncEnumerable.DistinctAsync<int>(null, CancellationToken.None);
                Assert.Fail();
            }
            catch (ArgumentNullException)
            {
            }
            catch
            {
                Assert.Fail();
            }
        }
       
        [TestMethod]
        public void EmptyCase()
        {
            var xs = AsyncEnumerable.FromValues(new int[] { });
            var rs = xs.DistinctAsync(CancellationToken.None).ToArrayAsync(CancellationToken.None).Result;
            Assert.IsTrue(rs.Length == 0);
        }

        [TestMethod]
        public void SingleCase()
        {
            var xs = AsyncEnumerable.FromValues(new int[] { 42 });
            var rs = xs.DistinctAsync(CancellationToken.None).ToArrayAsync(CancellationToken.None).Result;
            Assert.IsTrue(rs.Length == 1 && rs[0] == 42);
        }

        [TestMethod]
        public void SingleDuplicateCase()
        {
            var xs = AsyncEnumerable.FromValues(new int[] { 42, 42, 42 });
            var rs = xs.DistinctAsync(CancellationToken.None).ToArrayAsync(CancellationToken.None).Result;
            Assert.IsTrue(rs.Length == 1 && rs[0] == 42);
        }

        [TestMethod]
        public void MultipleDuplicateCase()
        {
            var xs = AsyncEnumerable.FromValues(new int[] { 1, 2, 1, 3, 2, 4, 3, 5 });
            var rs = xs.DistinctAsync(CancellationToken.None).ToArrayAsync(CancellationToken.None).Result;
            Assert.IsTrue(rs.Length == 5 && rs[0] == 1 && rs[1] == 2 && rs[2] == 3 && rs[3] == 4 && rs[4] == 5);
        }

        [TestMethod]
        public void AllDistinctCase()
        {
            var xs = AsyncEnumerable.FromValues(new int[] { 1, 2, 3, 4 });
            var rs = xs.DistinctAsync(CancellationToken.None).ToArrayAsync(CancellationToken.None).Result;
            Assert.IsTrue(rs.Length == 4 && rs[0] == 1 && rs[1] == 2 && rs[2] == 3 && rs[3] == 4);
        }
    }
}
