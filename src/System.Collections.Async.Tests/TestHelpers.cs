using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Collections.Async.Tests
{
    internal static class TestHelpers
    {
        public static Task<int> FaultedTask
        {
            get
            {
                var x = new TaskCompletionSource<int>();
                x.SetException(new Exception("Test"));
                return x.Task;
            }
        }

        public static IAsyncEnumerable<int> FaultedIntSequence
        {
            get
            {
                var xs = new[] { 1, 2, 3, 4, 5 };
                return xs.Select(x =>
                {
                    if (x == 1) throw new Exception("Test");
                    return Task.FromResult(x);
                })
                .ToAsyncEnumerable();
            }
        }
        
        public static void ThrowsArgumentNullException(Action action)
        {
            try
            {
                action();
                Assert.Fail();
            }
            catch (ArgumentNullException)
            {
            }
            catch
            {
                Assert.Fail();
            }
        }
        
        public static void ThrowsInvalidOperationException(Action action)
        {
            try
            {
                action();
                Assert.Fail();
            }
            catch (ArgumentNullException)
            {
            }
            catch
            {
                Assert.Fail();
            }
        }

        public static void ThrowsAggregateArgumentNullException(Action action)
        {
            try
            {
                action();
                Assert.Fail();
            }
            catch (Exception e)
            {
                var a = e as AggregateException;
                if (a == null || a.InnerExceptions.Count != 1 || !(a.InnerException is ArgumentNullException))
                    Assert.Fail();
            }
        }

        public static void ThrowsAggregateInvalidOperationException(Action action)
        {
            try
            {
                action();
                Assert.Fail();
            }
            catch (Exception e)
            {
                var a = e as AggregateException;
                if (a == null || a.InnerExceptions.Count != 1 || !(a.InnerException is InvalidOperationException))
                    Assert.Fail();
            }
        }

        public static void ThrowsAggregateTaskCanceledException(Action action)
        {
            try
            {
                action();
                Assert.Fail();
            }
            catch (Exception e)
            {
                var a = e as AggregateException;
                if (a == null || a.InnerExceptions.Count != 1 || !(a.InnerException is TaskCanceledException))
                    Assert.Fail();
            }
        }

        public static void ThrowsAggregateTestException(Action action)
        {
            try
            {
                action();
                Assert.Fail();
            }
            catch (Exception e)
            {
                var a = e as AggregateException;
                if (a == null || a.InnerExceptions.Count != 1 || a.InnerException.Message != "Test")
                    Assert.Fail();
            }
        }

        public static void TestFaultedOrCanceled(Action<IAsyncEnumerable<int>, CancellationToken> action)
        {
            ThrowsAggregateTaskCanceledException(() =>
                action(AsyncEnumerable.Empty<int>(), new CancellationToken(true))
                );
            ThrowsAggregateTestException(() =>
                action(FaultedIntSequence, CancellationToken.None)
                );
        }
    }
}
