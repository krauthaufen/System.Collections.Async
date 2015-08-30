using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Collections.Async.Tests
{
    [TestClass]
    public class SelectTests
    {
        [TestMethod]
        public void ThrowsWhenSourceIsNull()
        {
            try
            {
                AsyncEnumerable.Select<int, int>(null, x => x, CancellationToken.None);
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
        public void ThrowsOnSelectorIsNull()
        {
            try
            {
                var xs = AsyncEnumerable.Empty<int>();
                AsyncEnumerable.Select<int, int>(xs, null, CancellationToken.None);
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
            var rs = xs.Select(x => x, CancellationToken.None).ToArray(CancellationToken.None).Result;
            Assert.IsTrue(rs.Length == 0);
        }

        [TestMethod]
        public void SingleElement()
        {
            var xs = AsyncEnumerable.FromValue(42);
            var rs = xs.Select(x => x * 2, CancellationToken.None).ToArray(CancellationToken.None).Result;
            Assert.IsTrue(rs.Length == 1 && rs[0] == 84);
        }

        [TestMethod]
        public void MultipleElements()
        {
            var xs = AsyncEnumerable.FromValues(new[] { 10, 20, 30 });
            var rs = xs.Select(x => x / 2, CancellationToken.None).ToArray(CancellationToken.None).Result;
            Assert.IsTrue(rs.Length == 3 && rs[0] == 5 && rs[1] == 10 && rs[2] == 15);
        }

        [TestMethod]
        public void TSourceIsDifferentFromTResult()
        {
            var xs = AsyncEnumerable.FromValues(new[] { 10, 20, 30 });
            var rs = xs.Select(x => "x" + x, CancellationToken.None).ToArray(CancellationToken.None).Result;
            Assert.IsTrue(rs.Length == 3 && rs[0] == "x10" && rs[1] == "x20" && rs[2] == "x30");
        }
    }
}
