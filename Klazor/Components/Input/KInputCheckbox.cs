// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components;

namespace Klazor
{
    /* This is exactly equivalent to a .razor file containing:
     *
     *    @inherits InputBase<bool>
     *    <input type="checkbox" @bind="CurrentValue" id="@Id" class="@CssClass" />
     *
     * The only reason it's not implemented as a .razor file is that we don't presently have the ability to compile those
     * files within this project. Developers building their own input components should use Razor syntax.
     */

    /// <summary>
    /// An input component for editing <see cref="bool"/> values.
    /// </summary>
    public class KInputCheckbox : KInputBase<bool>
    {
        /// <inheritdoc />
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "input");
            builder.AddMultipleAttributes(1, UnknownParameters);
            builder.AddAttribute(2, "type", "checkbox");
            //builder.AddAttribute(3, "class", Classname);
            builder.AddAttribute(3, "class", "");
            builder.AddAttribute(4, "checked", BindConverter.FormatValue(currentValue));
            builder.AddAttribute(5, "onchange", EventCallback.Factory.CreateBinder<bool>(this, __value => currentValue = __value, currentValue));
            builder.AddAttribute(6, "id", Id);
            builder.CloseElement();
        }
    }
}
