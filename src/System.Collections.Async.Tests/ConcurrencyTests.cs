using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace System.Collections.Async.Tests
{
    [TestClass]
    public class ConcurrencyTests
    {
        [TestMethod]
        public void ConcurrentEmitsReachForEach()
        {
            var count = 100;
            var howOften = 1000;

            var source = AsyncEnumerable.Source<int>();
            var evt = new ManualResetEventSlim();
            var sem = new SemaphoreSlim(0);

            var derived = source.Select(i => i).Where(i => true);

            var values = new HashSet<int>();
            var subscription = source.ForEach(i =>
            {
                lock (values)
                {
                    values.Add(i);
                }
            });


            for (int i = 0; i < count; i++)
            {
                var id = i;
                var t = new Thread(() =>
                {
                    evt.Wait();
                    for(int x = 0; x < howOften; x++)
                        source.Yield(id).Wait();
                    sem.Release();
                });
                t.IsBackground = true;
                t.Start();
            }

            evt.Set();

            for (int i = 0; i < count; i++)
                sem.Wait();

            var arr = values.OrderBy(a => a).ToArray();

            Assert.AreEqual(count, arr.Length, "not all inputs processed");

            for (int i = 0; i < count; i++)
            {
                Assert.AreEqual(i, arr[i]);
            }



        }
    }
}