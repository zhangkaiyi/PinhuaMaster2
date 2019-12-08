using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pinhua2.Web.BlazorComponents.Button
{
    public partial class BButtonGroup : ComponentBase
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
