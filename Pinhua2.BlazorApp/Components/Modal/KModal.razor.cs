using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Klazor
{
    public abstract class KModalBase : ComponentBase
    {
        [Parameter] public string Id { get; set; }

        protected override void OnInitialized()
        {

        }

    }
}
