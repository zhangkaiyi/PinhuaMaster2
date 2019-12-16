using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pinhua2.Web.BlazorComponents.RModal
{
    public abstract class RModalBase : ComponentBase
    {
        [Parameter] public string Id { get; set; }

        protected override void OnInitialized()
        {

        }

    }
}
