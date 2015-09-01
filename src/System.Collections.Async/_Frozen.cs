using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System.Collections.Async
{
    internal static class FrozenEnumerable<T>
    {
        public static readonly IAsyncEnumerable<T> Canceled = new _FrozenEnumerable<T>(FrozenEnumerator<T>.Canceled);

        public static readonly IAsyncEnumerable<T> Completed = new _FrozenEnumerable<T>(FrozenEnumerator<T>.Completed);

        public static IAsyncEnumerable<T> Faulted(Exception e)
        {
            return new _FrozenEnumerable<T>(FrozenEnumerator<T>.Faulted(e));
        }
    }

    internal class _FrozenEnumerable<T> : IAsyncEnumerable<T>
    {
        private Task<IAsyncEnumerator<T>> _enumerator;

        public _FrozenEnumerable(IAsyncEnumerator<T> enumerator)
        {
            if (enumerator == null) throw new ArgumentNullException(nameof(enumerator));
            _enumerator = Task.FromResult(enumerator);
        }

        public Task<IAsyncEnumerator<T>> GetEnumerator(CancellationToken ct)
        {
            return _enumerator;
        }
    }

    internal static class FrozenEnumerator<T>
    {
        public static readonly IAsyncEnumerator<T> Canceled = new _FrozenEnumerator<T>(MoveNext.Canceled<T>());

        public static readonly IAsyncEnumerator<T> Completed = new _FrozenEnumerator<T>(MoveNext.Completed<T>());

        public static IAsyncEnumerator<T> Faulted(Exception e)
        {
            return new _FrozenEnumerator<T>(MoveNext.Faulted<T>(e));
        }
    }

    internal class _FrozenEnumerator<T> : IAsyncEnumerator<T>
    {
        private Task<IMoveNextResult<T>> _item;

        public _FrozenEnumerator(IMoveNextResult<T> item)
        {
            _item = Task.FromResult(item);
        }

        public Exception Exception => _item.Result.IsFaulted ? _item.Result.Exception : null;

        public bool IsFrozen => true;

        public MoveNextStatus Status => _item.Result.Status;

        public Task<IMoveNextResult<T>> MoveNext(CancellationToken ct)
        {
            return _item;
        }
    }
}
