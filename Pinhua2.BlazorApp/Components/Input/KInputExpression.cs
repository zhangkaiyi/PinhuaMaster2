using Microsoft.AspNetCore.Components;
using Pinhua2.ViewModels;
using System;
using System.Linq.Expressions;

namespace Klazor
{
    public class KInputExpression : ComponentBase
    {
        [CascadingParameter] public KInput Input { get; set; }
        [Parameter] public virtual Expression<Func<KInput, bool>> Condition { get; set; }
        [Parameter] public virtual Action<KInputExpression> Action { get; set; }
        [Parameter] public virtual RenderFragment ChildContent { get; set; }
        
        protected override void OnParametersSet()
        {

            if (Input == null)
                return;

            if (Condition == null)
                return;

            if (Action == null)
                return;

            var eval = Condition.Compile();

            if (eval(Input))
            {
                Action.Invoke(this);
            }
        }
    }
}