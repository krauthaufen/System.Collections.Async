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

    public static partial class AsyncEnumerable
    {
        public static IAsyncEnumerableSource<T> Source<T>()
        {
            return new _AsyncEnumerableSource<T>();
        }
    }

    internal class _AsyncEnumerableSource<T> : IAsyncEnumerableSource<T>
    {
        private class _Enumerator : IAsyncEnumerator<T>
        {
            private _AsyncEnumerableSource<T> _parent;

            public _Enumerator(_AsyncEnumerableSource<T> parent)
            {
                _parent = parent;
            }

            public T Current
            {
                get
                {
                    if (_parent._isCompleted) throw new InvalidOperationException();
                    return _parent._current;
                }
            }

            public Task<bool> MoveNext(CancellationToken ct)
            {
                return _parent._moveNext.Task;
            }
        }

        public _AsyncEnumerableSource()
        {
            _enumerator = Task.FromResult<IAsyncEnumerator<T>>(new _Enumerator(this));
        }

        private SemaphoreSlim _semaphore = new SemaphoreSlim(1);
        private Task<IAsyncEnumerator<T>> _enumerator;
        private int _subscribersCount = 0;
        private bool _isCompleted = false;

        private T _current;
        private TaskCompletionSource<bool> _moveNext = new TaskCompletionSource<bool>();
        private readonly Task DONE = Task.FromResult(0);

        public async Task Yield(T value)
        {
            try
            {
                await _semaphore.WaitAsync();

                if (_subscribersCount == 0 || _isCompleted) return;

                var moveNext = _moveNext;
                _moveNext = new TaskCompletionSource<bool>();

                _current = value;
                moveNext.SetResult(true);
            }
            finally
            {
                _semaphore.Release();
            }
        }

        public async Task Break()
        {
            try
            {
                await _semaphore.WaitAsync();

                if (_isCompleted) return;
                _isCompleted = true;

                _current = default(T);
                _moveNext.SetResult(false);
            }
            finally
            {
                _semaphore.Release();
            }
        }

        public int SubscribersCount => _subscribersCount;

        public Task<IAsyncEnumerator<T>> GetEnumerator(CancellationToken ct)
        {
            ct.ThrowIfCancellationRequested();

            Interlocked.Increment(ref _subscribersCount);
            return _enumerator;
        }
    }

    /// <summary>
    /// Implementation based on
    /// http://blogs.msdn.com/b/dotnet/archive/2013/04/04/net-memory-allocation-profiling-with-visual-studio-2012.aspx
    /// http://blogs.msdn.com/b/pfxteam/archive/2012/10/05/how-do-i-cancel-non-cancelable-async-operations.aspx
    /// </summary>
    internal static class TaskWithCancellationExtensions
    {
        /// <summary>
        /// Creates a task that completes (or cancels) when either the input task completes or the cancellation token is signalled.
        /// On cancellation, the original task still runs to completion because there is no way to preemptively cancel it.
        /// </summary>
        public static Task<T> WithCancellation<T>(this Task<T> task, CancellationToken ct)
        {
            if (task.IsCompleted || !ct.CanBeCanceled)
                return task;
            else if (ct.IsCancellationRequested)
                return new Task<T>(() => default(T), ct);
            else
                return task.WithCancellationInternal(ct);
        }

        /// <summary>
        /// Creates a task that completes (or cancels) when either the input task completes or the cancellation token is signalled.
        /// On cancellation, the original task still runs to completion because there is no way to preemptively cancel it.
        /// </summary>
        public static Task<T> WithCancellation<T>(this Task<T> task, CancellationToken? ct)
        {
            if (task.IsCompleted || !ct.HasValue || !ct.Value.CanBeCanceled)
                return task;
            else if (ct.Value.IsCancellationRequested)
                return new Task<T>(() => default(T), ct.Value);
            else
                return task.WithCancellationInternal(ct.Value);
        }


        private static readonly Action<object> s_cancellationRegistration =
            s => ((TaskCompletionSource<bool>)s).TrySetResult(true);

        private static async Task<T> WithCancellationInternal<T>(this Task<T> task, CancellationToken ct)
        {
            var tcs = new TaskCompletionSource<bool>();
            using (ct.Register(s_cancellationRegistration, tcs))
            {
                if (task != await Task.WhenAny(task, tcs.Task))
                {
                    throw new TaskCanceledException(task);
                }
            }
            return await task;
        }
    }
}
