﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meticulous
{
    public static class Check
    {
        #region ArgumentNotNull

        public static void This<T>(T @this)
            where T : class
        {
            ArgumentNotNullImpl(@this, "this", "The first argument of extension method is null");
        }

        public static void ArgumentNotNull<T>(T arg, string paramName)
            where T : class
        {
            ArgumentNotNullImpl(arg, paramName, null);
        }

        public static void ArgumentNotNull<T>(T arg, string paramName, string message)
            where T : class
        {
            ArgumentNotNullImpl(arg, paramName, message);
        }

        #endregion


        #region ArgumentInRange

        public static void ArgumentInRange<T>(T arg, string paramName, T lo, T hi, string message)
            where T: struct, IComparable<T>
        {
            ArgumentInRangeImpl(arg, paramName, lo, hi, message);
        }

        public static void ArgumentInRange<T>(T arg, string paramName, T lo, T hi)
            where T : struct, IComparable<T>
        {
            ArgumentInRangeImpl(arg, paramName, lo, hi, null);
        }

        #endregion

        #region OperationValid

        public static void OperationValid(bool condition, string message)
        {
            if (!condition)
                throw new InvalidOperationException(message);
        }

        #endregion

        #region Impl

        private static void ArgumentNotNullImpl<T>(T arg, string paramName, string message)
            where T : class
        {
            if (arg != null)
                return;

            if (message == null)
                throw new ArgumentNullException(paramName);

            throw new ArgumentNullException(paramName, message);
        }

        private static void ArgumentInRangeImpl<T>(T arg, string paramName, T lo, T hi, string message)
            where T : struct, IComparable<T>
        {
            if (lo.CompareTo(arg) <= 0)
            {
                if (hi.CompareTo(arg) >= 0)
                    return;
            }

            if (message == null)
                throw new ArgumentOutOfRangeException(paramName);

            throw new ArgumentOutOfRangeException(paramName, message);
        }

        #endregion
    }

    public static class CheckDebug
    {
        [Conditional("DEBUG")]
        public static void This<T>(T @this)
            where T : class
        {
            Check.This(@this);
        }

        [Conditional("DEBUG")]
        public static void ArgumentNotNull<T>(T arg, string paramName)
            where T : class
        {
            Check.ArgumentNotNull(arg, paramName);
        }

        [Conditional("DEBUG")]
        public static void ArgumentNotNull<T>(T arg, string paramName, string message)
            where T : class
        {
            Check.ArgumentNotNull(arg, paramName, message);
        }
    }
}
