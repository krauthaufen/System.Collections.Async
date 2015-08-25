using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Collections.Async.Tests
{
    [TestClass]
    public class FromValuesTests
    {
        [TestMethod]
        public void CanCreateSingle()
        {
            var xs = AsyncEnumerable.FromValue<int>(42);
            Assert.IsNotNull(xs);
        }

        [TestMethod]
        public void CanGetEnumeratorSingle()
        {
            var xs = AsyncEnumerable.FromValue<int>(42);
            Assert.IsNotNull(xs.GetEnumerator(CancellationToken.None).Result);
        }

        [TestMethod]
        public void GetEnumeratorFailsWhenCancelled()
        {
            var xs = AsyncEnumerable.FromValue<int>(42);

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
        public void EnumeratorSingleHasExactlyOneElement()
        {
            var ct = CancellationToken.None;
            var xs = AsyncEnumerable.FromValue<int>(42);
            var e = xs.GetEnumerator(ct).Result;
            Assert.IsTrue(e.MoveNext(ct).Result);
            Assert.IsTrue(e.Current == 42);
            Assert.IsFalse(e.MoveNext(ct).Result);
        }

        [TestMethod]
        public void CanCreateMultiple()
        {
            var xs = AsyncEnumerable.FromValues<int>(new int[] { 1, 2, 3 });
            Assert.IsNotNull(xs);
        }

        [TestMethod]
        public void CanGetEnumeratorMultiple()
        {
            var xs = AsyncEnumerable.FromValues<int>(new int[] { 1, 2, 3 });
            Assert.IsNotNull(xs.GetEnumerator(CancellationToken.None).Result);
        }

        [TestMethod]
        public void EnumeratorMultipleHasCorrectElements()
        {
            var ct = CancellationToken.None;
            var xs = AsyncEnumerable.FromValues<int>(new int[] { 1, 2, 3 });
            var e = xs.GetEnumerator(ct).Result;
            Assert.IsTrue(e.MoveNext(ct).Result);
            Assert.IsTrue(e.Current == 1);
            Assert.IsTrue(e.MoveNext(ct).Result);
            Assert.IsTrue(e.Current == 2);
            Assert.IsTrue(e.MoveNext(ct).Result);
            Assert.IsTrue(e.Current == 3);
            Assert.IsFalse(e.MoveNext(ct).Result);
        }
    }
}
