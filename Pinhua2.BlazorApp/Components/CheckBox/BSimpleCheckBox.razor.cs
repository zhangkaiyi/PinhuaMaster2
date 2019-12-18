using Blazui.Component.EventArgs;
using Klazor;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Klazor
{
    public partial class BSimpleCheckBox<TValue> : BFieldComponentBase<TValue>
    {
        protected string _isChecked = string.Empty;
        protected string _isIndeterminate = string.Empty;
        protected string isDisabled;

        [CascadingParameter]
        public BCheckBoxGroup<TValue> CheckBoxGroup { get; set; }

        [Parameter]
        public CheckBoxStatus Status { get; set; }

        private TValue originValue;
        [Parameter]
        public TValue Value { get; set; }
        [Parameter]
        public bool stopPropagationOnClick { get; set; } = false;

        [Parameter]
        public EventCallback<TValue> ValueChanged { get; set; }
        [Parameter]
        public EventCallback<CheckBoxStatus> StatusChanged { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            originValue = Value;
        }

        protected override void FormItem_OnReset()
        {
            CheckBoxGroup?.SelectedItems?.Remove(Value);
            Value = default;
            Status = CheckBoxStatus.UnChecked;
        }

        protected void ChangeStatus(ChangeEventArgs uIMouseEvent)
        {
            if (IsDisabled)
            {
                return;
            }
            var oldValue = new CheckBoxValue()
            {
                Status = Status
            };
            var newValue = new CheckBoxValue();
            switch (Status)
            {
                case CheckBoxStatus.UnChecked:
                    newValue.Status = CheckBoxStatus.Checked;
                    break;
                case CheckBoxStatus.Checked:
                    newValue.Status = CheckBoxStatus.UnChecked;
                    break;
                case CheckBoxStatus.Indeterminate:
                    newValue.Status = CheckBoxStatus.Checked;
                    break;
            }
            if (newValue.Status == CheckBoxStatus.Checked)
            {
                CheckBoxGroup?.SelectedItems?.Add(Value);
                Value = originValue;
            }
            else
            {
                CheckBoxGroup?.SelectedItems?.Remove(Value);
                Value = default;
            }
            Status = newValue.Status;

            //有 CheckBoxGroup 时，视整个CheckBoxGroup为一个字段
            if (CheckBoxGroup == null)
            {
                SetFieldValue(Value);
            }
            if (ValueChanged.HasDelegate)
            {
                _ = ValueChanged.InvokeAsync(Value);
            }
            if (StatusChanged.HasDelegate)
            {
                var args = new BChangeEventArgs<CheckBoxValue>();
                args.OldValue = oldValue;
                args.NewValue = newValue;
                _ = StatusChanged.InvokeAsync(newValue.Status);
            }
        }

        [Parameter]
        public bool IsDisabled
        {
            get
            {
                return isDisabled == "is-disabled";
            }
            set
            {
                if (value)
                {
                    isDisabled = "is-disabled";
                }
                else
                {
                    isDisabled = null;
                }
            }
        }

        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
