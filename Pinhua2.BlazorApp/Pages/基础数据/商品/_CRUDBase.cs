using AutoMapper;
using Klazor;
using Microsoft.AspNetCore.Components;
using Pinhua2.BlazorApp.Pages.Components;
using Pinhua2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pinhua2.BlazorApp.Pages.基础数据.商品
{
    public class _CRUDBase : PageComponentBase
    {
        protected readonly string routeA = "/基础数据/商品";
        protected readonly string routeC = "/基础数据/商品/新增";
        protected readonly string routeR = "/基础数据/商品/查看";
        protected readonly string routeU = "/基础数据/商品/修改";
        protected readonly string routeD = "/基础数据/商品/删除";

        protected decimal?[] dropdownLength = new decimal?[] { 450M, 500M, 600M, 400M };
        protected decimal?[] dropdownWidth = new decimal?[] { 450M, 500M, 600M, 400M };
        protected decimal?[] dropdownHeight = new decimal?[] { 15M, 18M, 12M };

        protected string[] dropdownUnits = new string[] { "片", "平方米", "延长米", "立方米", "套" };
        protected string[] dropdownCategory = new string[] { "地板类", "辅料类" };
    }
}
