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
            try
            {
                AsyncEnumerable.DefaultIfEmptyAsync<int>(null, CancellationToken.None);
                Assert.Fail();
            }
            catch (ArgumentNullException)
            {
            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void ThrowsWhenSourceIsNull2()
        {
            try
            {
                AsyncEnumerable.DefaultIfEmptyAsync<int>(null, 42, CancellationToken.None);
                Assert.Fail();
            }
            catch (ArgumentNullException)
            {
            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void EmptyCase()
        {
            var xs = AsyncEnumerable.Empty<int>();
            Assert.IsTrue(xs.DefaultIfEmptyAsync(CancellationToken.None).SingleAsync(CancellationToken.None).Result == 0);
            Assert.IsTrue(xs.DefaultIfEmptyAsync(42, CancellationToken.None).SingleAsync(CancellationToken.None).Result == 42);
        }
        
        [TestMethod]
        public void NonEmptyCase()
        {
            var xs = AsyncEnumerable.FromValue(17);
            Assert.IsTrue(xs.DefaultIfEmptyAsync(CancellationToken.None).SingleAsync(CancellationToken.None).Result == 17);
            Assert.IsTrue(xs.DefaultIfEmptyAsync(42, CancellationToken.None).SingleAsync(CancellationToken.None).Result == 17);
        }
    }
}
