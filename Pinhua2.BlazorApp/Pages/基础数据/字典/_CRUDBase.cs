using AutoMapper;
using Klazor;
using Microsoft.AspNetCore.Components;
using Pinhua2.BlazorApp.Pages.Components;
using Pinhua2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pinhua2.BlazorApp.Pages.基础数据.字典
{
    public class _CRUDBase : PageComponentBase
    {
        protected readonly string routeA = "/基础数据/字典";
        protected readonly string routeC = "/基础数据/字典/新增";
        protected readonly string routeR = "/基础数据/字典/查看";
        protected readonly string routeU = "/基础数据/字典/修改";
        protected readonly string routeD = "/基础数据/字典/删除";
    }
}
