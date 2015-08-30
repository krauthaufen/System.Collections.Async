using System;
using System.Collections.Async;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Examples
{
    static class Program
    {
        static void Main(string[] args)
        {
            Example1().Wait();
            //Example2().Wait();
        }

        static async Task Example1()
        {
            var work = Enumerable.Range(1, 3)
                .ToAsyncEnumerable(async x =>
                {
                    // async work ...
                    await Task.Delay(TimeSpan.FromSeconds(x));
                    return x;
                })
                .ForEach(x => Console.WriteLine("work {0}", x))
                ;

            Console.WriteLine("Example 1");

            await work;
        }

        //static async Task Example2()
        //{
        //    var work = PagedDataGenerator()
        //        .ToAsyncEnumerable()
        //        .SelectMany(x => x)
        //        .TakeFor(TimeSpan.FromSeconds(5))
        //        .Where(x => x % 5 == 0)
        //        .ForEachAsync(Console.WriteLine)
        //        ;

        //    Console.WriteLine("Example 2");

        //    await work;
        //}


        static IEnumerable<Task<int[]>> PagedDataGenerator()
        {
            var r = new Random();
            while (true)
            {
                yield return Task
                    .Delay(TimeSpan.FromSeconds(r.NextDouble()))
                    .ContinueWith(_ =>
                    {
                        var xs = new int[10];
                        for (var i = 0; i < 10; i++) xs[i] = r.Next(100);
                        return xs;
                    })
                    ;
            }
        }

    }
}
