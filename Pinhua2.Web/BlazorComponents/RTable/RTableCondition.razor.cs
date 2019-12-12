using Microsoft.AspNetCore.Components;
using Pinhua2.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Pinhua2.Web.BlazorComponents.RTable
{
    public partial class RTableCondition<TRow> : ComponentBase
    {
        [Parameter]
        public virtual Expression<Func<RTableColumnConfig, bool>> Predicate { get; set; }

        [Parameter]
        public virtual Expression<Func<ReflectionCell, bool>> Predicate2 { get; set; }

        [CascadingParameter]
        public RTableConditionContainer<TRow> Parent { get; set; }

        [Parameter]
        public virtual RenderFragment<TRow> ChildContent { get; set; }


        protected override void OnParametersSet()
        {
            if (Parent == null)
            {
                return;
            }
            Parent.AddCondition(this);
        }
    }
}
