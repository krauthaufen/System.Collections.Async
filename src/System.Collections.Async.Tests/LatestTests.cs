using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Collections.Async.Tests
{
    [TestClass]
    public class LatestTests
    {
        [TestMethod]
        public void LatestOfEmpty()
        {
            var source = AsyncEnumerable.Empty<int>();
            var latest = source.Latest();
            Assert.IsTrue(latest.Item.IsCompleted);
        }

        [TestMethod]
        public void LatestOfCanceled()
        {
            var source = AsyncEnumerable.Canceled<int>();
            var latest = source.Latest();
            Assert.IsTrue(latest.Item.IsCanceled);
        }

        [TestMethod]
        public void LatestOfFaulted()
        {
            var source = AsyncEnumerable.Faulted<int>(new Exception("Test"));
            var latest = source.Latest();
            Assert.IsTrue(latest.Item.IsFaulted);
        }

        [TestMethod]
        public void LatestOfSource()
        {
            var source = AsyncEnumerable.Source<int>();
            var latest = source.Latest();

            var step = new ManualResetEventSlim(false);
            var proceed = new ManualResetEventSlim(false);

            Assert.IsTrue(latest.Item.IsNone, $"(0) {latest.Item}");

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
            Assert.IsTrue(latest.Item.Value == 1, $"(1) {latest.Item}");
            proceed.Set();

            step.Wait(); step.Reset();
            Assert.IsTrue(latest.Item.Value == 2, $"(2) {latest.Item}");
            proceed.Set();

            step.Wait(); step.Reset();
            Assert.IsTrue(latest.Item.IsCompleted, $"(3) {latest.Item}");
            proceed.Set();
        }
    }
}
