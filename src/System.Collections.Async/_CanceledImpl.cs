using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System.Collections.Async
{
    internal class _CanceledEnumerable<T> : IAsyncEnumerable<T>
    {
        public static readonly IAsyncEnumerable<T> Default = new _CanceledEnumerable<T>();

        public Task<IAsyncEnumerator<T>> GetEnumerator(CancellationToken ct)
        {
            return Task.FromResult(_CanceledEnumerator<T>.Default);
        }
    }
    internal class _CanceledEnumerator<T> : IAsyncEnumerator<T>
    {
        public static readonly IAsyncEnumerator<T> Default = new _CanceledEnumerator<T>();

        private static readonly Task<IMoveNextResult<T>> _result = Task.FromResult(MoveNext<T>.Canceled);

        Task<IMoveNextResult<T>> IAsyncEnumerator<T>.MoveNext(CancellationToken ct)
        {
            return _result;
        }

        public MoveNextStatus Status => MoveNextStatus.Canceled;

        public Exception Exception => null;
    }
}
