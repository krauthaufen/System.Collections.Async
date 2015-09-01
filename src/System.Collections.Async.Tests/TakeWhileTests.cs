using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Collections.Async.Tests
{
    [TestClass]
    public class TakeWhileTests
    {
        [TestMethod]
        public void ThrowsWhenSourceIsNull()
        {
            try
            {
                AsyncEnumerable.TakeWhile<int>(null, x => true, CancellationToken.None);
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
        public void ThrowsWhenPredicateIsNull()
        {
            try
            {
                AsyncEnumerable.TakeWhile<int>(AsyncEnumerable.Empty<int>(), (Func<int, bool>)null, CancellationToken.None);
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
            var rs = xs.TakeWhile(x => false, CancellationToken.None).ToArray(CancellationToken.None).Result;
            Assert.IsTrue(rs.Length == 0);
        }

        [TestMethod]
        public void EmptyTakeAll()
        {
            var xs = AsyncEnumerable.Empty<int>();
            var rs = xs.TakeWhile(x => true, CancellationToken.None).ToArray(CancellationToken.None).Result;
            Assert.IsTrue(rs.Length == 0);
        }

        [TestMethod]
        public void SingleElementTakeAll()
        {
            var xs = AsyncEnumerable.FromValue(42);
            var rs = xs.TakeWhile(x => true, CancellationToken.None).ToArray(CancellationToken.None).Result;
            Assert.IsTrue(rs.Length == 1 && rs[0] == 42);
        }

        [TestMethod]
        public void SingleElementTakeNone()
        {
            var xs = AsyncEnumerable.FromValue(42);
            var rs = xs.TakeWhile(x => false, CancellationToken.None).ToArray(CancellationToken.None).Result;
            Assert.IsTrue(rs.Length == 0);
        }

        [TestMethod]
        public void MultipleElementsTakeNone()
        {
            var xs = AsyncEnumerable.FromValues(new[] { 10, 20, 30 });
            var rs = xs.TakeWhile(x => false, CancellationToken.None).ToArray(CancellationToken.None).Result;
            Assert.IsTrue(rs.Length == 0);
        }

        [TestMethod]
        public void MultipleElementsTakeOne()
        {
            var xs = AsyncEnumerable.FromValues(new[] { 10, 20, 30 });
            var rs = xs.TakeWhile(x => x == 10, CancellationToken.None).ToArray(CancellationToken.None).Result;
            Assert.IsTrue(rs.Length == 1 && rs[0] == 10);
        }

        [TestMethod]
        public void MultipleElementsTakeMultiple()
        {
            var xs = AsyncEnumerable.FromValues(new[] { 10, 20, 33, 44, 50 });
            var rs = xs.TakeWhile(x => x % 10 == 0, CancellationToken.None).ToArray(CancellationToken.None).Result;
            Assert.IsTrue(rs.Length == 2 && rs[0] == 10 && rs[1] == 20);
        }

        [TestMethod]
        public void MultipleElementsTakeAll()
        {
            var xs = AsyncEnumerable.FromValues(new[] { 10, 20, 30, 40, 50 });
            var rs = xs.TakeWhile(x => true, CancellationToken.None).ToArray(CancellationToken.None).Result;
            Assert.IsTrue(rs.Length == 5 && rs[0] == 10 && rs[1] == 20 && rs[2] == 30 && rs[3] == 40 && rs[4] == 50);
        }
    }

    [TestClass]
    public class TakeWhileWithIndexTests
    {

        [TestMethod]
        public void ThrowsWhenSourceIsNull()
        {
            try
            {
                AsyncEnumerable.TakeWhile<int>(null, (x, i) => true, CancellationToken.None);
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
        public void ThrowsWhenPredicateIsNull()
        {
            try
            {
                AsyncEnumerable.TakeWhile<int>(AsyncEnumerable.Empty<int>(), (Func<int, int, bool>)null, CancellationToken.None);
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
            var rs = xs.TakeWhile((x, i) => false, CancellationToken.None).ToArray(CancellationToken.None).Result;
            Assert.IsTrue(rs.Length == 0);
        }

        [TestMethod]
        public void EmptyTakeAll()
        {
            var xs = AsyncEnumerable.Empty<int>();
            var rs = xs.TakeWhile((x, i) => true, CancellationToken.None).ToArray(CancellationToken.None).Result;
            Assert.IsTrue(rs.Length == 0);
        }

        [TestMethod]
        public void SingleElementTakeAll()
        {
            var xs = AsyncEnumerable.FromValue(42);
            var rs = xs.TakeWhile((x, i) => true, CancellationToken.None).ToArray(CancellationToken.None).Result;
            Assert.IsTrue(rs.Length == 1 && rs[0] == 42);
        }

        [TestMethod]
        public void SingleElementTakeNone()
        {
            var xs = AsyncEnumerable.FromValue(42);
            var rs = xs.TakeWhile((x, i) => false, CancellationToken.None).ToArray(CancellationToken.None).Result;
            Assert.IsTrue(rs.Length == 0);
        }

        [TestMethod]
        public void MultipleElementsTakeNone()
        {
            var xs = AsyncEnumerable.FromValues(new[] { 10, 20, 30 });
            var rs = xs.TakeWhile((x, i) => false, CancellationToken.None).ToArray(CancellationToken.None).Result;
            Assert.IsTrue(rs.Length == 0);
        }

        [TestMethod]
        public void MultipleElementsTakeOne()
        {
            var xs = AsyncEnumerable.FromValues(new[] { 10, 20, 30 });
            var rs = xs.TakeWhile((x, i) => i == 0, CancellationToken.None).ToArray(CancellationToken.None).Result;
            Assert.IsTrue(rs.Length == 1 && rs[0] == 10);
        }

        [TestMethod]
        public void MultipleElementsTakeMultiple()
        {
            var xs = AsyncEnumerable.FromValues(new[] { 10, 20, 33, 44, 50 });
            var rs = xs.TakeWhile((x, i) => i < 2, CancellationToken.None).ToArray(CancellationToken.None).Result;
            Assert.IsTrue(rs.Length == 2 && rs[0] == 10 && rs[1] == 20);
        }

        [TestMethod]
        public void MultipleElementsTakeAll()
        {
            var xs = AsyncEnumerable.FromValues(new[] { 10, 20, 30, 40, 50 });
            var rs = xs.TakeWhile((x, i) => true, CancellationToken.None).ToArray(CancellationToken.None).Result;
            Assert.IsTrue(rs.Length == 5 && rs[0] == 10 && rs[1] == 20 && rs[2] == 30 && rs[3] == 40 && rs[4] == 50);
        }
    }
}
