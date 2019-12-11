﻿using Microsoft.AspNetCore.Components;
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

        [CascadingParameter]
        public RTableConditions<TRow> Conditions { get; set; }

        [Parameter]
        public virtual RenderFragment<TRow> ChildContent { get; set; }


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