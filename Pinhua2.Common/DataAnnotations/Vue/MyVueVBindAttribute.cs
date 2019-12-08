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
        public string Prop { get; set; }
        public string Method { get; set; }
        public string Args { get; set; }

        public MyVueVBindAttribute()
        {

        }

        public MyVueVBindAttribute(string prop, string method, string args)
        {
            Prop = prop;
            Method = method;
            Args = args;
        }
    }
}