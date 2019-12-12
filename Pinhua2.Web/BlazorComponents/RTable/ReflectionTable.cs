using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Pinhua2.Common.Attributes;

namespace Pinhua2.Web.BlazorComponents.RTable
{
    public class RTableReflectionData<TRow>
    {
        public List<RTableCondition<TRow>> Conditions { get; set; } = new List<RTableCondition<TRow>>();
        public List<ReflectionRow> Rows { get; set; } = new List<ReflectionRow>();
    }
}
