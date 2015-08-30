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
//        public static async Task<TSource> SingleAsync<TSource>(this IAsyncEnumerable<TSource> source, CancellationToken ct = default(CancellationToken))
//        {
//            if (source == null) throw new ArgumentNullException("source");
            
//            var e = await source.GetEnumerator(ct);
//            if (await e.MoveNext(ct))
//            {
//                var result = e.Current;
//                if (!await e.MoveNext(ct))
//                {
//                    return result;
//                }
//            }
//            throw new InvalidOperationException();
//        }
//    }
//}
