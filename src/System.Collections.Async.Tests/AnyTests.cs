using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Collections.Async.Tests
{
    [TestClass]
    public class AnyTests
    {
        [TestMethod]
        public void Any_ThrowsWhenSourceIsNull()
        {
            TestHelpers.ThrowsAggregateArgumentNullException(() =>
                AsyncEnumerable.Any<int>(null, CancellationToken.None).Wait()
                );
        }
        [TestMethod]
        public void Any_ThrowsWhenSourceIsNull2()
        {
            TestHelpers.ThrowsAggregateArgumentNullException(() =>
                AsyncEnumerable.Any<int>(null, _ => true, CancellationToken.None).Wait()
                );
        }
        [TestMethod]
        public void Any_ThrowsWhenPredicateIsNull()
        {
            TestHelpers.ThrowsAggregateArgumentNullException(() =>
                AsyncEnumerable.FromValues(new[] { 10, 20, 30, 40, 50 }).Any(null, CancellationToken.None).Wait()
                );
        }
        [TestMethod]
        public void Any_FaultedOrCancelled1()
        {
            TestHelpers.TestFaultedOrCanceled((source, ct) =>
                AsyncEnumerable.Any(source, ct).Wait()
                );
        }
        [TestMethod]
        public void Any_FaultedOrCancelled2()
        {
            TestHelpers.TestFaultedOrCanceled((source, ct) =>
                AsyncEnumerable.Any(source, x => false, ct).Wait()
                );
        }

        [TestMethod]
        public void Any_FalseWhenEmpty()
        {
            var xs = AsyncEnumerable.Empty<int>();
            Assert.IsFalse(xs.Any(CancellationToken.None).Result);
        }
        [TestMethod]
        public void Any_TrueWhenNotEmpty()
        {
            var xs = AsyncEnumerable.FromValue(42);
            Assert.IsTrue(xs.Any(CancellationToken.None).Result);
        }
        [TestMethod]
        public void Any_FalseWhenEmptyWithPredicate()
        {
            var xs = AsyncEnumerable.Empty<int>();
            Assert.IsFalse(xs.Any(_ => true, CancellationToken.None).Result);
        }
        [TestMethod]
        public void Any_TrueWhenNotEmptyWithPredicateMatch()
        {
            var xs = AsyncEnumerable.FromValues(new[] { 1, 2, 3, 4, 5 });
            Assert.IsTrue(xs.Any(x => x == 3, CancellationToken.None).Result);
        }
        [TestMethod]
        public void Any_FalseWhenNotEmptyWithPredicateNonMatch()
        {
            var xs = AsyncEnumerable.FromValues(new[] { 1, 2, 3, 4, 5 });
            Assert.IsFalse(xs.Any(x => x == 0, CancellationToken.None).Result);
        }
    }
}
