using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Collections.Async.Tests
{
    [TestClass]
    public class ToListTests
    {
        [TestMethod]
        public void ThrowsWhenSourceIsNull()
        {
            try
            {
                AsyncEnumerable.ToListAsync<int>(null, CancellationToken.None).Wait();
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
        public void EmptyCase()
        {
            var xs = AsyncEnumerable.Empty<int>();
            var rs = xs.ToListAsync(CancellationToken.None).Result;
            Assert.IsTrue(rs.Count == 0);
        }

        [TestMethod]
        public void SingleElement()
        {
            var xs = AsyncEnumerable.FromValue(42);
            var rs = xs.ToListAsync(CancellationToken.None).Result;
            Assert.IsTrue(rs.Count == 1 && rs[0] == 42);
        }
        
        [TestMethod]
        public void MultipleElements()
        {
            var xs = AsyncEnumerable.FromValues(new[] { 10, 20, 30 });
            var rs = xs.ToListAsync(CancellationToken.None).Result;
            Assert.IsTrue(rs.Count == 3 && rs[0] == 10 && rs[1] == 20 && rs[2] == 30);
        }
    }
}
