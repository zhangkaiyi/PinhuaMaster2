using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Pinhua2.Common.Attributes;

namespace Klazor
{
    public class KDataSource<TItem>
    {
        public object Data { get; set; }
        public List<ReflectedCell<TItem>> RData { get; set; } = new List<ReflectedCell<TItem>>();
    }
}
