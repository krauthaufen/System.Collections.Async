﻿//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace System.Collections.Async
//{
//    public static partial class AsyncEnumerable
//    {
//        public static IAsyncEnumerable<TSource> SkipWhile<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate, CancellationToken ct = default(CancellationToken))
//        {
//            if (source == null) throw new ArgumentNullException("source");

//            return new _AsyncEnumerable<TSource>(async ct2 =>
//            {
//                var skipping = true;
//                var e = await source.GetEnumerator(ct2);
//                return new _AsyncEnumerator<TSource>(async () =>
//                {
//                    while (true)
//                    {
//                        if (await e.MoveNext(ct))
//                        {
//                            if (skipping)
//                            {
//                                if (predicate(e.Current)) continue;
//                                skipping = false;
//                            }

//                            return Tuple.Create(e.Current, true);
//                        }
//                        else
//                        {
//                            return Tuple.Create(default(TSource), false);
//                        }
//                    }
//                });
//            });
//        }

//        public static IAsyncEnumerable<TSource> SkipWhile<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, int, bool> predicate, CancellationToken ct)
//        {
//            if (source == null) throw new ArgumentNullException("source");

//            return new _AsyncEnumerable<TSource>(async ct2 =>
//            {
//                var i = 0;
//                var skipping = true;
//                var e = await source.GetEnumerator(ct2);
//                return new _AsyncEnumerator<TSource>(async () =>
//                {
//                    while (true)
//                    {
//                        if (await e.MoveNext(ct))
//                        {
//                            if (skipping)
//                            {
//                                if (predicate(e.Current, i++)) continue;
//                                skipping = false;
//                            }

//                            return Tuple.Create(e.Current, true);
//                        }
//                        else
//                        {
//                            return Tuple.Create(default(TSource), false);
//                        }
//                    }
//                });
//            });
//        }
//    }
//}
