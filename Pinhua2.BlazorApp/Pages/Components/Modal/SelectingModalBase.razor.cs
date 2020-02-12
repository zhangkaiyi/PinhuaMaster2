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
using Pinhua2.BlazorApp.Pages.Components;

namespace Piuhua2.Components.Modal
{
    public partial class SelectingModalBase : PageComponentBase
    {
        protected KModal modal;


        [Parameter] public bool IsSingleSelect { get; set; } = false;


        public void Show()
        {
            //table.ChangeAllStatus(CheckBoxStatus.UnChecked);
            modal.Show();
        }

    }
}
