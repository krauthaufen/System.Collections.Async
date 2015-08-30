//using System;
//using System.Threading;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

//namespace System.Collections.Async.Tests
//{
//    [TestClass]
//    public class WhereTests
//    {
//        [TestMethod]
//        public void ThrowsWhenSourceIsNull()
//        {
//            try
//            {
//                AsyncEnumerable.Where<int>(null, x => true, CancellationToken.None);
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
//        public void EmptyWhereNone()
//        {
//            var xs = AsyncEnumerable.Empty<int>();
//            var rs = xs.Where(x => false, CancellationToken.None).ToArrayAsync(CancellationToken.None).Result;
//            Assert.IsTrue(rs.Length == 0);
//        }

//        [TestMethod]
//        public void EmptyWhereAll()
//        {
//            var xs = AsyncEnumerable.Empty<int>();
//            var rs = xs.Where(x => true, CancellationToken.None).ToArrayAsync(CancellationToken.None).Result;
//            Assert.IsTrue(rs.Length == 0);
//        }

//        [TestMethod]
//        public void SingleElementWhereAll()
//        {
//            var xs = AsyncEnumerable.FromValue(42);
//            var rs = xs.Where(x => true, CancellationToken.None).ToArrayAsync(CancellationToken.None).Result;
//            Assert.IsTrue(rs.Length == 1 && rs[0] == 42);
//        }

//        [TestMethod]
//        public void SingleElementWhereNone()
//        {
//            var xs = AsyncEnumerable.FromValue(42);
//            var rs = xs.Where(x => false, CancellationToken.None).ToArrayAsync(CancellationToken.None).Result;
//            Assert.IsTrue(rs.Length == 0);
//        }
        
//        [TestMethod]
//        public void MultipleElementsWhereNone()
//        {
//            var xs = AsyncEnumerable.FromValues(new[] { 10, 20, 30 });
//            var rs = xs.Where(x => false, CancellationToken.None).ToArrayAsync(CancellationToken.None).Result;
//            Assert.IsTrue(rs.Length == 0);
//        }

//        [TestMethod]
//        public void MultipleElementsWhereOne()
//        {
//            var xs = AsyncEnumerable.FromValues(new[] { 10, 20, 30 });
//            var rs = xs.Where(x => x == 30, CancellationToken.None).ToArrayAsync(CancellationToken.None).Result;
//            Assert.IsTrue(rs.Length == 1 && rs[0] == 30);
//        }

//        [TestMethod]
//        public void MultipleElementsWhereMultiple()
//        {
//            var xs = AsyncEnumerable.FromValues(new[] { 10, 20, 33, 44, 50 });
//            var rs = xs.Where(x => x % 10 == 0, CancellationToken.None).ToArrayAsync(CancellationToken.None).Result;
//            Assert.IsTrue(rs.Length == 3 && rs[0] == 10 && rs[1] == 20 && rs[2] == 50);
//        }

//        [TestMethod]
//        public void MultipleElementsWhereAll()
//        {
//            var xs = AsyncEnumerable.FromValues(new[] { 10, 20, 30, 40, 50 });
//            var rs = xs.Where(x => true, CancellationToken.None).ToArrayAsync(CancellationToken.None).Result;
//            Assert.IsTrue(rs.Length == 5 && rs[0] == 10 && rs[1] == 20 && rs[2] == 30 && rs[3] == 40 && rs[4] == 50);
//        }
//    }

//    [TestClass]
//    public class WhereWithIndexTests
//    {
//        [TestMethod]
//        public void ThrowsWhenSourceIsNull()
//        {
//            try
//            {
//                AsyncEnumerable.Where<int>(null, (x, i) => true, CancellationToken.None);
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
//        public void EmptyWhereNone()
//        {
//            var xs = AsyncEnumerable.Empty<int>();
//            var rs = xs.Where((x, i) => false, CancellationToken.None).ToArrayAsync(CancellationToken.None).Result;
//            Assert.IsTrue(rs.Length == 0);
//        }

//        [TestMethod]
//        public void EmptyWhereAll()
//        {
//            var xs = AsyncEnumerable.Empty<int>();
//            var rs = xs.Where((x, i) => true, CancellationToken.None).ToArrayAsync(CancellationToken.None).Result;
//            Assert.IsTrue(rs.Length == 0);
//        }

//        [TestMethod]
//        public void SingleElementWhereAll()
//        {
//            var xs = AsyncEnumerable.FromValue(42);
//            var rs = xs.Where((x, i) => true, CancellationToken.None).ToArrayAsync(CancellationToken.None).Result;
//            Assert.IsTrue(rs.Length == 1 && rs[0] == 42);
//        }

//        [TestMethod]
//        public void SingleElementWhereNone()
//        {
//            var xs = AsyncEnumerable.FromValue(42);
//            var rs = xs.Where((x, i) => false, CancellationToken.None).ToArrayAsync(CancellationToken.None).Result;
//            Assert.IsTrue(rs.Length == 0);
//        }

//        [TestMethod]
//        public void MultipleElementsWhereNone()
//        {
//            var xs = AsyncEnumerable.FromValues(new[] { 10, 20, 30 });
//            var rs = xs.Where((x, i) => false, CancellationToken.None).ToArrayAsync(CancellationToken.None).Result;
//            Assert.IsTrue(rs.Length == 0);
//        }

//        [TestMethod]
//        public void MultipleElementsWhereOne()
//        {
//            var xs = AsyncEnumerable.FromValues(new[] { 10, 20, 30 });
//            var rs = xs.Where((x, i) => i == 2, CancellationToken.None).ToArrayAsync(CancellationToken.None).Result;
//            Assert.IsTrue(rs.Length == 1 && rs[0] == 30);
//        }

//        [TestMethod]
//        public void MultipleElementsWhereMultiple()
//        {
//            var xs = AsyncEnumerable.FromValues(new[] { 10, 20, 33, 44, 50 });
//            var rs = xs.Where((x, i) => i != 2 && i != 3, CancellationToken.None).ToArrayAsync(CancellationToken.None).Result;
//            Assert.IsTrue(rs.Length == 3 && rs[0] == 10 && rs[1] == 20 && rs[2] == 50);
//        }

//        [TestMethod]
//        public void MultipleElementsWhereAll()
//        {
//            var xs = AsyncEnumerable.FromValues(new[] { 10, 20, 30, 40, 50 });
//            var rs = xs.Where((x, i) => true, CancellationToken.None).ToArrayAsync(CancellationToken.None).Result;
//            Assert.IsTrue(rs.Length == 5 && rs[0] == 10 && rs[1] == 20 && rs[2] == 30 && rs[3] == 40 && rs[4] == 50);
//        }
//    }
//}
