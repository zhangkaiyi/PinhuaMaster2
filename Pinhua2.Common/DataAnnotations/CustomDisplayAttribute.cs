using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Pinhua2.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class CustomDisplayAttribute : Attribute
    {
        public double Order { get; } = 100;
        public bool IsRendered { get; set; } = true;
        public bool ForIndex { get; set; } = true;
        public bool ForCreate { get; set; } = false;
        public bool ForRead { get; set; } = true;
        public bool ForUpdate { get; set; } = false;
        public bool ForDelete { get; set; } = true;
        public CustomDisplayAttribute(double displayOrder = 100)
        {
            Order = displayOrder;
        }
    }
}