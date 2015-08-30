using System;
using System.Collections.Generic;
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
            TestHelpers.ThrowsArgumentNullException(() =>
                AsyncEnumerable.ToAsyncEnumerable((IEnumerable<Task<int>>)null)
                );
        }
        [TestMethod]
        public void ThrowsWhenSourceIsNull2()
        {
            TestHelpers.ThrowsArgumentNullException(() =>
                AsyncEnumerable.ToAsyncEnumerable((Task<int>)null)
                );
        }



        [TestMethod]
        public void ThrowsWhenFaulted1()
        {
            try
            {
                var x = TestHelpers.FaultedTask;
                var rs = x.ToAsyncEnumerable().ToArray().Result;
                Assert.Fail();
            }
            catch (Exception e)
            {
                var a = e as AggregateException;
                if (a == null || a.InnerExceptions.Count != 1 || !(a.InnerException.Message == "Test"))
                    Assert.Fail();
            }
        }
        [TestMethod]
        public void ThrowsWhenFaulted2()
        {
            try
            {
                var xs = new[] { Task.FromResult(1), TestHelpers.FaultedTask, Task.FromResult(2) };
                var rs = xs.ToAsyncEnumerable().ToArray().Result;
                Assert.Fail();
            }
            catch (Exception e)
            {
                var a = e as AggregateException;
                if (a == null || a.InnerExceptions.Count != 1 || !(a.InnerException.Message == "Test"))
                    Assert.Fail();
            }
        }



        [TestMethod]
        public void EmptyCase1()
        {
            var xs = Enumerable.Empty<Task<int>>();
            var rs = xs.ToAsyncEnumerable().ToArray().Result;
            Assert.IsTrue(rs.Length == 0);
        }
        [TestMethod]
        public void SingleElement1()
        {
            var x = Task.FromResult(42);
            var rs = x.ToAsyncEnumerable().ToArray().Result;
            Assert.IsTrue(rs.Length == 1 && rs[0] == 42);
        }
        [TestMethod]
        public void SingleElement2()
        {
            var xs = new[] { Task.FromResult(42) };
            var rs = xs.ToAsyncEnumerable().ToArray().Result;
            Assert.IsTrue(rs.Length == 1 && rs[0] == 42);
        }
        [TestMethod]
        public void MultipleElements()
        {
            var xs = new[] { 10, 20, 30 };
            var rs = xs.Select(x => Task.FromResult(x)).ToAsyncEnumerable().ToArray().Result;
            Assert.IsTrue(rs.Length == 3 && rs[0] == 10 && rs[1] == 20 && rs[2] == 30);
        }



        [TestMethod]
        public void EmptyCaseWithSelector()
        {
            var xs = Enumerable.Empty<int>();
            var rs = xs.Select(x => Task.FromResult(x)).ToAsyncEnumerable().ToArray().Result;
            Assert.IsTrue(rs.Length == 0);
        }
        [TestMethod]
        public void SingleElementWithSelector()
        {
            var xs = new[] { 42 };
            var rs = xs.Select(x => Task.FromResult(x)).ToAsyncEnumerable().ToArray().Result;
            Assert.IsTrue(rs.Length == 1 && rs[0] == 42);
        }
        [TestMethod]
        public void MultipleElementsWithSelector()
        {
            var xs = new[] { Task.FromResult(10), Task.FromResult(20), Task.FromResult(30) };
            var rs = xs.ToAsyncEnumerable().ToArray().Result;
            Assert.IsTrue(rs.Length == 3 && rs[0] == 10 && rs[1] == 20 && rs[2] == 30);
        }
    }
}
