using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Collections.Async.Tests
{
    [TestClass]
    public class DefaultIfEmptyTests
    {
        [TestMethod]
        public void ThrowsWhenSourceIsNull1()
        {
            TestHelpers.ThrowsArgumentNullException(() =>
                AsyncEnumerable.DefaultIfEmpty<int>(null)
                );
        }

        [TestMethod]
        public void ThrowsWhenSourceIsNull2()
        {
            TestHelpers.ThrowsArgumentNullException(() =>
                AsyncEnumerable.DefaultIfEmpty<int>(null, 42)
                );
        }

        [TestMethod]
        public void EmptyCase()
        {
            var xs = AsyncEnumerable.Empty<int>();
            Assert.IsTrue(xs.DefaultIfEmpty().Single().Result == 0);
            Assert.IsTrue(xs.DefaultIfEmpty(42).Single().Result == 42);
        }

        [TestMethod]
        public void NonEmptyCase()
        {
            var xs = AsyncEnumerable.FromValue(17);
            var test = xs.DefaultIfEmpty().ToArray().Result;
            Assert.IsTrue(xs.DefaultIfEmpty().Single().Result == 17);
            //Assert.IsTrue(xs.DefaultIfEmpty(42).Single().Result == 17);
        }
    }
}
