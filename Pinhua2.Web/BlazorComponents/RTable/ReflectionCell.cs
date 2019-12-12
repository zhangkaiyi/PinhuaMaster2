using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Pinhua2.Common.Attributes;

namespace Pinhua2.Web.BlazorComponents.RTable
{
    public class ReflectionCell
    {
        public MyMarkModel Model { get; set; }
        public bool IsHidden { get; set; } = false;
        public RTableValueType ValueType { get; set; } = RTableValueType.Text;
        public string ValueFormat { get; set; } = string.Empty;
    }
}
