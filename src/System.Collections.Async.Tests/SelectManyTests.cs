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
        public void SelectMany_ThrowsIfSourceIsNull()
        {
            try
            {
                AsyncEnumerable.SelectMany<int, int>(null, x => new[] { x }, CancellationToken.None);
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
        public void SelectMany_ThrowsIfSelectorIsNull()
        {
            try
            {
                var xs = AsyncEnumerable.Empty<int>();
                AsyncEnumerable.SelectMany<int, int>(xs, null, CancellationToken.None);
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
        public void SelectMany_Cancelled()
        {
            TestHelpers.ThrowsAggregateTaskCanceledException(() =>
                AsyncEnumerable.Empty<int[]>().SelectMany(x => x, TestHelpers.Cancelled).Wait()
                );
        }
        [TestMethod]
        public void SelectMany_Faulted()
        {
            TestHelpers.ThrowsAggregateTestException(() =>
                TestHelpers.FaultedIntSequence.SelectMany(x => new[] { x }, CancellationToken.None).Wait()
                );
        }

        [TestMethod]
        public void SelectMany_EmptyCase()
        {
            var xs = AsyncEnumerable.Empty<int>();
            var rs = xs.SelectMany(x => new[] { x }).ToArray().Result;
            Assert.IsTrue(rs.Length == 0);
        }
        [TestMethod]
        public void SelectMany_SingleElement()
        {
            var xs = AsyncEnumerable.FromValue(42);
            var rs = xs.SelectMany(x => new[] { x, x * 2 }).ToArray().Result;
            Assert.IsTrue(rs.Length == 2 && rs[0] == 42 && rs[1] == 84);
        }
        [TestMethod]
        public void SelectMany_MultipleElements()
        {
            var xs = AsyncEnumerable.FromValues(new[] { 0, 1, 2, 3 });
            var rs = xs.SelectMany(x => Enumerable.Range(x, x)).ToArray().Result;
            Assert.IsTrue(rs.Length == 6 && rs[0] == 1 && rs[1] == 2 && rs[2] == 3 && rs[3] == 3 && rs[4] == 4 && rs[5] == 5);
        }
        [TestMethod]
        public void SelectMany_TSourceIsDifferentFromTResult()
        {
            var xs = AsyncEnumerable.FromValues(new[] { 10, 20 });
            var rs = xs.SelectMany(x => new[] { "x", x.ToString() }).ToArray().Result;
            Assert.IsTrue(rs.Length == 4 && rs[0] == "x" && rs[1] == "10" && rs[2] == "x" && rs[3] == "20");
        }
    }
}
