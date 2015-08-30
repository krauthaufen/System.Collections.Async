using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System.Collections.Async
{
    public enum MoveNextStatus
    {
        Cancelled,
        Completed,
        Faulted,
        Value,
    }

    public interface IMoveNextResult<T>
    {
        T Value { get; }

        Exception Exception { get; }

        MoveNextStatus Status { get; }

        bool IsCancelled { get; }
        bool IsCompleted { get; }
        bool IsFaulted { get; }
        bool IsValue { get; }

        void ThrowIfCancelledOrFaulted();
    }

    internal static class MoveNext
    {
        public static IMoveNextResult<T> Cancelled<T>()
        {
            return new MoveNextCancelled<T>();
        }
        public static IMoveNextResult<T> Completed<T>()
        {
            return new MoveNextCompleted<T>();
        }
        public static IMoveNextResult<T> Faulted<T>(Exception e)
        {
            return new MoveNextException<T>(e);
        }
        public static IMoveNextResult<T> Value<T>(T x)
        {
            return new MoveNextValue<T>(x);
        }
        public static IMoveNextResult<R> Convert<T, R>(IMoveNextResult<T> x)
        {
            switch (x.Status)
            {
                case MoveNextStatus.Cancelled:
                    return Cancelled<R>();
                case MoveNextStatus.Completed:
                    return Completed<R>();
                case MoveNextStatus.Faulted:
                    return Faulted<R>(x.Exception);
                case MoveNextStatus.Value:
                    throw new InvalidOperationException();
                default:
                    throw new NotImplementedException();
            }
        }

        private class MoveNextCancelled<T> : IMoveNextResult<T>
        {
            public T Value { get { throw new InvalidOperationException(); } }

            public Exception Exception => null;

            public MoveNextStatus Status => MoveNextStatus.Cancelled;

            public bool IsCancelled => true;
            public bool IsCompleted => false;
            public bool IsFaulted => false;
            public bool IsValue => false;

            public void ThrowIfCancelledOrFaulted()
            {
                throw new OperationCanceledException();
            }
        }
        private class MoveNextCompleted<T> : IMoveNextResult<T>
        {
            public T Value { get { throw new InvalidOperationException(); } }

            public Exception Exception => null;

            public MoveNextStatus Status => MoveNextStatus.Completed;

            public bool IsCancelled => false;
            public bool IsCompleted => true;
            public bool IsFaulted => false;
            public bool IsValue => false;

            public void ThrowIfCancelledOrFaulted()
            {
            }
        }
        private class MoveNextException<T> : IMoveNextResult<T>
        {
            public MoveNextException(Exception e)
            {
                Exception = e;
            }

            public T Value { get { throw new InvalidOperationException(); } }

            public Exception Exception { get; }

            public MoveNextStatus Status => MoveNextStatus.Faulted;

            public bool IsCancelled => false;
            public bool IsCompleted => false;
            public bool IsFaulted => true;
            public bool IsValue => false;

            public void ThrowIfCancelledOrFaulted()
            {
                throw Exception;
            }
        }
        private class MoveNextValue<T> : IMoveNextResult<T>
        {
            public MoveNextValue(T x)
            {
                Value = x;
            }

            public T Value { get; }

            public Exception Exception => null;

            public MoveNextStatus Status => MoveNextStatus.Value;

            public bool IsCancelled => false;
            public bool IsCompleted => false;
            public bool IsFaulted => false;
            public bool IsValue => true;

            public void ThrowIfCancelledOrFaulted()
            {
            }
        }
    }
    

    public interface IAsyncEnumerator<T>
    {
        /// <summary>
        /// Asynchronously advances the enumerator to the next element of the collection.
        /// </summary>
        Task<IMoveNextResult<T>> MoveNext(CancellationToken ct);
    }
}
