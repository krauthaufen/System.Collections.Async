using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System.Collections.Async
{
    internal class _FaultedEnumerable<T> : IAsyncEnumerable<T>
    {
        private Task<IAsyncEnumerator<T>> _enumerator;

        public _FaultedEnumerable(Exception e)
        {
            _enumerator = Task.FromResult<IAsyncEnumerator<T>>(new _FaultedEnumerator<T>(e));
        }

        public Task<IAsyncEnumerator<T>> GetEnumerator(CancellationToken ct)
        {
            return _enumerator;
        }
    }
    internal class _FaultedEnumerator<T> : IAsyncEnumerator<T>
    {
        private Task<IMoveNextResult<T>> _result;

        public _FaultedEnumerator(Exception e)
        {
            Exception = e;
            _result = Task.FromResult(MoveNext.Faulted<T>(e));
        }

        Task<IMoveNextResult<T>> IAsyncEnumerator<T>.MoveNext(CancellationToken ct)
        {
            return _result;
        }

        public MoveNextStatus Status => MoveNextStatus.Faulted;

        public Exception Exception { get; }
    }
}
