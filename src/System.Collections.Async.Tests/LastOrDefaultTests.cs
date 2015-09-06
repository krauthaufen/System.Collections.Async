using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Collections.Async.Tests
{
    [TestClass]
    public class LastOrDefaultTests
    {
        [TestMethod]
        public void ThrowsWhenSourceIsNull()
        {
            TestHelpers.ThrowsAggregateArgumentNullException(() =>
                AsyncEnumerable.LastOrDefault<int>(null, CancellationToken.None).Wait()
                );
        }

        [TestMethod]
        public void ThrowsWhenSourceIsNull2()
        {
            TestHelpers.ThrowsAggregateArgumentNullException(() =>
                AsyncEnumerable.LastOrDefault<int>(null, x => true, CancellationToken.None).Wait()
                );
        }

        [TestMethod]
        public void ThrowsOnPredicateIsNull()
        {
            TestHelpers.ThrowsAggregateArgumentNullException(() =>
                AsyncEnumerable.LastOrDefault(AsyncEnumerable.Empty<int>(), null, CancellationToken.None).Wait()
                );
        }

        [TestMethod]
        public void EmptyCase()
        {
            var xs = AsyncEnumerable.Empty<int>();
            Assert.IsTrue(xs.LastOrDefault(CancellationToken.None).Result == 0);
        }

        [TestMethod]
        public void EmptyCaseWithPredicate()
        {
            var xs = AsyncEnumerable.Empty<int>();
            Assert.IsTrue(xs.LastOrDefault(x => true, CancellationToken.None).Result == 0);
        }

        [TestMethod]
        public void SingleElement()
        {
            var xs = AsyncEnumerable.FromValue(42);
            Assert.IsTrue(xs.LastOrDefault(CancellationToken.None).Result == 42);
        }

        [TestMethod]
        public void MultipleElements()
        {
            var xs = AsyncEnumerable.FromValues(new[] { 10, 20, 30 });
            Assert.IsTrue(xs.LastOrDefault(CancellationToken.None).Result == 30);
        }

        [TestMethod]
        public void SingleElementWithPredicateMatch()
        {
            var xs = AsyncEnumerable.FromValue(42);
            Assert.IsTrue(xs.LastOrDefault(x => x == 42, CancellationToken.None).Result == 42);
        }

        [TestMethod]
        public void SingleElementWithPredicateMismatch()
        {
            var xs = AsyncEnumerable.FromValue(42);
            Assert.IsTrue(xs.LastOrDefault(x => x == 17, CancellationToken.None).Result == 0);
        }

        [TestMethod]
        public void MultipleElementsWithPredicateMatch()
        {
            var xs = AsyncEnumerable.FromValues(new[] { 1, 2, 3, 4, 5 });
            Assert.IsTrue(xs.LastOrDefault(x => x == 3, CancellationToken.None).Result == 3);
        }

        [TestMethod]
        public void MultipleElementsWithPredicateMultiMatch()
        {
            var xs = AsyncEnumerable.FromValues(new[] { 1, 2, 3, 3, 4, 5 });
            Assert.IsTrue(xs.LastOrDefault(x => x == 3, CancellationToken.None).Result == 3);
        }

        [TestMethod]
        public void FailsOnMultipleElementsWithPredicateMismatch()
        {
            var xs = AsyncEnumerable.FromValues(new[] { 1, 2, 3, 4, 5 });
            Assert.IsTrue(xs.LastOrDefault(x => x == 17, CancellationToken.None).Result == 0);
        }
    }
}
