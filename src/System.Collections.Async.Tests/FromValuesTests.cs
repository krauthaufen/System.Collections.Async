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
            var xs = AsyncEnumerable.FromValue(42);
            Assert.IsNotNull(xs);
        }

        [TestMethod]
        public void CanGetEnumeratorSingle()
        {
            var xs = AsyncEnumerable.FromValue(42);
            Assert.IsNotNull(xs.GetEnumerator(CancellationToken.None).Result);
        }

        [TestMethod]
        public void GetEnumeratorFailsWhenCancelled()
        {
            var xs = AsyncEnumerable.FromValue(42);

            try
            {
                var result = xs.GetEnumerator(new CancellationToken(true)).Result;
                Assert.Fail();
            }
            catch
            {
            }
        }


        [TestMethod]
        public void EnumeratorSingleHasExactlyOneElement()
        {
            var ct = CancellationToken.None;
            var xs = AsyncEnumerable.FromValue(42);
            var e = xs.GetEnumerator(ct).Result;

            var x = e.MoveNext(ct).Result;
            Assert.IsTrue(x.IsValue);
            Assert.IsTrue(x.Value == 42);
            x = e.MoveNext(ct).Result;
            Assert.IsTrue(x.IsCompleted);
        }

        [TestMethod]
        public void CanCreateMultiple()
        {
            var xs = AsyncEnumerable.FromValues(new [] { 1, 2, 3 });
            Assert.IsNotNull(xs);
        }

        [TestMethod]
        public void CanGetEnumeratorMultiple()
        {
            var xs = AsyncEnumerable.FromValues(new [] { 1, 2, 3 });
            Assert.IsNotNull(xs.GetEnumerator(CancellationToken.None).Result);
        }

        [TestMethod]
        public void EnumeratorMultipleHasCorrectElements()
        {
            var ct = CancellationToken.None;
            var xs = AsyncEnumerable.FromValues(new [] { 1, 2, 3 });
            var e = xs.GetEnumerator(ct).Result;

            var x = e.MoveNext(ct).Result;
            Assert.IsTrue(x.IsValue);
            Assert.IsTrue(x.Value == 1);
            x = e.MoveNext(ct).Result;
            Assert.IsTrue(x.IsValue);
            Assert.IsTrue(x.Value == 2);
            x = e.MoveNext(ct).Result;
            Assert.IsTrue(x.IsValue);
            Assert.IsTrue(x.Value == 3);
            x = e.MoveNext(ct).Result;
            Assert.IsTrue(x.IsCompleted);
        }
    }
}
