using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Pinhua2.Common.Attributes;

namespace Klazor
{
    public class ReflectionCol<TDataSource>
    {
        public List<ReflectionCell<TDataSource>> Cells { get; set; } = new List<ReflectionCell<TDataSource>>();
    }
}
