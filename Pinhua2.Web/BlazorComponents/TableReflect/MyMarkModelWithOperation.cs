using Pinhua2.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Pinhua2.Web.BlazorComponents.TableReflect
{
    public class MyMarkModelWithOperation
    {
        public MyMarkModel Model { get; set; }
        public Expression<Func<MyMarkModel, bool>> Predicate { get; set; }
        public bool Hidden { get; set; }
    }
}
