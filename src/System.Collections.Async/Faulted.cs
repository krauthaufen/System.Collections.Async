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
        public static IAsyncEnumerable<T> Faulted<T>(Exception e)
        {
            return new _FaultedEnumerable<T>(e);
        }
    }
}
