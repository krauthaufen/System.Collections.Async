using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Collections.Async.Tests
{
    [TestClass]
    public class SkipWhileTests
    {
        [TestMethod]
        public void ThrowsWhenSourceIsNull()
        {
            try
            {
                AsyncEnumerable.SkipWhileAsync<int>(null, x => true, CancellationToken.None);
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
        public void EmptySkipNone()
        {
            var xs = AsyncEnumerable.Empty<int>();
            var rs = xs.SkipWhileAsync(x => false, CancellationToken.None).ToArrayAsync(CancellationToken.None).Result;
            Assert.IsTrue(rs.Length == 0);
        }

        [TestMethod]
        public void EmptySkipAll()
        {
            var xs = AsyncEnumerable.Empty<int>();
            var rs = xs.SkipWhileAsync(x => true, CancellationToken.None).ToArrayAsync(CancellationToken.None).Result;
            Assert.IsTrue(rs.Length == 0);
        }

        [TestMethod]
        public void SingleElementSkipAll()
        {
            var xs = AsyncEnumerable.FromValue(42);
            var rs = xs.SkipWhileAsync(x => true, CancellationToken.None).ToArrayAsync(CancellationToken.None).Result;
            Assert.IsTrue(rs.Length == 0);
        }

        [TestMethod]
        public void SingleElementSkipNone()
        {
            var xs = AsyncEnumerable.FromValue(42);
            var rs = xs.SkipWhileAsync(x => false, CancellationToken.None).ToArrayAsync(CancellationToken.None).Result;
            Assert.IsTrue(rs.Length == 1 && rs[0] == 42);
        }
        
        [TestMethod]
        public void MultipleElementsSkipNone()
        {
            var xs = AsyncEnumerable.FromValues(new[] { 10, 20, 30 });
            var rs = xs.SkipWhileAsync(x => false, CancellationToken.None).ToArrayAsync(CancellationToken.None).Result;
            Assert.IsTrue(rs.Length == 3 && rs[0] == 10 && rs[1] == 20 && rs[2] == 30);
        }

        [TestMethod]
        public void MultipleElementsSkipOne()
        {
            var xs = AsyncEnumerable.FromValues(new[] { 10, 20, 30 });
            var rs = xs.SkipWhileAsync(x => x != 20, CancellationToken.None).ToArrayAsync(CancellationToken.None).Result;
            Assert.IsTrue(rs.Length == 2 && rs[0] == 20 && rs[1] == 30);
        }

        [TestMethod]
        public void MultipleElementsSkipMultiple()
        {
            var xs = AsyncEnumerable.FromValues(new[] { 10, 20, 33, 44, 50 });
            var rs = xs.SkipWhileAsync(x => x % 10 == 0, CancellationToken.None).ToArrayAsync(CancellationToken.None).Result;
            Assert.IsTrue(rs.Length == 3 && rs[0] == 33 && rs[1] == 44 && rs[2] == 50);
        }

        [TestMethod]
        public void MultipleElementsSkipAll()
        {
            var xs = AsyncEnumerable.FromValues(new[] { 10, 20, 30, 40, 50 });
            var rs = xs.SkipWhileAsync(x => true, CancellationToken.None).ToArrayAsync(CancellationToken.None).Result;
            Assert.IsTrue(rs.Length == 0);
        }
    }

    [TestClass]
    public class SkipWhileWithIndexTests
    {
        [TestMethod]
        public void ThrowsWhenSourceIsNull()
        {
            try
            {
                AsyncEnumerable.SkipWhileAsync<int>(null, (x, i) => true, CancellationToken.None);
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
        public void EmptySkipNone()
        {
            var xs = AsyncEnumerable.Empty<int>();
            var rs = xs.SkipWhileAsync((x, i) => false, CancellationToken.None).ToArrayAsync(CancellationToken.None).Result;
            Assert.IsTrue(rs.Length == 0);
        }

        [TestMethod]
        public void EmptySkipAll()
        {
            var xs = AsyncEnumerable.Empty<int>();
            var rs = xs.SkipWhileAsync((x, i) => true, CancellationToken.None).ToArrayAsync(CancellationToken.None).Result;
            Assert.IsTrue(rs.Length == 0);
        }

        [TestMethod]
        public void SingleElementSkipAll()
        {
            var xs = AsyncEnumerable.FromValue(42);
            var rs = xs.SkipWhileAsync((x, i) => true, CancellationToken.None).ToArrayAsync(CancellationToken.None).Result;
            Assert.IsTrue(rs.Length == 0);
        }

        [TestMethod]
        public void SingleElementSkipNone()
        {
            var xs = AsyncEnumerable.FromValue(42);
            var rs = xs.SkipWhileAsync((x, i) => false, CancellationToken.None).ToArrayAsync(CancellationToken.None).Result;
            Assert.IsTrue(rs.Length == 1 && rs[0] == 42);
        }

        [TestMethod]
        public void MultipleElementsSkipNone()
        {
            var xs = AsyncEnumerable.FromValues(new[] { 10, 20, 30 });
            var rs = xs.SkipWhileAsync((x, i) => false, CancellationToken.None).ToArrayAsync(CancellationToken.None).Result;
            Assert.IsTrue(rs.Length == 3 && rs[0] == 10 && rs[1] == 20 && rs[2] == 30);
        }

        [TestMethod]
        public void MultipleElementsSkipOne()
        {
            var xs = AsyncEnumerable.FromValues(new[] { 10, 20, 30 });
            var rs = xs.SkipWhileAsync((x, i) => i != 1, CancellationToken.None).ToArrayAsync(CancellationToken.None).Result;
            Assert.IsTrue(rs.Length == 2 && rs[0] == 20 && rs[1] == 30);
        }

        [TestMethod]
        public void MultipleElementsSkipMultiple()
        {
            var xs = AsyncEnumerable.FromValues(new[] { 10, 20, 33, 44, 50 });
            var rs = xs.SkipWhileAsync((x, i) => i != 2, CancellationToken.None).ToArrayAsync(CancellationToken.None).Result;
            Assert.IsTrue(rs.Length == 3 && rs[0] == 33 && rs[1] == 44 && rs[2] == 50);
        }

        [TestMethod]
        public void MultipleElementsSkipAll()
        {
            var xs = AsyncEnumerable.FromValues(new[] { 10, 20, 30, 40, 50 });
            var rs = xs.SkipWhileAsync((x, i) => true, CancellationToken.None).ToArrayAsync(CancellationToken.None).Result;
            Assert.IsTrue(rs.Length == 0);
        }
    }
}
