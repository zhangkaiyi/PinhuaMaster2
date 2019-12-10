using Microsoft.AspNetCore.Components;
using Pinhua2.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Pinhua2.Web.BlazorComponents.TableReflect
{
    public partial class STableCondition<TRow> : ComponentBase
    {
        internal virtual bool IsCheckBox { get; set; }

        [Parameter]
        public virtual bool IsHidden { get; set; } = false;

        [Parameter]
        public Expression<Func<MyMarkModelWithOperation, bool>> Predicate { get; set; }

        [CascadingParameter]
        public STableConditions<TRow> Conditions { get; set; }

        [Parameter]
        public virtual RenderFragment<TRow> ChildContent { get; set; }

        [Parameter]
        public string Text { get; set; }

        protected override void OnParametersSet()
        {
            if (Conditions == null)
            {
                return;
            }
            Conditions.AddCondition(this);
        }
    }
}
