using Microsoft.AspNetCore.Components;
using Pinhua2.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Pinhua2.Web.BlazorComponents.RTable
{
    public partial class RTableCondition<TDataSource> : ComponentBase
    {
        [Parameter]
        public virtual Expression<Func<ReflectionCell<TDataSource>, bool>> Predicate { get; set; }

        [CascadingParameter]
        public RTableConditionContainer<TDataSource> Parent { get; set; }

        [Parameter]
        public virtual RenderFragment<TDataSource> ChildContent { get; set; }


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
