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
    }

    public class MoveNextCancelled<T> : IMoveNextResult<T>
    {
        public T Value { get { throw new InvalidOperationException(); } }

        public Exception Exception => null;

        public MoveNextStatus Status => MoveNextStatus.Cancelled;

        public bool IsCancelled => true;
        public bool IsCompleted => false;
        public bool IsFaulted => false;
        public bool IsValue => false;
    }
    public class MoveNextCompleted<T> : IMoveNextResult<T>
    {
        public T Value { get { throw new InvalidOperationException(); } }

        public Exception Exception => null;

        public MoveNextStatus Status => MoveNextStatus.Completed;

        public bool IsCancelled => false;
        public bool IsCompleted => true;
        public bool IsFaulted => false;
        public bool IsValue => false;
    }
    public class MoveNextException<T> : IMoveNextResult<T>
    {
        public T Value { get { throw new InvalidOperationException(); } }

        public Exception Exception { get; }

        public MoveNextStatus Status => MoveNextStatus.Faulted;

        public bool IsCancelled => false;
        public bool IsCompleted => false;
        public bool IsFaulted => true;
        public bool IsValue => false;
    }
    public class MoveNextValue<T> : IMoveNextResult<T>
    {
        public T Value { get; }

        public Exception Exception => null;

        public MoveNextStatus Status => MoveNextStatus.Value;

        public bool IsCancelled => false;
        public bool IsCompleted => false;
        public bool IsFaulted => false;
        public bool IsValue => true;
    }
    

    public interface IAsyncEnumerator<T>
    {
        /// <summary>
        /// Asynchronously advances the enumerator to the next element of the collection.
        /// </summary>
        Task<IMoveNextResult<T>> MoveNext(CancellationToken ct);
    }
}
