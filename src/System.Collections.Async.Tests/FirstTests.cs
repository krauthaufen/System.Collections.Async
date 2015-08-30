using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Collections.Async.Tests
{
    [TestClass]
    public class FirstTests
    {
        [TestMethod]
        public void ThrowsWhenSourceIsNull()
        {
            try
            {
                AsyncEnumerable.First<int>(null, CancellationToken.None).Wait();
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
                AsyncEnumerable.First<int>(null, x => true, CancellationToken.None).Wait();
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
        public void ThrowsOnEmpty()
        {
            try
            {
                var xs = AsyncEnumerable.Empty<int>();
                AsyncEnumerable.First<int>(xs, CancellationToken.None).Wait();
                Assert.Fail();
            }
            catch (Exception e)
            {
                var a = e as AggregateException;
                if (a == null || a.InnerExceptions.Count != 1 || !(a.InnerException is InvalidOperationException))
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod]
        public void ThrowsOnEmpty2()
        {
            try
            {
                var xs = AsyncEnumerable.Empty<int>();
                AsyncEnumerable.First<int>(xs, x => true, CancellationToken.None).Wait();
                Assert.Fail();
            }
            catch (Exception e)
            {
                var a = e as AggregateException;
                if (a == null || a.InnerExceptions.Count != 1 || !(a.InnerException is InvalidOperationException))
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod]
        public void ThrowsOnPredicateIsNull()
        {
            try
            {
                var xs = AsyncEnumerable.Empty<int>();
                AsyncEnumerable.First<int>(xs, null, CancellationToken.None).Wait();
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
        public void SingleElement()
        {
            var xs = AsyncEnumerable.FromValue(42);
            Assert.IsTrue(xs.First(CancellationToken.None).Result == 42);
        }

        [TestMethod]
        public void MultipleElements()
        {
            var xs = AsyncEnumerable.FromValues(new[] { 10, 20, 30 });
            Assert.IsTrue(xs.First(CancellationToken.None).Result == 10);
        }

        [TestMethod]
        public void SingleElementWithPredicateMatch()
        {
            var xs = AsyncEnumerable.FromValue(42);
            Assert.IsTrue(xs.First(x => x == 42, CancellationToken.None).Result == 42);
        }

        [TestMethod]
        public void FailsOnSingleElementWithPredicateMismatch()
        {
            try
            {
                var xs = AsyncEnumerable.FromValue(42);
                xs.First(x => x == 17, CancellationToken.None).Wait();
                Assert.Fail();
            }
            catch (Exception e)
            {
                var a = e as AggregateException;
                if (a == null || a.InnerExceptions.Count != 1 || !(a.InnerException is InvalidOperationException))
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod]
        public void MultipleElementsWithPredicateMatch()
        {
            var xs = AsyncEnumerable.FromValues(new[] { 1, 2, 3, 4, 5 });
            Assert.IsTrue(xs.First(x => x == 3, CancellationToken.None).Result == 3);
        }

        [TestMethod]
        public void MultipleElementsWithPredicateMultiMatch()
        {
            var xs = AsyncEnumerable.FromValues(new[] { 1, 2, 3, 3, 4, 5 });
            Assert.IsTrue(xs.First(x => x == 3, CancellationToken.None).Result == 3);
        }

        [TestMethod]
        public void FailsOnMultipleElementsWithPredicateMismatch()
        {
            try
            {
                var xs = AsyncEnumerable.FromValues(new[] { 1, 2, 3, 4, 5 });
                xs.First(x => x == 17, CancellationToken.None).Wait();
                Assert.Fail();
            }
            catch (Exception e)
            {
                var a = e as AggregateException;
                if (a == null || a.InnerExceptions.Count != 1 || !(a.InnerException is InvalidOperationException))
                {
                    Assert.Fail();
                }
            }
        }
    }
}
