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
    public static partial class Pinhua2ViewsExtension
    {
        public static IList<view_AllOrders> view_全部订单(this Pinhua2Context context)
        {
            var l = from r in context.tb_订单表.AsNoTracking()
                    join rd in context.tb_订单表D.AsNoTracking() on r.RecordId equals rd.RecordId into rdTemp
                    from rd in rdTemp.DefaultIfEmpty()
                    select new view_AllOrders
                    {
                        RecordId = rd.RecordId,
                        业务类型 = r.业务类型,
                        交期 = r.交期,
                        仓 = r.仓,
                        制单 = r.CreateUser,
                        单价 = rd.单价,
                        单位 = rd.单位,
                        单号 = r.单号,
                        品号 = rd.品号,
                        品名 = rd.品名,
                        品牌 = rd.品牌,
                        备注 = r.备注,
                        子单号 = rd.子单号,
                        往来 = r.往来,
                        往来号 = r.往来号,
                        个数 = rd.个数,
                        日期 = r.日期,
                        状态 = rd.状态,
                        税率 = rd.税率,
                        规格 = rd.规格,
                        质保 = rd.质保,
                        金额 = rd.金额
                    };

            return l.ToList();
        }

        public static IList<view_OrderIO> view_订单收发(this Pinhua2Context context)
        {
            var l = from rd in context.tb_IOD.AsNoTracking()
                    group rd by rd.子单号 into g
                    select new view_OrderIO
                    {
                        收 = g.Sum(x => x.收 ?? 0),
                        发 = g.Sum(x => x.发 ?? 0),
                        子单号 = g.Key
                    };

            return l.ToList();
        }

        public static IList<view_AllOrdersIO> view_全部订单收发(this Pinhua2Context context)
        {
            var l = from m in view_全部订单(context)
                    join x in view_订单收发(context) on m.子单号 equals x.子单号 into vTemp
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
                        品号 = m.品号,
                        品名 = m.品名,
                        品牌 = m.品牌,
                        备注 = m.备注,
                        子单号 = m.子单号,
                        往来 = m.往来,
                        往来号 = m.往来号,
                        个数 = m.个数,
                        日期 = m.日期,
                        状态 = m.状态,
                        税率 = m.税率,
                        规格 = m.规格,
                        质保 = m.质保,
                        金额 = m.金额,
                        已收 = v?.收 ?? 0,
                        待收 = m.个数 ?? 0 - v?.收 ?? 0,
                        已发 = v?.发 ?? 0,
                        待发 = m.个数 ?? 0 - v?.发 ?? 0,
                    };

            return l.ToList();
        }

        public static IList<view_Lq> view_库存(this Pinhua2Context context)
        {
            var l = from product in context.tb_商品表.AsNoTracking()
                    join detail in context.tb_IOD.AsNoTracking() on product.品号 equals detail.品号 into detailTemp
                    from lDetail in detailTemp.DefaultIfEmpty()
                    group new { product, lDetail } by new { product.品号, lDetail.库位 } into g
                    select new view_Lq
                    {
                        品号 = g.Key.品号,
                        库位 = g.Key.库位,
                        //库存 = g.Sum(p => p.lDetail == null ? 0 : p.lDetail.收) - g.Sum(p => p.lDetail == null ? 0 : p.lDetail.发)
                        库存 = g.Sum(p => p.lDetail == null ? 0 : p.lDetail.收 ?? 0 - p.lDetail.发 ?? 0)

                    };

            return l.ToList();
        }

        public static IList<view_Lbq> view_库批存(this Pinhua2Context context)
        {
            var l = from detail in context.tb_IOD.AsNoTracking()

                    group detail by new { detail.品号, detail.库位, detail.批次 } into g
                    select new view_Lbq
                    {
                        品号 = g.Key.品号,
                        库位 = g.Key.库位,
                        批次 = g.Key.批次,
                        库存 = g.Sum(p => p.收 ?? 0 - p.发 ?? 0)

                    };

            return l.ToList();
        }

        public static IList<view_LastPrice> view_最新单价(this Pinhua2Context context)
        {
            var o = from m in context.tb_订单表.AsNoTracking()
                    join d in context.tb_订单表D.AsNoTracking() on m.RecordId equals d.RecordId
                    select new
                    {
                        m.RecordId,
                        m.业务类型,
                        m.往来号,
                        d.品号,
                        d.单价,
                        m.日期
                    };
            var l = from p in o
                    where !o.Any(x => x.RecordId > p.RecordId && x.业务类型 == p.业务类型 && x.往来号 == p.往来号 && x.品号 == p.品号) // 不存在更新的RecordId
                    group p by new { p.RecordId, p.业务类型, p.日期, p.往来号, p.品号 } into g
                    select new view_LastPrice
                    {
                        RecordId = g.Key.RecordId,
                        业务类型 = g.Key.业务类型,
                        往来号 = g.Key.往来号,
                        品号 = g.Key.品号,
                        日期 = g.Key.日期,
                        最低价 = g.Min(x => x.单价),
                        最高价 = g.Max(x => x.单价)
                    };


            return l.ToList();
        }

        public static IList<view_LastQue> view_最新报价(this Pinhua2Context context)
        {
            var o = from m in context.tb_报价表.AsNoTracking()
                    join d in context.tb_报价表D.AsNoTracking() on m.RecordId equals d.RecordId
                    select new
                    {
                        m.RecordId,
                        m.业务类型,
                        m.往来号,
                        d.品号,
                        d.单价,
                        m.日期
                    };
            var l = from p in o
                    where !o.Any(x => x.RecordId > p.RecordId && x.业务类型 == p.业务类型 && x.往来号 == p.往来号 && x.品号 == p.品号) // 不存在更新的RecordId
                    group p by new { p.RecordId, p.业务类型, p.日期, p.往来号, p.品号 } into g
                    select new view_LastQue
                    {
                        RecordId = g.Key.RecordId,
                        业务类型 = g.Key.业务类型,
                        往来号 = g.Key.往来号,
                        品号 = g.Key.品号,
                        日期 = g.Key.日期,
                        最低价 = g.Min(x => x.单价),
                        最高价 = g.Max(x => x.单价)
                    };


            return l.ToList();
        }

        public static IList<view_OrderPay> view_订单收付(this Pinhua2Context context)
        {
            var l = from p in context.tb_收付表D.AsNoTracking()
                    where !string.IsNullOrEmpty(p.子单号)
                    group p by p.子单号 into g
                    select new view_OrderPay
                    {
                        收 = g.Sum(x => x.本次收额 ?? 0),
                        付 = g.Sum(x => x.本次付额 ?? 0),
                        子单号 = g.Key
                    };


            return l.ToList();
        }

        public static IList<view_AllOrdersPay> view_全部订单收付(this Pinhua2Context context)
        {
            var l = from m in view_全部订单(context)
                    join x in view_订单收付(context) on m.子单号 equals x.子单号 into vTemp
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
                        品名 = m.品名,
                        品牌 = m.品牌,
                        备注 = m.备注,
                        子单号 = m.子单号,
                        往来 = m.往来,
                        往来号 = m.往来号,
                        个数 = m.个数,
                        日期 = m.日期,
                        状态 = m.状态,
                        税率 = m.税率,
                        规格 = m.规格,
                        质保 = m.质保,
                        金额 = m.金额,
                        已收 = v?.收 ?? 0,
                        待收 = m.金额 ?? 0 - v?.收 ?? 0,
                        已付 = v?.付 ?? 0,
                        待付 = m.金额 ?? 0 - v?.付 ?? 0,
                    };

            return l.ToList();
        }
    }
}
