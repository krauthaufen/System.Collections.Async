using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Collections.Async.Tests
{
    [TestClass]
    public class ToAsyncEnumerableTests
    {
        [TestMethod]
        public void ThrowsWhenSourceIsNull1()
        {
            try
            {
                AsyncEnumerable.ToAsyncEnumerable<int>(null);
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
        public void ThrowsWhenSourceIsNull2()
        {
            try
            {
                AsyncEnumerable.ToAsyncEnumerable<int, int>(null, x => Task.FromResult(x));
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
        public void ThrowsWhenSelectorIsNull()
        {
            try
            {
                AsyncEnumerable.ToAsyncEnumerable<int, int>(new[] { 1, 2, 3, 4, 5 }, null);
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
            var xs = Enumerable.Empty<Task<int>>();
            var rs = xs.ToAsyncEnumerable().ToArrayAsync().Result;
            Assert.IsTrue(rs.Length == 0);
        }

        [TestMethod]
        public void EmptyCaseWithSelector()
        {
            var xs = Enumerable.Empty<int>();
            var rs = xs.ToAsyncEnumerable(x => Task.FromResult(x)).ToArrayAsync().Result;
            Assert.IsTrue(rs.Length == 0);
        }

        [TestMethod]
        public void SingleElement()
        {
            var xs = new[] { Task.FromResult(42) };
            var rs = xs.ToAsyncEnumerable().ToArrayAsync().Result;
            Assert.IsTrue(rs.Length == 1 && rs[0] == 42);
        }

        [TestMethod]
        public void SingleElementWithSelector()
        {
            var xs = new[] { 42 };
            var rs = xs.ToAsyncEnumerable(x => Task.FromResult(x)).ToArrayAsync().Result;
            Assert.IsTrue(rs.Length == 1 && rs[0] == 42);
        }

        [TestMethod]
        public void MultipleElements()
        {
            var xs = new[] { 10, 20, 30 };
            var rs = xs.ToAsyncEnumerable(x => Task.FromResult(x)).ToArrayAsync().Result;
            Assert.IsTrue(rs.Length == 3 && rs[0] == 10 && rs[1] == 20 && rs[2] == 30);
        }

        [TestMethod]
        public void MultipleElementsWithSelector()
        {
            var xs = new[] { Task.FromResult(10), Task.FromResult(20), Task.FromResult(30) };
            var rs = xs.ToAsyncEnumerable().ToArrayAsync().Result;
            Assert.IsTrue(rs.Length == 3 && rs[0] == 10 && rs[1] == 20 && rs[2] == 30);
        }
    }
}
