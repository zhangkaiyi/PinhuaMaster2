using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Klazor
{
    public class KTable2Column : ComponentBase
    {
        internal virtual bool IsCheckBox { get; set; }
        internal virtual bool IsBoolean { get; set; }

        [Parameter]
        public virtual int? Width { get; set; }

        [Parameter]
        public string Field { get; set; }

        [Parameter]
        public string Format { get; set; }

        [CascadingParameter]
        public KTable2Columns Columns { get; set; }

        [Parameter]
        public virtual RenderFragment<object> ChildContent { get; set; }

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
