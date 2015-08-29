﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Collections.Async.Tests
{
    internal static class TestHelpers
    {
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
    }
}
