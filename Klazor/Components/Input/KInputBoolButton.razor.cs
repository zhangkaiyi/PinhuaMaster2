﻿using BlazorComponentUtilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using System.Linq.Expressions;
using System.Globalization;

namespace Klazor
{
    public partial class KInputBoolButton<TValue> : KInputBool<TValue>
    {
        [Parameter] public string ButtonText { get; set; } = "按钮";
        [Parameter] public EventCallback<MouseEventArgs> OnButtonClick { get; set; }
    }
}
