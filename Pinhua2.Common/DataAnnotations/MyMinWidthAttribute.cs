using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Pinhua2.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MyMinWidthAttribute : Attribute
    {
        public double MinWidth { get; }
        public MyMinWidthAttribute(double minWidth)
        {
            MinWidth = minWidth;
        }
    }
}