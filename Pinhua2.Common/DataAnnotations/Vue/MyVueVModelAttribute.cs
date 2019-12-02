using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Pinhua2.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MyVueVModelAttribute : Attribute
    {
        public string TargetPrefix { get; set; }

        public MyVueVModelAttribute()
        {
            
        }

        public MyVueVModelAttribute(string targetPrefix)
        {
            TargetPrefix = targetPrefix;
        }
    }
}