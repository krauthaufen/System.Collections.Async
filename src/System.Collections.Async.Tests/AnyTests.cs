using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Collections.Async.Tests
{
    [TestClass]
    public class AnyTests
    {
        [TestMethod]
        public void ThrowsWhenSourceIsNull()
        {
            try
            {
                AsyncEnumerable.AnyAsync<int>(null, CancellationToken.None).Wait();
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
                AsyncEnumerable.AnyAsync<int>(null, _ => true, CancellationToken.None).Wait();
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
                xs.AnyAsync(null, CancellationToken.None).Wait();
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
        public void FalseWhenEmpty()
        {
            var xs = AsyncEnumerable.Empty<int>();
            Assert.IsFalse(xs.AnyAsync(CancellationToken.None).Result);
        }

        [TestMethod]
        public void TrueWhenNotEmpty()
        {
            var xs = AsyncEnumerable.FromValue(42);
            Assert.IsTrue(xs.AnyAsync(CancellationToken.None).Result);
        }

        [TestMethod]
        public void FalseWhenEmptyWithPredicate()
        {
            var xs = AsyncEnumerable.Empty<int>();
            Assert.IsFalse(xs.AnyAsync(_ => true, CancellationToken.None).Result);
        }

        [TestMethod]
        public void TrueWhenNotEmptyWithPredicateMatch()
        {
            var xs = AsyncEnumerable.FromValues(new[] { 1, 2, 3, 4, 5 });
            Assert.IsTrue(xs.AnyAsync(x => x == 3, CancellationToken.None).Result);
        }

        [TestMethod]
        public void FalseWhenNotEmptyWithPredicateNonMatch()
        {
            var xs = AsyncEnumerable.FromValues(new[] { 1, 2, 3, 4, 5 });
            Assert.IsFalse(xs.AnyAsync(x => x == 0, CancellationToken.None).Result);
        }
    }
}
