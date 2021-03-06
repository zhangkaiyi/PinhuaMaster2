// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;

namespace Klazor
{
    /// <summary>
    /// Renders a form element that cascades an <see cref="EditContext"/> to descendants.
    /// </summary>
    public partial class KForm : ComponentBase
    {
        private readonly Func<Task> _handleSubmitDelegate; // Cache to avoid per-render allocations

        private EditContext _fixedEditContext;

        /// <summary>
        /// Constructs an instance of <see cref="KForm"/>.
        /// </summary>
        public KForm()
        {
            _handleSubmitDelegate = HandleSubmitAsync;
        }

        /// <summary>
        /// Gets or sets a collection of additional attributes that will be applied to the created <c>form</c> element.
        /// </summary>
        [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

        /// <summary>
        /// Supplies the edit context explicitly. If using this parameter, do not
        /// also supply <see cref="Model"/>, since the model value will be taken
        /// from the <see cref="EditContext.Model"/> property.
        /// </summary>
        [Parameter] public EditContext EditContext { get; set; }

        /// <summary>
        /// Specifies the top-level model object for the form. An edit context will
        /// be constructed for this model. If using this parameter, do not also supply
        /// a value for <see cref="EditContext"/>.
        /// </summary>
        [Parameter] public object Model { get; set; }

        /// <summary>
        /// Specifies the content to be rendered inside this <see cref="KForm"/>.
        /// </summary>
        [Parameter] public RenderFragment<EditContext> ChildContent { get; set; }

        /// <summary>
        /// A callback that will be invoked when the form is submitted.
        ///
        /// If using this parameter, you are responsible for triggering any validation
        /// manually, e.g., by calling <see cref="EditContext.Validate"/>.
        /// </summary>
        [Parameter] public EventCallback<EditContext> OnSubmit { get; set; }

        /// <summary>
        /// A callback that will be invoked when the form is submitted and the
        /// <see cref="EditContext"/> is determined to be valid.
        /// </summary>
        [Parameter] public EventCallback<EditContext> OnValidSubmit { get; set; }

        /// <summary>
        /// A callback that will be invoked when the form is submitted and the
        /// <see cref="EditContext"/> is determined to be invalid.
        /// </summary>
        [Parameter] public EventCallback<EditContext> OnInvalidSubmit { get; set; }

        [Parameter] public LabelAlign LabelAlign { get; set; }

        [Parameter] public bool? InputReadonly { get; set; }

        [Parameter] public int? LabelCol { get; set; }
        [Parameter] public int? LabelColXS { get; set; }
        [Parameter] public int? LabelColSM { get; set; }
        [Parameter] public int? LabelColMD { get; set; }
        [Parameter] public int? LabelColLG { get; set; }
        [Parameter] public int? LabelColXL { get; set; }

        /// <inheritdoc />
        protected override void OnParametersSet()
        {
            if ((EditContext == null) == (Model == null))
            {
                throw new InvalidOperationException($"{nameof(KForm)} requires a {nameof(Model)} " +
                    $"parameter, or an {nameof(EditContext)} parameter, but not both.");
            }

            // If you're using OnSubmit, it becomes your responsibility to trigger validation manually
            // (e.g., so you can display a "pending" state in the UI). In that case you don't want the
            // system to trigger a second validation implicitly, so don't combine it with the simplified
            // OnValidSubmit/OnInvalidSubmit handlers.
            if (OnSubmit.HasDelegate && (OnValidSubmit.HasDelegate || OnInvalidSubmit.HasDelegate))
            {
                throw new InvalidOperationException($"When supplying an {nameof(OnSubmit)} parameter to " +
                    $"{nameof(KForm)}, do not also supply {nameof(OnValidSubmit)} or {nameof(OnInvalidSubmit)}.");
            }

            // Update _fixedEditContext if we don't have one yet, or if they are supplying a
            // potentially new EditContext, or if they are supplying a different Model
            if (_fixedEditContext == null || EditContext != null || Model != _fixedEditContext.Model)
            {
                _fixedEditContext = EditContext ?? new EditContext(Model);
            }
        }

        private async Task HandleSubmitAsync()
        {
            if (OnSubmit.HasDelegate)
            {
                // When using OnSubmit, the developer takes control of the validation lifecycle
                await OnSubmit.InvokeAsync(_fixedEditContext);
            }
            else
            {
                // Otherwise, the system implicitly runs validation on form submission
                var isValid = _fixedEditContext.Validate(); // This will likely become ValidateAsync later

                if (isValid && OnValidSubmit.HasDelegate)
                {
                    await OnValidSubmit.InvokeAsync(_fixedEditContext);
                }

                if (!isValid && OnInvalidSubmit.HasDelegate)
                {
                    await OnInvalidSubmit.InvokeAsync(_fixedEditContext);
                }
            }
        }
    }
}
