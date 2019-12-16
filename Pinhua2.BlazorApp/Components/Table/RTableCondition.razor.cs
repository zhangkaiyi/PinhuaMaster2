using Microsoft.AspNetCore.Components;
using System;
using System.Linq.Expressions;

namespace Klazor
{
    public abstract class KTableConditionBase<TDataSource> : ComponentBase
    {
        [Parameter]
        public virtual Expression<Func<ReflectionCell<TDataSource>, bool>> Predicate { get; set; }

        [CascadingParameter]
        public KTableBase<TDataSource> Table { get; set; }

        [Parameter]
        public virtual RenderFragment<TDataSource> ChildContent { get; set; }

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
