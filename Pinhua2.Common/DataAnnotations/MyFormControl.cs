using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Pinhua2.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MyFormControlAttribute : Attribute
    {
        public string Placeholder { get; set; }
        public bool Visible { get; set; }
        public bool Hidden { get; set; }
        public bool Readonly { get; set; }
    }
}