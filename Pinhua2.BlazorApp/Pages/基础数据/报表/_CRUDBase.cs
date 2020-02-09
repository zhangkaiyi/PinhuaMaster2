using AutoMapper;
using Klazor;
using Microsoft.AspNetCore.Components;
using Pinhua2.BlazorApp.Pages.Components;
using Pinhua2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pinhua2.BlazorApp.Pages.基础数据.报表
{
    public class _CRUDBase : PageComponentBase
    {
        protected readonly string routeA = "/基础数据/报表";
        protected readonly string route全部订单 = "/基础数据/报表/全部订单";
        protected readonly string route全部订单收发 = "/基础数据/报表/全部订单收发";
        protected readonly string route全部金额收付 = "/基础数据/报表/全部金额收付";
        protected readonly string route订单数量收发 = "/基础数据/报表/订单数量收发";
        protected readonly string route销售订单待发 = "/基础数据/报表/销售订单待发";
        protected readonly string route采购订单待收 = "/基础数据/报表/采购订单待收";
        protected readonly string route销售金额待收 = "/基础数据/报表/销售金额待收";
        protected readonly string route采购金额待付 = "/基础数据/报表/采购金额待付";
        protected readonly string route库存 = "/基础数据/报表/库存";
        protected readonly string route库批存 = "/基础数据/报表/库批存";
        protected readonly string route最新报价 = "/基础数据/报表/最新报价";
        protected readonly string route最新单价 = "/基础数据/报表/最新单价";
    }
}
