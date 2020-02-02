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
using AutoMapper;
using Pinhua2.Data;
using Pinhua2.Data.Models;

namespace Piuhua2.Components.Modal
{
    public partial class Modal_订单金额待付 : ComponentBase
    {
        protected KModal modal;
        protected KTable2 table;

        protected List<view_AllOrdersPay> DataSource;
        protected List<view_AllOrdersPay> currentDataSource
        {
            get
            {
                if (FilterExpression != null)
                {
                    return DataSource.Where(FilterExpression.Compile()).ToList();
                }
                else
                {
                    return DataSource;
                }
            }
            set
            {
                DataSource = value;
            }
        }

        [Inject] IMapper Mapper { get; set; }
        [Inject] Pinhua2Context PinhuaContext { get; set; }

        [Parameter] public EventCallback<Modal_订单金额待付> OnOK { get; set; }
        [Parameter] public EventCallback<Modal_订单金额待付> OnCancel { get; set; }
        [Parameter] public Expression<Func<view_AllOrdersPay, bool>> FilterExpression { get; set; }

        protected override void OnInitialized()
        {
            currentDataSource = PinhuaContext.View订单金额收付().Where(item => item.待付 > 0 && item.业务类型.StartsWith("采购")).ToList();

            base.OnInitialized();
        }

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
            table.ChangeAllStatus(CheckBoxStatus.UnChecked);
            modal.Show();
        }

        public void Hide()
        {
            modal.Hide();
        }

        public HashSet<object> SelectedProducts
        {
            get { return table.SelectedRows; }
        }
    }
}
