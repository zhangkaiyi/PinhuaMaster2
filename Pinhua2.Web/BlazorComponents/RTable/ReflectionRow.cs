using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Pinhua2.Common.Attributes;

namespace Pinhua2.Web.BlazorComponents.RTable
{
    public class ReflectionRow
    {
        public List<ReflectionCell> Cells { get; set; } = new List<ReflectionCell>();
    }
}
