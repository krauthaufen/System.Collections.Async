# System.Collections.Async

An implementation of async enumerables including many LINQ operators.

## Interfaces
The async version of IEnumerable's GetEnumerator can be awaited and takes a cancellation token.
For example, the enumerator may represent items stored in a distributed or cloud-based system.
Its creation may take some time due to network or authentication overhead.
```c#
namespace System.Collections.Async
{
    public interface IAsyncEnumerable<T>
    {
        /// <summary>
        /// Asynchronously gets enumerator.
        /// </summary>
        Task<IAsyncEnumerator<T>> GetEnumerator(CancellationToken ct);
    }
```
The async version of IEnumerator's MoveNext also can be awaited and cancelled.
Imagine iterating over a collection of large files where a call to MoveNext triggers the next file to be read from disk.

```c#
    public interface IAsyncEnumerator<out T>
    {
        /// <summary>
        /// Gets the current element in the collection.
        /// </summary>
        T Current { get; }

        /// <summary>
        /// Asynchronously advances the enumerator to the next element of the collection.
        /// Returns true if the enumerator successfully advanced to the next element;
        /// false if it passed the end of the collection.
        /// </summary>
        Task<bool> MoveNext(CancellationToken ct);
    }
}
```

## Operators
The following operators are implemented:
* Aggregate
* All
* Any
* Concat
* Contains
* Count
* DefaultIfEmpty
* Distinct
* ElementAt
* ElementAtOrDefault
* Empty
* Except
* First
* FirstOrDefault
* ForEach
* FromValue
* FromValues
* Intersect
* Last
* LastOrDefault
* LongCount
* Max
* Min
* Range
* Repeat
* Select
* SelectMany
* Single
* Skip
* SkipWhile
* Sum
* Take
* TakeWhile,
* ToArray
* ToList
* Where

