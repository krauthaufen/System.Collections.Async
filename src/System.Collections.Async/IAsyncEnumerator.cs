using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System.Collections.Async
{
    public interface IAsyncEnumerator<T>
    {
        /// <summary>
        /// Asynchronously returns the next element of the sequence.
        /// </summary>
        Task<IMoveNextResult<T>> MoveNext(CancellationToken ct);

        /// <summary>
        /// Gets current status of stream.
        /// </summary>
        MoveNextStatus Status { get; }

        /// <summary>
        /// Contains exception if status is Faulted, null otherwise.
        /// </summary>
        Exception Exception { get; }
    }

    public enum MoveNextStatus
    {
        Canceled,
        Completed,
        Faulted,
        Value,
        None,
    }

    public interface IMoveNextResult<T>
    {
        T Value { get; }

        Exception Exception { get; }

        MoveNextStatus Status { get; }

        bool IsCanceled { get; }
        bool IsCompleted { get; }
        bool IsFaulted { get; }
        bool IsValue { get; }
        bool IsNone { get; }

        void ThrowIfCanceledOrFaulted();
    }

    internal static class MoveNext
    {
        public static IMoveNextResult<T> None<T>()
        {
            return new MoveNextNone<T>();
        }
        public static IMoveNextResult<T> Canceled<T>()
        {
            return new MoveNextCanceled<T>();
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
                case MoveNextStatus.Canceled:
                    return Canceled<R>();
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

        private class MoveNextNone<T> : IMoveNextResult<T>
        {
            public T Value { get { throw new InvalidOperationException("Can't get value from stream in state 'None'."); } }

            public Exception Exception => null;

            public MoveNextStatus Status => MoveNextStatus.None;

            public bool IsCanceled => false;
            public bool IsCompleted => false;
            public bool IsFaulted => false;
            public bool IsValue => false;
            public bool IsNone => true;

            public void ThrowIfCanceledOrFaulted()
            {
            }

            public override string ToString()
            {
                return $"MoveNextNone<{typeof(T)}>()";
            }
        }
        private class MoveNextCanceled<T> : IMoveNextResult<T>
        {
            public T Value { get { throw new OperationCanceledException(); } }

            public Exception Exception => null;

            public MoveNextStatus Status => MoveNextStatus.Canceled;

            public bool IsCanceled => true;
            public bool IsCompleted => false;
            public bool IsFaulted => false;
            public bool IsValue => false;
            public bool IsNone => false;

            public void ThrowIfCanceledOrFaulted()
            {
                throw new OperationCanceledException();
            }

            public override string ToString()
            {
                return $"MoveNextCanceled<{typeof(T)}>()";
            }
        }
        private class MoveNextCompleted<T> : IMoveNextResult<T>
        {
            public T Value { get { throw new InvalidOperationException(); } }

            public Exception Exception => null;

            public MoveNextStatus Status => MoveNextStatus.Completed;

            public bool IsCanceled => false;
            public bool IsCompleted => true;
            public bool IsFaulted => false;
            public bool IsValue => false;
            public bool IsNone => false;

            public void ThrowIfCanceledOrFaulted()
            {
            }

            public override string ToString()
            {
                return $"MoveNextCompleted<{typeof(T)}>()";
            }
        }
        private class MoveNextException<T> : IMoveNextResult<T>
        {
            public MoveNextException(Exception e)
            {
                Exception = e;
            }

            public T Value { get { throw new InvalidOperationException("Can't get value from faulted stream.", Exception); } }

            public Exception Exception { get; }

            public MoveNextStatus Status => MoveNextStatus.Faulted;

            public bool IsCanceled => false;
            public bool IsCompleted => false;
            public bool IsFaulted => true;
            public bool IsValue => false;
            public bool IsNone => false;

            public void ThrowIfCanceledOrFaulted()
            {
                throw Exception;
            }

            public override string ToString()
            {
                return $"MoveNextException<{typeof(T)}>({Exception})";
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

            public bool IsCanceled => false;
            public bool IsCompleted => false;
            public bool IsFaulted => false;
            public bool IsValue => true;
            public bool IsNone => false;

            public void ThrowIfCanceledOrFaulted()
            {
            }

            public override string ToString()
            {
                return $"MoveNextValue<{typeof(T)}>({Value})";
            }
        }
    }
}
