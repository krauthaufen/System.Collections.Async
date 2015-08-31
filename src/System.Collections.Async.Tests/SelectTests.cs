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
            TestHelpers.ThrowsArgumentNullException(() =>
                AsyncEnumerable.Select<int, int>(null, x => x)
                );
        }
        
        [TestMethod]
        public void ThrowsOnSelectorIsNull()
        {
            TestHelpers.ThrowsArgumentNullException(() =>
                AsyncEnumerable.Select<int, int>(AsyncEnumerable.Empty<int>(), null)
                );
        }

        [TestMethod]
        public void ReturnsCanceledEnumerableIfCtIsCancelledOnConstruction()
        {
            var xs = AsyncEnumerable.Empty<int>();
            var e = xs.Select(x => x, new CancellationToken(true)).GetEnumerator(CancellationToken.None).Result;
            Assert.IsTrue(e.Status == MoveNextStatus.Canceled, $"{e.Status} == {MoveNextStatus.Canceled}");
        }

        [TestMethod]
        public void ReturnsCanceledEnumerableFromCanceledEnumerable()
        {
            var xs = AsyncEnumerable.Canceled<int>();
            var e = xs.Select(x => x).GetEnumerator(CancellationToken.None).Result;
            Assert.IsTrue(e.Status == MoveNextStatus.Canceled, $"{e.Status} == {MoveNextStatus.Canceled}");
        }

        [TestMethod]
        public void ReturnsFaultedEnumerableFromFaultedEnumerable()
        {
            var xs = AsyncEnumerable.Faulted<int>(new Exception("Test"));
            var e = xs.Select(x => x).GetEnumerator(CancellationToken.None).Result;
            Assert.IsTrue(e.Status == MoveNextStatus.Faulted, $"{e.Status} == {MoveNextStatus.Faulted}");
        }

        [TestMethod]
        public void EmptyCase()
        {
            var xs = AsyncEnumerable.Empty<int>();
            var rs = xs.Select(x => x).ToArray().Result;
            Assert.IsTrue(rs.Length == 0);
        }

        [TestMethod]
        public void SingleElement()
        {
            var xs = AsyncEnumerable.FromValue(42);
            var rs = xs.Select(x => x * 2).ToArray().Result;
            Assert.IsTrue(rs.Length == 1 && rs[0] == 84);
        }

        [TestMethod]
        public void MultipleElements()
        {
            var xs = AsyncEnumerable.FromValues(new[] { 10, 20, 30 });
            var rs = xs.Select(x => x / 2).ToArray().Result;
            Assert.IsTrue(rs.Length == 3 && rs[0] == 5 && rs[1] == 10 && rs[2] == 15);
        }

        [TestMethod]
        public void TSourceIsDifferentFromTResult()
        {
            var xs = AsyncEnumerable.FromValues(new[] { 10, 20, 30 });
            var rs = xs.Select(x => "x" + x).ToArray().Result;
            Assert.IsTrue(rs.Length == 3 && rs[0] == "x10" && rs[1] == "x20" && rs[2] == "x30");
        }
    }
}
