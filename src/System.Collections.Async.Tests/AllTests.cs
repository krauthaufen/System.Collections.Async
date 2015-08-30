using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Collections.Async.Tests
{
    [TestClass]
    public class AllTests
    {
        [TestMethod]
        public void ThrowsWhenSourceIsNull()
        {
            try
            {
                AsyncEnumerable.All<int>(null, _ => true, CancellationToken.None).Wait();
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
                xs.All(null, CancellationToken.None).Wait();
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
        public void TrueWhenEmpty()
        {
            var xs = AsyncEnumerable.Empty<int>();
            Assert.IsTrue(xs.All(x => x == 0, CancellationToken.None).Result);
        }
        
        [TestMethod]
        public void TrueWhenNotEmptyWithPredicateMatch()
        {
            var xs = AsyncEnumerable.FromValues(new[] { 10, 20, 30, 40, 50 });
            Assert.IsTrue(xs.All(x => x % 10 == 0, CancellationToken.None).Result);
        }

        [TestMethod]
        public void FalseWhenNotEmptyWithPredicateNonMatch()
        {
            var xs = AsyncEnumerable.FromValues(new[] { 10, 20, 30, 4, 50 });
            Assert.IsFalse(xs.All(x => x % 10 == 0, CancellationToken.None).Result);
        }
    }
}
