using AutoMapper;
using Klazor;
using Microsoft.AspNetCore.Components;
using Pinhua2.BlazorApp.Pages.Components;
using Pinhua2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pinhua2.BlazorApp.Pages.销售.出库
{
    public class _CRUDBase : PageComponentBase
    {
        protected readonly string routeA = "/销售/出库";
        protected readonly string routeC = "/销售/出库/新增";
        protected readonly string routeR = "/销售/出库/查看";
        protected readonly string routeU = "/销售/出库/修改";
        protected readonly string routeD = "/销售/出库/删除";

        protected readonly string category = "销售出库";
    }
}
