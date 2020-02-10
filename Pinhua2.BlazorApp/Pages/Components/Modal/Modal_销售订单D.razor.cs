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
    public partial class Modal_销售订单D : ComponentBase
    {
        protected KModal modal;
        protected KTable2 table;

        protected List<combo销售订单> DataSource;
        protected List<dto销售订单D> currentDataSource
        {
            get
            {
                if (FilterExpression != null)
                {
                    return Mapper.Map<IEnumerable<dto销售订单D>>(DataSource.Where(FilterExpression.Compile()).Select(d => d.Detail)).ToList();
                }
                else
                {
                    return Mapper.Map<IEnumerable<dto销售订单D>>(DataSource.Select(d => d.Detail)).ToList();
                }
            }

        }

        [Inject] IMapper Mapper { get; set; }
        [Inject] Pinhua2Context PinhuaContext { get; set; }

        [Parameter] public EventCallback<Modal_销售订单D> OnOK { get; set; }
        [Parameter] public EventCallback<Modal_销售订单D> OnCancel { get; set; }
        [Parameter] public Expression<Func<combo销售订单, bool>> FilterExpression { get; set; }

        protected override void OnInitialized()
        {
            DataSource = PinhuaContext.GetViews().销售.销售订单combo();

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
