using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System.Collections.Async
{
    internal class _AsyncEnumerableFromValues<T> : IAsyncEnumerable<T>
    {
        private IEnumerable<T> _values;

        public _AsyncEnumerableFromValues(IEnumerable<T> values) { _values = values; }

        public Task<IAsyncEnumerator<T>> GetEnumerator(CancellationToken ct)
        {
            ct.ThrowIfCancellationRequested();
            return Task.FromResult<IAsyncEnumerator<T>>(new _AsyncEnumeratorFromValues<T>(_values, ct));
        }
    }

    internal class _AsyncEnumeratorFromValues<T> : IAsyncEnumerator<T>
    {
        private CancellationToken _ct;
        private IEnumerator<T> _e;
        private Task<IMoveNextResult<T>> _finished;

        public _AsyncEnumeratorFromValues(IEnumerable<T> values, CancellationToken ct)
        {
            _e = values.GetEnumerator();
            _ct = ct;
            Status = MoveNextStatus.None;
        }

        Task<IMoveNextResult<T>> IAsyncEnumerator<T>.MoveNext(CancellationToken ct)
        {
            if (_finished != null) return _finished;
            if (_ct.IsCancellationRequested || ct.IsCancellationRequested)
            {
                _finished = Task.FromResult(MoveNext.Canceled<T>());
                Status = MoveNextStatus.Canceled;
                return _finished;
            }

            if (_e.MoveNext())
            {
                var x = Task.FromResult(MoveNext.Value(_e.Current));
                Status = MoveNextStatus.Value;
                return x;
            }
            else
            {
                _finished = Task.FromResult(MoveNext.Completed<T>());
                Status = MoveNextStatus.Completed;
                return _finished;
            }
        }

        public MoveNextStatus Status { get; private set; }

        public Exception Exception => null;

        public bool IsFrozen => Status != MoveNextStatus.None && Status != MoveNextStatus.Value;
    }
}
