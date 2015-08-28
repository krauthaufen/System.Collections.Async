using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System.Collections.Async
{
    public static partial class AsyncEnumerable
    {
        public static IAsyncEnumerable<TResult> Repeat<TResult>(TResult element, int count, CancellationToken ct = default(CancellationToken))
        {
            if (count < 0) throw new ArgumentOutOfRangeException("count");

            return new _AsyncEnumerable<TResult>(ct2 =>
            {
                ct2.ThrowIfCancellationRequested();
                var i = 0L;
                return new _AsyncEnumerator<TResult>(() =>
                {
                    ct2.ThrowIfCancellationRequested();
                    if (i++ < count)
                    {
                        return Task.FromResult(Tuple.Create(element, true));
                    }
                    else
                    {
                        return Task.FromResult(Tuple.Create(default(TResult), false));
                    }
                });
            });
        }
    }
}
