using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pinhua2.Web.BlazorComponents.Table
{
    public partial class BTableDateTimeColumn<TRow> : BTableColumn<TRow>
    {
        [Parameter]
        public string Format { get; set; }
    }
}
