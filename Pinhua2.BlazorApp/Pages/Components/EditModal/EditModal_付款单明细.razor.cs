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
    public partial class EditModal_付款单明细 : ComponentBase
    {
        [Parameter] public EventCallback<EditModal_付款单明细> OnOK { get; set; }
        [Parameter] public EventCallback<EditModal_付款单明细> OnCancel { get; set; }

        protected KModal modal;
        protected string[] dropdownItems => new[] { "片", "平方米", "延长米", "立方米", "套" };

        protected dto付款单D currentDataSource
        {
            get
            {
                return DataSource;
            }
        }

        [Parameter] public dto付款单D DataSource { get; set; }

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

        protected decimal? computedQuantity
        {
            get
            {
                switch (currentDataSource.单位)
                {
                    case "片":
                        return currentDataSource.个数;
                    case "平方米":
                        return currentDataSource.个数 * currentDataSource.长度 * currentDataSource.宽度 / 1000 / 1000;
                    case "延长米":
                        return currentDataSource.个数 * currentDataSource.长度 / 1000;
                    case "立方米":
                        return currentDataSource.个数 * currentDataSource.长度 * currentDataSource.宽度 * currentDataSource.高度 / 1000 / 1000 / 1000;
                    case "套":
                        return currentDataSource.个数;
                    default:
                        return null;
                }
            }
            set
            {
                currentDataSource.数量 = value;
            }
        }
    }
}
