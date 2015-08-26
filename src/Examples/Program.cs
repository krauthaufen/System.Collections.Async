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
        }

        static async Task Example1()
        {
            var work = Enumerable.Range(1, 5)
                .ToAsyncEnumerable(async x =>
                {
                    await Task.Delay(TimeSpan.FromSeconds(x));
                    return x;
                })
                .ForEachAsync(x => Console.WriteLine("work {0}", x), CancellationToken.None)
                ;

            Console.WriteLine("doing something else");

            await work;
        }
    }
}
