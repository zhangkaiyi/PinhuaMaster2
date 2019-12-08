using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pinhua2.Web.BlazorComponents.Table
{
    public partial class BTableTemplateColumn<TRow> : BTableColumn<TRow>
    {
        [Parameter]
        public override RenderFragment<TRow> ChildContent { get; set; }
    }
}
