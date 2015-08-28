using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Collections.Async
{
    public static partial class AsyncEnumerable
    {
        /// <summary>
        /// Generator is an async function taking a yield return function.
        /// </summary>
        public static IAsyncEnumerable<TResult> Generate<TResult>(Func<Func<TResult, Task>, Task> generator)
        {
            return new _AsyncEnumerable<TResult>(ct =>
            {
                ct.ThrowIfCancellationRequested();

                var yieldReturn = new TaskCompletionSource<TResult>();
                var yieldReturnConsumed = new TaskCompletionSource<bool>();
                
                var yieldBreak = generator(async x =>
                {
                    yieldReturn.SetResult(x);
                    await yieldReturnConsumed.Task;
                });

                return new _AsyncEnumerator<TResult>(async () =>
                {
                    ct.ThrowIfCancellationRequested();
                    
                    if (await Task.WhenAny(yieldReturn.Task, yieldBreak) == yieldBreak)
                    {
                        return Tuple.Create(default(TResult), false);
                    }

                    var x = yieldReturn.Task.Result;
                    var xConsumed = yieldReturnConsumed;

                    yieldReturn = new TaskCompletionSource<TResult>();
                    yieldReturnConsumed = new TaskCompletionSource<bool>();

                    xConsumed.SetResult(true);

                    return Tuple.Create(x, true);
                });
            });
        }
    }
}
