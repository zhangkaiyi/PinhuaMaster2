using BlazorComponentUtilities;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorStrap;
using Microsoft.JSInterop;
using Pinhua2.Common.Attributes;
using Pinhua2.Common.DataAnnotations;
using System.Linq.Expressions;
using Pinhua2.ViewModels;
using Klazor;

namespace Piuhua2.Components.PageTemplate
{
    public partial class TemplateA : ComponentBase
    {
        [Parameter] public IEnumerable<TemplateAItem> Items { get; set; }
    }
}
