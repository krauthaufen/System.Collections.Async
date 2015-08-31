using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Collections.Async.Tests
{
    [TestClass]
    public class AllTests
    {
        [TestMethod]
        public void All_ThrowsWhenSourceIsNull()
        {
            TestHelpers.ThrowsAggregateArgumentNullException(() =>
                AsyncEnumerable.All<int>(null, _ => true, CancellationToken.None).Wait()
                );
        }
        [TestMethod]
        public void All_ThrowsWhenPredicateIsNull()
        {
            TestHelpers.ThrowsAggregateArgumentNullException(() =>
                AsyncEnumerable.FromValues(new[] { 10, 20, 30, 40, 50 }).All(null, CancellationToken.None).Wait()
                );
        }
        [TestMethod]
        public void All_FaultedOrCancelled()
        {
            TestHelpers.TestFaultedOrCanceled((source, ct) =>
                AsyncEnumerable.All(source, x => true, ct).Wait()
                );
        }
        
        [TestMethod]
        public void All_TrueWhenEmpty()
        {
            var xs = AsyncEnumerable.Empty<int>();
            Assert.IsTrue(xs.All(x => x == 0, CancellationToken.None).Result);
        }
        [TestMethod]
        public void All_TrueWhenNotEmptyWithPredicateMatch()
        {
            var xs = AsyncEnumerable.FromValues(new[] { 10, 20, 30, 40, 50 });
            Assert.IsTrue(xs.All(x => x % 10 == 0, CancellationToken.None).Result);
        }
        [TestMethod]
        public void All_FalseWhenNotEmptyWithPredicateNonMatch()
        {
            var xs = AsyncEnumerable.FromValues(new[] { 10, 20, 30, 4, 50 });
            Assert.IsFalse(xs.All(x => x % 10 == 0, CancellationToken.None).Result);
        }
    }
}
