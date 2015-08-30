using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Collections.Async.Tests
{
    [TestClass]
    public class RaceConditionTests
    {
        private IAsyncEnumerable<int> CreateInTask()
        {
            var result = AsyncEnumerable.Source<int>();

            Task.Run(async () =>
            {
                while (result.SubscribersCount == 0) await Task.Yield();

                for (var i = 0; i < 100; i++)
                {
                    await result.Yield(1);
                }
                await result.Break();
            });

            return result;
        }

        [TestMethod]
        public void Race1()
        {
            var result = CreateInTask().SumAsync(x => x).Result;
            Assert.IsTrue(result == 100, $"{result} == 100");
        }

        [TestMethod]
        public void Race2()
        {
            var result = CreateInTask().ToListAsync().Result;
            Assert.IsTrue(result.Count == 100, $"{result} == 100");
        }
    }
}
