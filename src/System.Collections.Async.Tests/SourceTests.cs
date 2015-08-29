using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Collections.Async.Tests
{
    [TestClass]
    public class SourceTests
    {
        private CancellationToken CANCELLED
        {
            get
            {
                var cts = new CancellationTokenSource();
                cts.Cancel();
                return cts.Token;
            }
        }


        [TestMethod]
        public void CanCreateSource()
        {
            AsyncEnumerable.Source<int>();
        }

        [TestMethod]
        public void NewlyCreatedSourceHasNoSubscribers()
        {
            Assert.IsTrue(AsyncEnumerable.Source<int>().SubscribersCount == 0);
        }

        [TestMethod]
        public void CanGetEnumerator()
        {
            AsyncEnumerable.Source<int>().GetEnumerator(CancellationToken.None).Wait();
        }

        [TestMethod]
        public void GetEnumeratorThrowsWhenCancelled()
        {
            try
            {
                AsyncEnumerable.Source<int>().GetEnumerator(CANCELLED).Wait();
                Assert.Fail();
            }
            catch (OperationCanceledException)
            {
            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void CurrentThrowsWhenEndOfSequence()
        {
            try
            {
                var source = AsyncEnumerable.Source<int>();

                var e = source.GetEnumerator(CancellationToken.None).Result;

                var moveNext1 = e.MoveNext(CancellationToken.None);

                source.Yield(42).Wait();

                Assert.IsTrue(moveNext1.Result == true);
                Assert.IsTrue(e.Current == 42);

                var moveNext2 = e.MoveNext(CancellationToken.None);

                source.Break().Wait();

                Assert.IsTrue(moveNext2.Result == false);

                // this should fail with InvalidOperationException
                var x = e.Current;
                Assert.Fail();
            }
            catch (InvalidOperationException)
            {
            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void SubscribersCountIsOneAfterGetEnumeratorIsCalledOnce()
        {
            var source = AsyncEnumerable.Source<int>();
            source.GetEnumerator(CancellationToken.None).Wait();
            Assert.IsTrue(source.SubscribersCount == 1);
        }

        [TestMethod]
        public void SubscribersCountIsTwoAfterGetEnumeratorIsCalledTwice()
        {
            var source = AsyncEnumerable.Source<int>();
            source.GetEnumerator(CancellationToken.None).Wait();
            source.GetEnumerator(CancellationToken.None).Wait();
            Assert.IsTrue(source.SubscribersCount == 2);
        }
        
        [TestMethod]
        public void CanBreakSourceWithZeroEnumerators()
        {
            var source = AsyncEnumerable.Source<int>();
            source.Break().Wait();
        }

        [TestMethod]
        public void CanBreakSourceWithOneEnumerator()
        {
            var source = AsyncEnumerable.Source<int>();
            var count1 = source.CountAsync(); // enumerator 1

            source.Break().Wait();
            Assert.IsTrue(count1.Result == 0);
        }

        [TestMethod]
        public void CanBreakSourceWithTwoEnumerators()
        {
            var source = AsyncEnumerable.Source<int>();
            var count1 = source.CountAsync(); // enumerator 1
            var count2 = source.CountAsync(); // enumerator 2

            source.Break().Wait();
            Assert.IsTrue(count1.Result == 0);
            Assert.IsTrue(count2.Result == 0);
        }

        [TestMethod]
        public void CanYieldSourceWithZeroEnumerators()
        {
            var source = AsyncEnumerable.Source<int>();

            source.Yield(42).Wait();
        }

        [TestMethod]
        public void CanYieldSourceWithOneEnumerator()
        {
            var source = AsyncEnumerable.Source<int>();
            var count1 = source.CountAsync(); // enumerator 1

            source.Yield(42).Wait();
        }

        [TestMethod]
        public void CanYieldSourceWithTwoEnumerators()
        {
            var source = AsyncEnumerable.Source<int>();
            var count1 = source.CountAsync(); // enumerator 1
            var count2 = source.CountAsync(); // enumerator 2

            source.Yield(42).Wait();
        }

        [TestMethod]
        public void CanYieldAndBreakSourceWithZeroEnumerators()
        {
            var source = AsyncEnumerable.Source<int>();

            source.Yield(42).Wait();
            source.Break().Wait();
        }

        [TestMethod]
        public void CanYieldAndBreakSourceWithOneEnumerator()
        {
            var source = AsyncEnumerable.Source<int>();
            var count1 = source.CountAsync(); // enumerator 1

            source.Yield(42).Wait();
            source.Break().Wait();

            Assert.IsTrue(count1.Result == 1);
        }

        [TestMethod]
        public void CanYieldAndBreakSourceWithTwoEnumerators()
        {
            var source = AsyncEnumerable.Source<int>();
            var count1 = source.CountAsync(); // enumerator 1
            var count2 = source.CountAsync(); // enumerator 2

            source.Yield(42).Wait();
            source.Break().Wait();

            Assert.IsTrue(count1.Result == 1);
            Assert.IsTrue(count2.Result == 1);
        }

        [TestMethod]
        public void YieldElementsFromTask()
        {
            var source = AsyncEnumerable.Source<int>();
            var sum = source.SumAsync();

            Task.Run(() =>
            {
                for (var i = 0; i <= 5; i++) source.Yield(i);
                source.Break();
            });

            Assert.IsTrue(sum.Result == 15, $"{sum.Result} == 15");
        }

        [TestMethod]
        public void SecondEnumeratorComesInLater()
        {
            var source = AsyncEnumerable.Source<int>();

            var sum1 = source.SumAsync(); // enumerator 1

            source.Yield(1).Wait();
            source.Yield(2).Wait();

            var sum2 = source.SumAsync(); // enumerator 2

            source.Yield(4).Wait();
            source.Yield(8).Wait();

            source.Break().Wait();

            Assert.IsTrue(sum1.Result == 15);
            Assert.IsTrue(sum2.Result == 12);
        }

        [TestMethod]
        public void RaceTest1()
        {
            var source = AsyncEnumerable.Source<int>();

            var count1 = source.CountAsync(); // enumerator 1

            var t1 = Task.Run(() =>
            {
                for (var i = 0; i < 1000; i++) source.Yield(i);
            });

            var t2 = Task.Run(() =>
            {
                for (var i = 0; i < 1000; i++) source.Yield(i);
            });

            Task.WaitAll(t1, t2);
            source.Break().Wait();

            Assert.IsTrue(count1.Result == 2000, $"{count1.Result} == 2000");
        }
    }
}
