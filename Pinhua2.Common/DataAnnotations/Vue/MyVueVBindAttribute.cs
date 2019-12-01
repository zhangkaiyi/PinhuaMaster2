using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Pinhua2.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MyVueVBindAttribute : Attribute
    {
        public string Attr { get; set; }
        public string Method { get; set; }
        public MyVueVBindAttribute(string attr, string method)
        {
            Attr = attr;
            Method = method;
        }
    }
}