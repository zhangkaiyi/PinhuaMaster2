using Microsoft.AspNetCore.Components;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Klazor
{
    public partial class KTableConditionContainer<TItem> : ComponentBase
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }
        [CascadingParameter]
        public KTable<TItem> Table { get; set; }

        public void AddCondition(KTableCondition<TItem> condition)
        {
            var exsisted = Table.RConditions.Contains(condition);
            if (!exsisted)
                Table.RConditions.Add(condition);
        }
    }
}
