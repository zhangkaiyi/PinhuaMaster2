using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Pinhua2.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MyViewComponentAttribute : Attribute
    {
        public string Name { get; }

        public MyViewComponentAttribute(string componentName)
        {
            Name = componentName;
        }
    }
}