using System;
using System.Linq;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Collections.Async.Tests
{
    [TestClass]
    public class SelectManyTests
    {
        [TestMethod]
        public void ThrowsIfSourceIsNull()
        {
            try
            {
                AsyncEnumerable.SelectManyAsync<int, int>(null, x => new[] { x }, CancellationToken.None);
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
        public void ThrowsIfSelectorIsNull()
        {
            try
            {
                var xs = AsyncEnumerable.Empty<int>();
                AsyncEnumerable.SelectManyAsync<int, int>(xs, null, CancellationToken.None);
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
            var xs = AsyncEnumerable.Empty<int>();
            var rs = xs.SelectManyAsync(x => new[] { x }, CancellationToken.None).ToArrayAsync(CancellationToken.None).Result;
            Assert.IsTrue(rs.Length == 0);
        }

        [TestMethod]
        public void SingleElement()
        {
            var xs = AsyncEnumerable.FromValue(42);
            var rs = xs.SelectManyAsync(x => new[] { x, x * 2 }, CancellationToken.None).ToArrayAsync(CancellationToken.None).Result;
            Assert.IsTrue(rs.Length == 2 && rs[0] == 42 && rs[1] == 84);
        }

        [TestMethod]
        public void MultipleElements()
        {
            var xs = AsyncEnumerable.FromValues(new[] { 0, 1, 2, 3 });
            var rs = xs.SelectManyAsync(x => Enumerable.Range(x, x), CancellationToken.None).ToArrayAsync(CancellationToken.None).Result;
            Assert.IsTrue(rs.Length == 6 && rs[0] == 1 && rs[1] == 2 && rs[2] == 3 && rs[3] == 3 && rs[4] == 4 && rs[5] == 5);
        }

        [TestMethod]
        public void TSourceIsDifferentFromTResult()
        {
            var xs = AsyncEnumerable.FromValues(new[] { 10, 20 });
            var rs = xs.SelectManyAsync(x => new [] { "x", x.ToString() }, CancellationToken.None).ToArrayAsync(CancellationToken.None).Result;
            Assert.IsTrue(rs.Length == 4 && rs[0] == "x" && rs[1] == "10" && rs[2] == "x" && rs[3] == "20");
        }
    }
}
