﻿using AutoMapper;
using Klazor;
using Microsoft.AspNetCore.Components;
using Pinhua2.BlazorApp.Pages.Components;
using Pinhua2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pinhua2.BlazorApp.Pages.采购.申请
{
    public class _CRUDBase : PageComponentBase
    {
        protected readonly string routeA = "/采购/申请";
        protected readonly string routeC = "/采购/申请/新增";
        protected readonly string routeR = "/采购/申请/查看";
        protected readonly string routeU = "/采购/申请/修改";
        protected readonly string routeD = "/采购/申请/删除";

        protected readonly string category = "采购申请";

        protected string[] dropdownCategory1 = new string[] { "付款" };
        protected string[] dropdownCategory2 = new string[] { "银行", "微信", "支付宝", "二维码", "现金", "其他" };
    }
}
