using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Collections.Async.Tests
{
    [TestClass]
    public class ForEachTests
    {
        [TestMethod]
        public void ThrowsWhenSourceIsNull()
        {
            try
            {
                AsyncEnumerable.ForEach<int>(null, _ => { }, CancellationToken.None).Wait();
                Assert.Fail();
            }
            catch (Exception e)
            {
                var a = e as AggregateException;
                if (a == null || a.InnerExceptions.Count != 1 || !(a.InnerException is ArgumentNullException))
                    Assert.Fail();
            }
        }

        [TestMethod]
        public void ThrowsWhenActionIsNull()
        {
            try
            {
                var xs = AsyncEnumerable.FromValues(new[] { 10, 20, 30, 40, 50 });
                xs.ForEach(null, CancellationToken.None).Wait();
                Assert.Fail();
            }
            catch (Exception e)
            {
                var a = e as AggregateException;
                if (a == null || a.InnerExceptions.Count != 1 || !(a.InnerException is ArgumentNullException))
                    Assert.Fail();
            }
        }

        [TestMethod]
        public void ForEachOnEmpty()
        {
            var xs = AsyncEnumerable.Empty<int>();
            xs.ForEach(_ => Assert.Fail(), CancellationToken.None).Wait();
        }

        [TestMethod]
        public void ForEachOnMultiple()
        {
            var xs = AsyncEnumerable.FromValues<int>(new[] { 1, 2, 3, 4 });
            var result = 0;
            xs.ForEach(x => result += x, CancellationToken.None).Wait();
            Assert.IsTrue(result == 10);
        }

        [TestMethod]
        public void FailsWhenCancelled()
        {
            var xs = AsyncEnumerable.FromValue<int>(42);

            try
            {
                xs.ForEach(_ => { }, Helper.CANCELLED).Wait();
                Assert.Fail();
            }
            catch
            {
                Assert.IsTrue(Helper.CANCELLED.IsCancellationRequested);
            }
        }
    }
}
