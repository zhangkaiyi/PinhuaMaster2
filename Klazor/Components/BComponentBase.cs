using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Klazor
{
    public class BComponentBase : ComponentBase
    {
        [Parameter]
        public string Style { get; set; } = string.Empty;
    }
}
