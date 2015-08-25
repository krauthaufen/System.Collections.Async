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
        public static IAsyncEnumerable<T> FromValue<T>(T value)
        {
            return new _AsyncEnumerableFromValues<T>(new[] { value });
        }

        public static IAsyncEnumerable<T> FromValues<T>(IEnumerable<T> values)
        {
            return new _AsyncEnumerableFromValues<T>(values);
        }
    }
}
