using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System.Collections.Async.Tests
{
    internal static class Helper
    {
        public static CancellationToken CANCELLED;

        static Helper()
        {
            var cts = new CancellationTokenSource();
            cts.Cancel();
            CANCELLED = cts.Token;
        }
    }
}
