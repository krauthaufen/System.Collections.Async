using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Collections.Async.Tests
{
    [TestClass]
    public class NextTests
    {
        [TestMethod]
        public void ThrowsIfSourceIsNull()
        {
            TestHelpers.ThrowsAggregateArgumentNullException(() =>
                AsyncEnumerable.Next<int>(null).Wait()
                );
        }

        [TestMethod]
        public void ThrowsIfSourceIsEmpty()
        {
            TestHelpers.ThrowsAggregateInvalidOperationException(() =>
                AsyncEnumerable.Empty<int>().Next().Wait()
                );
        }

        [TestMethod]
        public void ThrowsIfSourceIsCanceled()
        {
            TestHelpers.ThrowsAggregateTaskCanceledException(() =>
                AsyncEnumerable.Canceled<int>().Next().Wait()
                );
        }

        [TestMethod]
        public void ThrowsIfSourceIsFaulted()
        {
            TestHelpers.ThrowsAggregateTestException(() =>
                AsyncEnumerable.Faulted<int>(new Exception("Test")).Next().Wait()
                );
        }

        [TestMethod]
        public void NextOfSource()
        {
            var source = AsyncEnumerable.Source<int>();
            var next = source.Next();

            var step = new ManualResetEventSlim(false);
            var proceed = new ManualResetEventSlim(false);
            
            var t = Task.Run(async () =>
            {
                await source.Yield(1);
                await Task.Yield();
                step.Set();
                proceed.Wait(); proceed.Reset();

                await source.Yield(2);
                await Task.Yield();
                step.Set();
                proceed.Wait(); proceed.Reset();

                await source.Break();
                await Task.Yield();
                step.Set();
                proceed.Wait(); proceed.Reset();
            });

            step.Wait(); step.Reset();
            Assert.IsTrue(next.Result == 1, $"(1) {next.Result}");
            next = source.Next();
            proceed.Set();

            step.Wait(); step.Reset();
            Assert.IsTrue(next.Result == 2, $"(2) {next.Result}");
            next = source.Next();
            proceed.Set();

            step.Wait(); step.Reset();
        }
    }
}
