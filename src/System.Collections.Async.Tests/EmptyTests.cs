using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Collections.Async.Tests
{
    [TestClass]
    public class EmptyTests
    {
        [TestMethod]
        public void CanCreate()
        {
            var xs = AsyncEnumerable.Empty<int>();
            Assert.IsNotNull(xs);
        }

        [TestMethod]
        public void CanGetEnumerator()
        {
            var xs = AsyncEnumerable.Empty<int>();
            Assert.IsNotNull(xs.GetEnumerator(CancellationToken.None).Result);
        }
        
        [TestMethod]
        public void GetEnumeratorFailsWhenCancelled()
        {
            var xs = AsyncEnumerable.Empty<int>();

            try
            {
                var result = xs.GetEnumerator(Helper.CANCELLED).Result;
                Assert.Fail();
            }
            catch
            {
                Assert.IsTrue(Helper.CANCELLED.IsCancellationRequested);
            }
        }

        [TestMethod]
        public void EnumeratorHasNoElements()
        {
            var ct = CancellationToken.None;
            var xs = AsyncEnumerable.Empty<int>();
            var e = xs.GetEnumerator(ct).Result;
            var result = e.MoveNext(ct).Result;
            Assert.IsFalse(result);
            Assert.IsTrue(e.Current == default(int));
        }
    }
}
