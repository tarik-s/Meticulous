﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Meticulous.Tests
{
    [TestFixture]
    public class CheckTests
    {
        private const string _notNullObject = "";

        [TestCase(_notNullObject)]
        [TestCase(null, ExpectedException = typeof(ArgumentNullException))]
        public void ThisTest(object @this)
        {
            Check.This(@this);
        }



        [TestCase(_notNullObject)]
        [TestCase(null, ExpectedException = typeof(ArgumentNullException))]
        public void ArgumentNotNull(object arg)
        {
            Check.ArgumentNotNull(arg, "arg");
        }

        [TestCase(1, 0, 2)]
        [TestCase(1, 1, 1)]
        [TestCase(0, 1, 2, ExpectedException = typeof(ArgumentOutOfRangeException))]
        [TestCase(0, 2, 2, ExpectedException = typeof(ArgumentOutOfRangeException))]
        public void ArgumentInRange(int arg, int lo, int hi)
        {
            Check.ArgumentInRange(arg, "arg", lo, hi);
        }

    }
}
