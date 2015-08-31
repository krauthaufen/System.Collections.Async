using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System.Collections.Async
{
    internal class _EmptyEnumerable<T> : IAsyncEnumerable<T>
    {
        public static readonly IAsyncEnumerable<T> Default = new _EmptyEnumerable<T>();

        public Task<IAsyncEnumerator<T>> GetEnumerator(CancellationToken ct)
        {
            return Task.FromResult(_EmptyEnumerator<T>.Default);
        }
    }
    internal class _EmptyEnumerator<T> : IAsyncEnumerator<T>
    {
        public static readonly IAsyncEnumerator<T> Default = new _EmptyEnumerator<T>();

        private static readonly Task<IMoveNextResult<T>> _result = Task.FromResult(MoveNext.Completed<T>());

        Task<IMoveNextResult<T>> IAsyncEnumerator<T>.MoveNext(CancellationToken ct)
        {
            return _result;
        }

        public MoveNextStatus Status => MoveNextStatus.Completed;

        public Exception Exception => null;
    }
}
