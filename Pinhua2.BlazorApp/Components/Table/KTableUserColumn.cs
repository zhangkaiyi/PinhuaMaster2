using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Klazor
{
    public class KTableUserColumn<TItem> : ComponentBase
    {
        internal virtual bool IsCheckBox { get; set; }
        [Parameter]
        public virtual int? Width { get; set; }

        [Parameter]
        public Expression<Func<TItem, object>> Property { get; set; }

        [CascadingParameter]
        public KTableUserColumns<TItem> Columns { get; set; }

        [Parameter]
        public virtual RenderFragment<TItem> ChildContent { get; set; }

        [Parameter]
        public string Text { get; set; }

        protected override void OnParametersSet()
        {
            if (Columns == null)
            {
                return;
            }
            Columns.AddColumn(this);
        }
    }
}
