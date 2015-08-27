using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Collections.Async.Tests
{
    [TestClass]
    public class ConcatTests
    {
        [TestMethod]
        public void ThrowsWhenFirstIsNull()
        {
            try
            {
                AsyncEnumerable.Concat(null, AsyncEnumerable.FromValues(new[] { 1, 2, 3, 4, 5 }), CancellationToken.None);
                Assert.Fail();
            }
            catch (ArgumentNullException)
            {
                return;
            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void ThrowsWhenSecondIsNull()
        {
            try
            {
                AsyncEnumerable.Concat(AsyncEnumerable.FromValues(new[] { 1, 2, 3, 4, 5 }), null, CancellationToken.None);
                Assert.Fail();
            }
            catch (ArgumentNullException)
            {
                return;
            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void ThrowsWhenFirstAndSecondAreNull()
        {
            try
            {
                AsyncEnumerable.Concat<int>(null, null, CancellationToken.None);
                Assert.Fail();
            }
            catch (ArgumentNullException)
            {
                return;
            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void CanConcatEmptyAndEmpty()
        {
            var a = AsyncEnumerable.FromValues(new int[] { });
            var b = AsyncEnumerable.FromValues(new int[] { });
            var c = a.Concat(b, CancellationToken.None).ToArrayAsync(CancellationToken.None).Result;
            Assert.IsTrue(c.Length == 0);
        }

        [TestMethod]
        public void CanConcatEmptyAndSingle()
        {
            var a = AsyncEnumerable.FromValues(new int[] { });
            var b = AsyncEnumerable.FromValues(new int[] { 42 });
            var c = a.Concat(b, CancellationToken.None).ToArrayAsync(CancellationToken.None).Result;
            Assert.IsTrue(c.Length == 1 && c[0] == 42);
        }

        [TestMethod]
        public void CanConcatEmptyAndMulti()
        {
            var a = AsyncEnumerable.FromValues(new int[] { });
            var b = AsyncEnumerable.FromValues(new int[] { 1, 2, 3 });
            var c = a.Concat(b, CancellationToken.None).ToArrayAsync(CancellationToken.None).Result;
            Assert.IsTrue(c.Length == 3 && c[0] == 1 && c[1] == 2 && c[2] == 3);
        }

        [TestMethod]
        public void CanConcatSingleAndEmpty()
        {
            var a = AsyncEnumerable.FromValues(new int[] { 17 });
            var b = AsyncEnumerable.FromValues(new int[] { });
            var c = a.Concat(b, CancellationToken.None).ToArrayAsync(CancellationToken.None).Result;
            Assert.IsTrue(c.Length == 1 && c[0] == 17);
        }

        [TestMethod]
        public void CanConcatSingleAndSingle()
        {
            var a = AsyncEnumerable.FromValues(new int[] { 17 });
            var b = AsyncEnumerable.FromValues(new int[] { 42 });
            var c = a.Concat(b, CancellationToken.None).ToArrayAsync(CancellationToken.None).Result;
            Assert.IsTrue(c.Length == 2 && c[0] == 17 && c[1] == 42);
        }

        [TestMethod]
        public void CanConcatSingleAndMulti()
        {
            var a = AsyncEnumerable.FromValues(new int[] { 17 });
            var b = AsyncEnumerable.FromValues(new int[] { 1, 2, 3 });
            var c = a.Concat(b, CancellationToken.None).ToArrayAsync(CancellationToken.None).Result;
            Assert.IsTrue(c.Length == 4 && c[0] == 17 && c[1] == 1 && c[2] == 2 && c[3] == 3);
        }

        [TestMethod]
        public void CanConcatMultiAndEmpty()
        {
            var a = AsyncEnumerable.FromValues(new int[] { 17, 18, 19 });
            var b = AsyncEnumerable.FromValues(new int[] { });
            var c = a.Concat(b, CancellationToken.None).ToArrayAsync(CancellationToken.None).Result;
            Assert.IsTrue(c.Length == 3 && c[0] == 17 && c[1] == 18 && c[2] == 19);
        }

        [TestMethod]
        public void CanConcatMultiAndSingle()
        {
            var a = AsyncEnumerable.FromValues(new int[] { 17, 18, 19 });
            var b = AsyncEnumerable.FromValues(new int[] { 42 });
            var c = a.Concat(b, CancellationToken.None).ToArrayAsync(CancellationToken.None).Result;
            Assert.IsTrue(c.Length == 4 && c[0] == 17 && c[1] == 18 && c[2] == 19 && c[3] == 42);
        }

        [TestMethod]
        public void CanConcatMultiAndMulti()
        {
            var a = AsyncEnumerable.FromValues(new int[] { 17, 18, 19 });
            var b = AsyncEnumerable.FromValues(new int[] { 1, 2, 3 });
            var c = a.Concat(b, CancellationToken.None).ToArrayAsync(CancellationToken.None).Result;
            Assert.IsTrue(c.Length == 6 && c[0] == 17 && c[1] == 18 && c[2] == 19 && c[3] == 1 && c[4] == 2 && c[5] == 3);
        }
    }
}
