using AutoMapper;
using Klazor;
using Microsoft.AspNetCore.Components;
using Pinhua2.BlazorApp.Pages.Components;
using Pinhua2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pinhua2.BlazorApp.Pages.销售.收款
{
    public class _CRUDBase : PageComponentBase
    {
        protected readonly string routeA = "/销售/收款";
        protected readonly string routeC = "/销售/收款/新增";
        protected readonly string routeR = "/销售/收款/查看";
        protected readonly string routeU = "/销售/收款/修改";
        protected readonly string routeD = "/销售/收款/删除";

        protected string[] dropdownCategory1 = new string[] { "收款" };
        protected string[] dropdownCategory2 = new string[] { "银行", "微信", "支付宝", "二维码", "现金", "其他" };
    }
}
