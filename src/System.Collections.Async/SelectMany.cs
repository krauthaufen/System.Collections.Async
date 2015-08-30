//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace System.Collections.Async
//{
//    public static partial class AsyncEnumerable
//    {
//        public static IAsyncEnumerable<TResult> SelectMany<TSource, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, IEnumerable<TResult>> selector, CancellationToken ct = default(CancellationToken))
//        {
//            if (source == null) throw new ArgumentNullException("source");
//            if (selector == null) throw new ArgumentNullException("selector");

//            return new _AsyncEnumerable<TResult>(async ct2 =>
//            {
//                var outer = await source.GetEnumerator(ct2);
//                if (!await outer.MoveNext(ct2)) return new _AsyncEnumeratorEmpty<TResult>();
//                var inner = selector(outer.Current).GetEnumerator();
//                return new _AsyncEnumerator<TResult>(async () =>
//                {
//                    while (true)
//                    {
//                        if (inner.MoveNext())
//                        {
//                            return Tuple.Create(inner.Current, true);
//                        }
//                        else
//                        {
//                            if (await outer.MoveNext(ct2))
//                            {
//                                inner = selector(outer.Current).GetEnumerator();
//                            }
//                            else
//                            {
//                                return Tuple.Create(default(TResult), false);
//                            }
//                        }
//                    }
//                });
//            });
//        }
//    }
//}
