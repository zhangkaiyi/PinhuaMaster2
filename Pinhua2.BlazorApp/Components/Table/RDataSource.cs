using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Pinhua2.Common.Attributes;

namespace Klazor
{
    public class RDataSource<TItem>
    {
        public TItem Data { get; set; }
        public List<ReflectionCell<TItem>> RData { get; set; } = new List<ReflectionCell<TItem>>();
    }
}
