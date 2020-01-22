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

namespace Piuhua2.Components.Modal
{
    public partial class EditModal_字典明细 : ComponentBase
    {
        [Parameter] public EventCallback<EditModal_字典明细> OnOK { get; set; }
        [Parameter] public EventCallback<EditModal_字典明细> OnCancel { get; set; }

        protected KModal modal;
        protected string[] dropdownItems => new[] { "片", "平方米", "延长米", "立方米", "套" };

        protected dto字典D currentDataSource
        {
            get
            {
                return DataSource;
            }
        }

        [Parameter] public dto字典D DataSource { get; set; }

        protected void OK()
        {
            Hide();
            OnOK.InvokeAsync(this);
        }

        protected void Cancel()
        {
            Hide();
            OnCancel.InvokeAsync(this);
        }

        public void Show()
        {
            modal.Show();
        }

        public void Hide()
        {
            modal.Hide();
        }
    }
}
