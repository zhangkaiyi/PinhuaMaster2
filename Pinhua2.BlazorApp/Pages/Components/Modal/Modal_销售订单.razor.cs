﻿using BlazorComponentUtilities;
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

namespace Piuhua2.Components.Modal
{
    public partial class Modal_销售订单 : ComponentBase
    {
        protected KModal modal;
        protected KTable2 table;
        protected List<dto销售订单> products;

        [Inject] IMapper Mapper { get; set; }
        [Inject] Pinhua2Context PinhuaContext { get; set; }

        [Parameter] public EventCallback<Modal_销售订单> OnOK { get; set; }
        [Parameter] public EventCallback<Modal_销售订单> OnCancel { get; set; }

        protected override void OnInitialized()
        {
            products = Mapper.ProjectTo<dto销售订单>(PinhuaContext.GetViews().销售.销售订单()).ToList();

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
            table.SetAllCheckState(false);
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
