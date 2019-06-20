using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Pinhua2.Common.Attributes
{
    public enum Priority
    {
        High,
        Medium,
        Low
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class MyPriorityAttribute : Attribute
    {
        public MyPriorityAttribute(Priority priority)
        {
            Priority = priority;
        }

        public Priority Priority { get; }
    }
}