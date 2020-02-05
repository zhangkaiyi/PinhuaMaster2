﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace Klazor
{
    public class KValidationSummary : ComponentBase
    {
        [CascadingParameter] protected EditContext CurrentEditContext { get; set; }

        /// <summary>
        /// string: Key ,  Tuple of string: Error Message, bool: Valid
        /// </summary>
        [Parameter] public Dictionary<string, bool> ValidationMessages { get; set; } = new Dictionary<string, bool>();

        [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            if (CurrentEditContext != null)
            {
                builder?.OpenComponent(0, typeof(ValidationSummary));
                builder.CloseComponent();
            }

            if (ValidationMessages.Where(q => q.Value == false).Any())
            {
                builder?.OpenElement(1, "ul");
                builder.AddMultipleAttributes(1, AdditionalAttributes);
                builder.AddAttribute(2, "class", "validation-errors");
                foreach (KeyValuePair<string, bool> item in ValidationMessages.Where(q => q.Value == false))
                {
                    builder.OpenElement(2, "li");
                    builder.AddAttribute(3, "class", "validation-message");
                    builder.AddContent(4, item.Key);
                    builder.CloseElement();
                }
                builder.CloseElement();
            }
            if (ValidationMessages.Where(q => q.Value == true).Any())
            {
                builder?.OpenElement(1, "ul");
                builder.AddMultipleAttributes(1, AdditionalAttributes);
                builder.AddAttribute(2, "class", "validation-success");
                foreach (KeyValuePair<string, bool> item in ValidationMessages.Where(q => q.Value == true))
                {
                    builder.OpenElement(2, "li");
                    builder.AddAttribute(3, "class", "validation-message");
                    builder.AddContent(4, item.Key);
                    builder.CloseElement();
                }
                builder.CloseElement();
            }
        }
    }
}
