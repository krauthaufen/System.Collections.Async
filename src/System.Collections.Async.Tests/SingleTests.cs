using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Collections.Async.Tests
{
    [TestClass]
    public class SingleTests
    {
        [TestMethod]
        public void ThrowsWhenSourceIsNull()
        {
            TestHelpers.ThrowsAggregateArgumentNullException(() =>
                AsyncEnumerable.Single<int>(null, CancellationToken.None).Wait()
                );
        }

        [TestMethod]
        public void ThrowsOnEmpty()
        {
            TestHelpers.ThrowsAggregateInvalidOperationException(() =>
                AsyncEnumerable.Single(AsyncEnumerable.Empty<int>(), CancellationToken.None).Wait()
                );
        }

        [TestMethod]
        public void ThrowsOnMultiple()
        {
            TestHelpers.ThrowsAggregateInvalidOperationException(() =>
                AsyncEnumerable.Single(AsyncEnumerable.FromValues(new[] { 10, 20 }), CancellationToken.None).Wait()
                );
        }

        [TestMethod]
        public void SucceedsOnSingleElement()
        {
            var xs = AsyncEnumerable.FromValue(42);
            Assert.IsTrue(xs.Single(CancellationToken.None).Result == 42);
        }
    }
}
