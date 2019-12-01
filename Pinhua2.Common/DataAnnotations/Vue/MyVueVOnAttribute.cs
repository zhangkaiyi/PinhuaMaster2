using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Pinhua2.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MyVueVOnAttribute : Attribute
    {
        public string Event { get; set; }
        public string Method { get; set; }
        public MyVueVOnAttribute(string _event, string _method)
        {
            Event = _event;
            Method = _method;
        }
    }
}