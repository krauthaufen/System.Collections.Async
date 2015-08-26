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
        public static IAsyncEnumerable<int> RangeAsync(int start, int count, CancellationToken ct = default(CancellationToken))
        {
            ct.ThrowIfCancellationRequested();
            if (count < 0) throw new ArgumentOutOfRangeException("count");
            if ((long)start + count - 1 > int.MaxValue) throw new ArgumentOutOfRangeException("start + count - 1");

            return new _AsyncEnumerable<int>(ct2 =>
            {
                ct2.ThrowIfCancellationRequested();
                var i = (long)start;
                var iMax = (long)start + count;
                return new _AsyncEnumerator<int>(() =>
                {
                    ct2.ThrowIfCancellationRequested();
                    if (i < iMax)
                    {
                        return Task.FromResult(Tuple.Create((int)i++, true));
                    }
                    else
                    {
                        return Task.FromResult(Tuple.Create(0, false));
                    }
                });
            });
        }
    }
}
