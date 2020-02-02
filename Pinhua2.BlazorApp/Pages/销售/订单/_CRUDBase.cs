using AutoMapper;
using Klazor;
using Microsoft.AspNetCore.Components;
using Pinhua2.BlazorApp.Pages.Components;
using Pinhua2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pinhua2.BlazorApp.Pages.销售.订单
{
    public class _CRUDBase : PageComponentBase
    {
        protected readonly string routeA = "/销售/订单";
        protected readonly string routeC = "/销售/订单/新增";
        protected readonly string routeR = "/销售/订单/查看";
        protected readonly string routeU = "/销售/订单/修改";
        protected readonly string routeD = "/销售/订单/删除";

        protected readonly string category = "销售订单";
    }
}
