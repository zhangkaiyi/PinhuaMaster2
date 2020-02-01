using AutoMapper;
using Klazor;
using Microsoft.AspNetCore.Components;
using Pinhua2.BlazorApp.Pages.Components;
using Pinhua2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pinhua2.BlazorApp.Pages.采购.入库
{
    public class _CRUDBase : PageComponentBase
    {
        protected readonly string routeA = "/采购/入库";
        protected readonly string routeC = "/采购/入库/新增";
        protected readonly string routeR = "/采购/入库/查看";
        protected readonly string routeU = "/采购/入库/修改";
        protected readonly string routeD = "/采购/入库/删除";

        protected readonly string category = "采购入库";
    }
}
