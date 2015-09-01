//using System;
//using System.Threading;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

//namespace System.Collections.Async.Tests
//{
//    [TestClass]
//    public class SkipTests
//    {
//        [TestMethod]
//        public void ThrowsWhenSourceIsNull()
//        {
//            try
//            {
//                AsyncEnumerable.Skip<int>(null, 5, CancellationToken.None);
//                Assert.Fail();
//            }
//            catch (ArgumentNullException)
//            {
//            }
//            catch
//            {
//                Assert.Fail();
//            }
//        }
        
//        [TestMethod]
//        public void EmptySkipNone()
//        {
//            var xs = AsyncEnumerable.Empty<int>();
//            var rs = xs.Skip(0, CancellationToken.None).ToArray(CancellationToken.None).Result;
//            Assert.IsTrue(rs.Length == 0);
//        }

//        [TestMethod]
//        public void EmptySkipOne()
//        {
//            var xs = AsyncEnumerable.Empty<int>();
//            var rs = xs.Skip(1, CancellationToken.None).ToArray(CancellationToken.None).Result;
//            Assert.IsTrue(rs.Length == 0);
//        }

//        [TestMethod]
//        public void SingleElementSkipOne()
//        {
//            var xs = AsyncEnumerable.FromValue(42);
//            var rs = xs.Skip(1, CancellationToken.None).ToArray(CancellationToken.None).Result;
//            Assert.IsTrue(rs.Length == 0);
//        }

//        [TestMethod]
//        public void SingleElementSkipNone()
//        {
//            var xs = AsyncEnumerable.FromValue(42);
//            var rs = xs.Skip(0, CancellationToken.None).ToArray(CancellationToken.None).Result;
//            Assert.IsTrue(rs.Length == 1 && rs[0] == 42);
//        }

//        [TestMethod]
//        public void SingleElementSkipTwo()
//        {
//            var xs = AsyncEnumerable.FromValue(42);
//            var rs = xs.Skip(2, CancellationToken.None).ToArray(CancellationToken.None).Result;
//            Assert.IsTrue(rs.Length == 0);
//        }

//        [TestMethod]
//        public void SingleElementSkipNegative()
//        {
//            var xs = AsyncEnumerable.FromValue(42);
//            var rs = xs.Skip(-1, CancellationToken.None).ToArray(CancellationToken.None).Result;
//            Assert.IsTrue(rs.Length == 1 && rs[0] == 42);
//        }
        
//        [TestMethod]
//        public void MultipleElementsSkipNone()
//        {
//            var xs = AsyncEnumerable.FromValues(new[] { 10, 20, 30 });
//            var rs = xs.Skip(0, CancellationToken.None).ToArray(CancellationToken.None).Result;
//            Assert.IsTrue(rs.Length == 3 && rs[0] == 10 && rs[1] == 20 && rs[2] == 30);
//        }

//        [TestMethod]
//        public void MultipleElementsSkipOne()
//        {
//            var xs = AsyncEnumerable.FromValues(new[] { 10, 20, 30 });
//            var rs = xs.Skip(1, CancellationToken.None).ToArray(CancellationToken.None).Result;
//            Assert.IsTrue(rs.Length == 2 && rs[0] == 20 && rs[1] == 30);
//        }

//        [TestMethod]
//        public void MultipleElementsSkipMultiple()
//        {
//            var xs = AsyncEnumerable.FromValues(new[] { 10, 20, 30, 40, 50 });
//            var rs = xs.Skip(3, CancellationToken.None).ToArray(CancellationToken.None).Result;
//            Assert.IsTrue(rs.Length == 2 && rs[0] == 40 && rs[1] == 50);
//        }

//        [TestMethod]
//        public void MultipleElementsSkipAll()
//        {
//            var xs = AsyncEnumerable.FromValues(new[] { 10, 20, 30, 40, 50 });
//            var rs = xs.Skip(5, CancellationToken.None).ToArray(CancellationToken.None).Result;
//            Assert.IsTrue(rs.Length == 0);
//        }

//        [TestMethod]
//        public void MultipleElementsSkipMoreThanAll()
//        {
//            var xs = AsyncEnumerable.FromValues(new[] { 10, 20, 30, 40, 50 });
//            var rs = xs.Skip(50, CancellationToken.None).ToArray(CancellationToken.None).Result;
//            Assert.IsTrue(rs.Length == 0);
//        }

//        [TestMethod]
//        public void MultipleElementsSkipNegative()
//        {
//            var xs = AsyncEnumerable.FromValues(new[] { 10, 20, 30 });
//            var rs = xs.Skip(-2, CancellationToken.None).ToArray(CancellationToken.None).Result;
//            Assert.IsTrue(rs.Length == 3 && rs[0] == 10 && rs[1] == 20 && rs[2] == 30);
//        }
//    }
//}
