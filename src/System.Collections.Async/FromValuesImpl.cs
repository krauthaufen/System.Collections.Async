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
        private IMoveNextResult<T> _finished;

        public _AsyncEnumeratorFromValues(IEnumerable<T> values, CancellationToken ct)
        {
            _e = values.GetEnumerator();
            _ct = ct;
        }

        Task<IMoveNextResult<T>> IAsyncEnumerator<T>.MoveNext(CancellationToken ct)
        {
            if (_finished != null) return Task.FromResult(_finished);
            if (_ct.IsCancellationRequested || ct.IsCancellationRequested)
            {
                _finished = MoveNext.Cancelled<T>();
                return Task.FromResult(_finished);
            }

            if (_e.MoveNext())
            {
                return Task.FromResult(MoveNext.Value(_e.Current));
            }
            else
            {
                _finished = MoveNext.Completed<T>();
                return Task.FromResult(_finished);
            }
        }
    }
}
