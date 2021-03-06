﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meticulous.Externals
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Assembly, Inherited = false)]
    public class ExternalGroupAttribute : Attribute
    {
        private readonly string _name;

        public ExternalGroupAttribute()
        {
            _name = String.Empty; 
        }

        public ExternalGroupAttribute(string name)
        {
            Check.ArgumentNotEmpty(name, "name");

            _name = name;
        }
        
        public string Name
        {
            get { return _name; }
        }
    }
}
