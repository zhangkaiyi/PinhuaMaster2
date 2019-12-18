using Microsoft.AspNetCore.Components;
using Pinhua2.ViewModels;
using System;
using System.Linq.Expressions;

namespace Klazor
{
    public abstract class KTableCondition<TItem> : ComponentBase
    {
        [Parameter]
        public virtual Expression<Func<ReflectedCell<TItem>, bool>> Predicate { get; set; }

        [CascadingParameter]
        public KTable<TItem> Table { get; set; }

        [Parameter]
        public virtual RenderFragment<TItem> ChildContent { get; set; }

        protected override void OnParametersSet()
        {
            if (Table?.RConditions == null)
            {
                return;
            }
            if (Table.RConditions.Contains(this))
            {
                return;
            }
            Table.RConditions.Add(this);
        }
    }
}