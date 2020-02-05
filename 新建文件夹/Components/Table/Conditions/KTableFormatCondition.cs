using Microsoft.AspNetCore.Components;
using Pinhua2.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Klazor
{
    public partial class KTableFormatCondition<TItem> : KTableCondition<TItem>
    {
        [Parameter]
        public KTableValueType ValueType { get; set; } = KTableValueType.Text;

        [Parameter]
        public string ValueFormat { get; set; }
    }
}
