using Microsoft.AspNetCore.Components;
using Pinhua2.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Klazor
{
    public abstract class KTableFormatConditionBase<TItem> : KTableConditionBase<TItem>
    {
        [Parameter]
        public RTableValueType ValueType { get; set; } = RTableValueType.Text;

        [Parameter]
        public string ValueFormat { get; set; }
    }
}
