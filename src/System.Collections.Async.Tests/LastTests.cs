using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Collections.Async.Tests
{
    [TestClass]
    public class LastTests
    {
        [TestMethod]
        public void ThrowsWhenSourceIsNull()
        {
            TestHelpers.ThrowsAggregateArgumentNullException(() =>
                AsyncEnumerable.Last<int>(null, CancellationToken.None).Wait()
                );
        }

        [TestMethod]
        public void ThrowsWhenSourceIsNull2()
        {
            TestHelpers.ThrowsAggregateArgumentNullException(() =>
                AsyncEnumerable.Last<int>(null, x => true, CancellationToken.None).Wait()
                );
        }

        [TestMethod]
        public void ThrowsOnEmpty()
        {
            TestHelpers.ThrowsAggregateInvalidOperationException(() =>
                AsyncEnumerable.Last<int>(AsyncEnumerable.Empty<int>(), CancellationToken.None).Wait()
                );
        }

        [TestMethod]
        public void ThrowsOnEmpty2()
        {
            TestHelpers.ThrowsAggregateInvalidOperationException(() =>
                AsyncEnumerable.Last<int>(AsyncEnumerable.Empty<int>(), x => true, CancellationToken.None).Wait()
                );
        }

        [TestMethod]
        public void ThrowsOnPredicateIsNull()
        {
            TestHelpers.ThrowsAggregateArgumentNullException(() =>
                AsyncEnumerable.Last<int>(AsyncEnumerable.Empty<int>(), null, CancellationToken.None).Wait()
                );
        }

        [TestMethod]
        public void SingleElement()
        {
            var xs = AsyncEnumerable.FromValue(42);
            Assert.IsTrue(xs.Last(CancellationToken.None).Result == 42);
        }

        [TestMethod]
        public void MultipleElements()
        {
            var xs = AsyncEnumerable.FromValues(new[] { 10, 20, 30 });
            Assert.IsTrue(xs.Last(CancellationToken.None).Result == 30);
        }

        [TestMethod]
        public void SingleElementWithPredicateMatch()
        {
            var xs = AsyncEnumerable.FromValue(42);
            Assert.IsTrue(xs.Last(x => x == 42, CancellationToken.None).Result == 42);
        }

        [TestMethod]
        public void FailsOnSingleElementWithPredicateMismatch()
        {
            try
            {
                var xs = AsyncEnumerable.FromValue(42);
                xs.Last(x => x == 17, CancellationToken.None).Wait();
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
            Assert.IsTrue(xs.Last(x => x == 3, CancellationToken.None).Result == 3);
        }

        [TestMethod]
        public void MultipleElementsWithPredicateMultiMatch()
        {
            var xs = AsyncEnumerable.FromValues(new[] { 1, 2, 3, 3, 4, 5 });
            Assert.IsTrue(xs.Last(x => x == 3, CancellationToken.None).Result == 3);
        }

        [TestMethod]
        public void FailsOnMultipleElementsWithPredicateMismatch()
        {
            try
            {
                var xs = AsyncEnumerable.FromValues(new[] { 1, 2, 3, 4, 5 });
                xs.Last(x => x == 17, CancellationToken.None).Wait();
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
