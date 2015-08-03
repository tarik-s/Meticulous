﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meticulous.Patterns
{
    public interface IBuilder<out T>
    {
        T Build();
    }
}
