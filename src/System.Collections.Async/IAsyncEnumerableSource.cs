using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System.Collections.Async
{
    public interface IAsyncEnumerableSource<T> : IAsyncEnumerable<T>
    {
        Task Yield(T value);
        Task Break();
        int SubscribersCount { get; }
    }
}
