using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Collections.Async.Tests
{
    [TestClass]
    public class TakeTests
    {
        [TestMethod]
        public void ThrowsWhenSourceIsNull()
        {
            try
            {
                AsyncEnumerable.TakeAsync<int>(null, 5, CancellationToken.None);
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
        public void EmptyTakeNone()
        {
            var xs = AsyncEnumerable.Empty<int>();
            var rs = xs.TakeAsync(0, CancellationToken.None).ToArrayAsync(CancellationToken.None).Result;
            Assert.IsTrue(rs.Length == 0);
        }

        [TestMethod]
        public void EmptyTakeOne()
        {
            var xs = AsyncEnumerable.Empty<int>();
            var rs = xs.TakeAsync(1, CancellationToken.None).ToArrayAsync(CancellationToken.None).Result;
            Assert.IsTrue(rs.Length == 0);
        }

        [TestMethod]
        public void SingleElementTakeOne()
        {
            var xs = AsyncEnumerable.FromValue(42);
            var rs = xs.TakeAsync(1, CancellationToken.None).ToArrayAsync(CancellationToken.None).Result;
            Assert.IsTrue(rs.Length == 1 && rs[0] == 42);
        }

        [TestMethod]
        public void SingleElementTakeNone()
        {
            var xs = AsyncEnumerable.FromValue(42);
            var rs = xs.TakeAsync(0, CancellationToken.None).ToArrayAsync(CancellationToken.None).Result;
            Assert.IsTrue(rs.Length == 0);
        }

        [TestMethod]
        public void SingleElementTakeTwo()
        {
            var xs = AsyncEnumerable.FromValue(42);
            var rs = xs.TakeAsync(2, CancellationToken.None).ToArrayAsync(CancellationToken.None).Result;
            Assert.IsTrue(rs.Length == 1 && rs[0] == 42);
        }

        [TestMethod]
        public void SingleElementTakeNegative()
        {
            var xs = AsyncEnumerable.FromValue(42);
            var rs = xs.TakeAsync(-1, CancellationToken.None).ToArrayAsync(CancellationToken.None).Result;
            Assert.IsTrue(rs.Length == 0);
        }
        
        [TestMethod]
        public void MultipleElementsTakeNone()
        {
            var xs = AsyncEnumerable.FromValues(new[] { 10, 20, 30 });
            var rs = xs.TakeAsync(0, CancellationToken.None).ToArrayAsync(CancellationToken.None).Result;
            Assert.IsTrue(rs.Length == 0);
        }

        [TestMethod]
        public void MultipleElementsTakeOne()
        {
            var xs = AsyncEnumerable.FromValues(new[] { 10, 20, 30 });
            var rs = xs.TakeAsync(1, CancellationToken.None).ToArrayAsync(CancellationToken.None).Result;
            Assert.IsTrue(rs.Length == 1 && rs[0] == 10);
        }

        [TestMethod]
        public void MultipleElementsTakeMultiple()
        {
            var xs = AsyncEnumerable.FromValues(new[] { 10, 20, 30, 40, 50 });
            var rs = xs.TakeAsync(3, CancellationToken.None).ToArrayAsync(CancellationToken.None).Result;
            Assert.IsTrue(rs.Length == 3 && rs[0] == 10 && rs[1] == 20 && rs[2] == 30);
        }

        [TestMethod]
        public void MultipleElementsTakeAll()
        {
            var xs = AsyncEnumerable.FromValues(new[] { 10, 20, 30, 40, 50 });
            var rs = xs.TakeAsync(5, CancellationToken.None).ToArrayAsync(CancellationToken.None).Result;
            Assert.IsTrue(rs.Length == 5 && rs[0] == 10 && rs[1] == 20 && rs[2] == 30 && rs[3] == 40 && rs[4] == 50);
        }

        [TestMethod]
        public void MultipleElementsTakeMoreThanAll()
        {
            var xs = AsyncEnumerable.FromValues(new[] { 10, 20, 30, 40, 50 });
            var rs = xs.TakeAsync(50, CancellationToken.None).ToArrayAsync(CancellationToken.None).Result;
            Assert.IsTrue(rs.Length == 5 && rs[0] == 10 && rs[1] == 20 && rs[2] == 30 && rs[3] == 40 && rs[4] == 50);
        }

        [TestMethod]
        public void MultipleElementsTakeNegative()
        {
            var xs = AsyncEnumerable.FromValues(new[] { 10, 20, 30 });
            var rs = xs.TakeAsync(-2, CancellationToken.None).ToArrayAsync(CancellationToken.None).Result;
            Assert.IsTrue(rs.Length == 0);
        }
    }
}
