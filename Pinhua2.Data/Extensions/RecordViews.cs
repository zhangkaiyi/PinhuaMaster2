using Microsoft.EntityFrameworkCore;
using Pinhua2.Data.Models;
using Pinhua2.Data.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Newtonsoft.Json.Linq;

namespace Pinhua2.Data
{
    public static class RecordViewsExtension
    {
        public static List<view_AllOrdersPay> View订单金额收付(this Pinhua2Context context)
        {
            var l = from m in context.view_全部订单()
                    join x in context.view_订单收付() on m.子单号 equals x.子单号 into vTemp
                    from v in vTemp.DefaultIfEmpty()
                    select new view_AllOrdersPay
                    {
                        RecordId = m.RecordId,
                        业务类型 = m.业务类型,
                        交期 = m.交期,
                        仓 = m.仓,
                        制单 = m.制单,
                        单价 = m.单价,
                        单位 = m.单位,
                        单号 = m.单号,
                        品号 = m.品号,
                        数量 = m.数量,
                        品名 = m.品名,
                        品牌 = m.品牌,
                        备注 = m.备注,
                        子单号 = m.子单号,
                        往来 = m.往来,
                        往来号 = m.往来号,
                        个数 = m.个数,
                        型号 = m.型号,
                        日期 = m.日期,
                        状态 = m.状态,
                        税率 = m.税率,
                        规格 = m.规格,
                        长度 = m.长度,
                        宽度 = m.宽度,
                        高度 = m.高度,
                        面厚 = m.面厚,
                        质保 = m.质保,
                        金额 = m.金额,
                        已收 = v?.收 ?? 0,
                        待收 = (m.金额 ?? 0) - (v?.收 ?? 0),
                        已付 = v?.付 ?? 0,
                        待付 = (m.金额 ?? 0) - (v?.付 ?? 0),
                    };

            return l.ToList();
        }

        public static List<view_AllOrdersIO> View订单数量收发(this Pinhua2Context context)
        {
            var l = from m in context.view_全部订单()
                    join x in context.view_订单收发() on m.子单号 equals x.子单号 into vTemp
                    from v in vTemp.DefaultIfEmpty()
                    select new view_AllOrdersIO
                    {
                        RecordId = m.RecordId,
                        业务类型 = m.业务类型,
                        交期 = m.交期,
                        仓 = m.仓,
                        制单 = m.制单,
                        单价 = m.单价,
                        单位 = m.单位,
                        单号 = m.单号,
                        型号 = m.型号,
                        品号 = m.品号,
                        品名 = m.品名,
                        品牌 = m.品牌,
                        备注 = m.备注,
                        子单号 = m.子单号,
                        往来 = m.往来,
                        往来号 = m.往来号,
                        个数 = m.个数,
                        数量 = m.数量,
                        日期 = m.日期,
                        状态 = m.状态,
                        税率 = m.税率,
                        规格 = m.规格,
                        长度 = m.长度,
                        宽度 = m.宽度,
                        高度 = m.高度,
                        面厚 = m.面厚,
                        质保 = m.质保,
                        金额 = m.金额,
                        已收 = v?.收 ?? 0,
                        待收 = (m.个数 ?? 0) - (v?.收 ?? 0),
                        已发 = v?.发 ?? 0,
                        待发 = (m.个数 ?? 0) - (v?.发 ?? 0),
                    };

            return l.ToList();
        }

    }
}
