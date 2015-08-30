using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Collections.Async.Tests
{
    [TestClass]
    public class CountTests
    {
        [TestMethod]
        public void ThrowsWhenSourceIsNull()
        {
            try
            {
                AsyncEnumerable.Count<int>(null, CancellationToken.None).Wait();
                Assert.Fail();
            }
            catch (Exception e)
            {
                var a = e as AggregateException;
                if (a == null || a.InnerExceptions.Count != 1 || !(a.InnerException is ArgumentNullException))
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod]
        public void ThrowsWhenPredicateIsNull()
        {
            try
            {
                var xs = AsyncEnumerable.FromValues(new[] { 10, 20, 30, 40, 50 });
                xs.Count(null, CancellationToken.None).Wait();
                Assert.Fail();
            }
            catch (Exception e)
            {
                var a = e as AggregateException;
                if (a == null || a.InnerExceptions.Count != 1 || !(a.InnerException is ArgumentNullException))
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod]
        public void ThrowsWhenSourceIsNull2()
        {
            try
            {
                AsyncEnumerable.Count<int>(null, _ => true, CancellationToken.None).Wait();
                Assert.Fail();
            }
            catch (Exception e)
            {
                var a = e as AggregateException;
                if (a == null || a.InnerExceptions.Count != 1 || !(a.InnerException is ArgumentNullException))
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod]
        public void CountEmptyIsZero()
        {
            var xs = AsyncEnumerable.Empty<int>();
            Assert.IsTrue(xs.Count(CancellationToken.None).Result == 0);
        }

        [TestMethod]
        public void CountEmptyWithAllIsZero()
        {
            var xs = AsyncEnumerable.Empty<int>();
            Assert.IsTrue(xs.Count(x => true, CancellationToken.None).Result == 0);
        }

        [TestMethod]
        public void CountEmptyWithNoneIsZero()
        {
            var xs = AsyncEnumerable.Empty<int>();
            Assert.IsTrue(xs.Count(x => false, CancellationToken.None).Result == 0);
        }

        [TestMethod]
        public void CountSingleIsOne()
        {
            var xs = AsyncEnumerable.FromValue(42);
            Assert.IsTrue(xs.Count(CancellationToken.None).Result == 1);
        }

        [TestMethod]
        public void CountSingleWithAllIsOne()
        {
            var xs = AsyncEnumerable.FromValue(42);
            Assert.IsTrue(xs.Count(x => true, CancellationToken.None).Result == 1);
        }

        [TestMethod]
        public void CountSingleWithNoneIsZero()
        {
            var xs = AsyncEnumerable.FromValue(42);
            Assert.IsTrue(xs.Count(x => false, CancellationToken.None).Result == 0);
        }

        [TestMethod]
        public void CountMultiple()
        {
            var xs = AsyncEnumerable.FromValues(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            Assert.IsTrue(xs.Count(CancellationToken.None).Result == 9);
        }

        [TestMethod]
        public void CountMultipleWithAll()
        {
            var xs = AsyncEnumerable.FromValues(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            Assert.IsTrue(xs.Count(x => true, CancellationToken.None).Result == 9);
        }

        [TestMethod]
        public void CountMultipleWithNone()
        {
            var xs = AsyncEnumerable.FromValues(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            Assert.IsTrue(xs.Count(x => false, CancellationToken.None).Result == 0);
        }

        [TestMethod]
        public void CountMultipleWithPredicate()
        {
            var xs = AsyncEnumerable.FromValues(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            Assert.IsTrue(xs.Count(x => x % 2 == 0, CancellationToken.None).Result == 4);
        }
    }
}
