using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Pinhua2.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MyOrderAttribute : Attribute
    {
        public double Order { get; }

        public MyOrderAttribute(double displayOrder = 100)
        {
            Order = displayOrder;
        }
    }
}