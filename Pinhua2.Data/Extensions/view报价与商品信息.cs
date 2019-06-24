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
    public static class view报价与商品信息
    {
        public static JArray Get销售报价商品(this Pinhua2Context context)
        {
            var set = from m in context.tb_报价表.AsNoTracking()
                      join d in context.tb_报价表D.AsNoTracking() on m.RecordId equals d.RecordId
                      join x in context.tb_商品表.AsNoTracking() on d.品号 equals x.品号
                      where m.业务类型 == "销售报价"
                      select new
                      {
                          报 = d,
                          品 = x
                      };
            JArray jsonArray = new JArray();
            foreach (var item in set)
            {
                jsonArray.Add(Pinhua2Helper.JObjectFromMerge(item.报, item.品));
            }

            return jsonArray;
        }

        public static JArray Get销售报价商品(this Pinhua2Context context, string customerId)
        {
            if (string.IsNullOrEmpty(customerId))
                return new JArray();

            var set = from m in context.tb_报价表.AsNoTracking()
                      join d in context.tb_报价表D.AsNoTracking() on m.RecordId equals d.RecordId
                      join x in context.tb_商品表.AsNoTracking() on d.品号 equals x.品号
                      where m.往来号 == customerId && m.业务类型 == "销售报价"
                      select new
                      {
                          报 = d,
                          品 = x
                      };
            JArray jsonArray = new JArray();
            foreach (var item in set)
            {
                jsonArray.Add(Pinhua2Helper.JObjectFromMerge(item.报, item.品));
            }

            return jsonArray;
        }

        public static JArray Get销售报价商品(this Pinhua2Context context, string customerId, string orderId)
        {
            var set = from m in context.tb_报价表.AsNoTracking()
                      join d in context.tb_报价表D.AsNoTracking() on m.RecordId equals d.RecordId
                      join x in context.tb_商品表.AsNoTracking() on d.品号 equals x.品号
                      where /*m.往来号 == customerId &&*/ m.业务类型 == "销售报价" && m.单号 == orderId
                      select new
                      {
                          报 = d,
                          品 = x
                      };
            JArray jsonArray = new JArray();
            foreach (var item in set)
            {
                jsonArray.Add(Pinhua2Helper.JObjectFromMerge(item.报, item.品));
            }

            return jsonArray;
        }

        public static JArray Get销售订单商品(this Pinhua2Context context, string customerId)
        {
            if (string.IsNullOrEmpty(customerId))
                return new JArray();

            var set = from m in context.tb_订单表.AsNoTracking()
                      join d in context.tb_订单表D.AsNoTracking() on m.RecordId equals d.RecordId
                      join x in context.tb_商品表.AsNoTracking() on d.品号 equals x.品号
                      where m.往来号 == customerId && m.业务类型 == "销售订单"
                      select new
                      {
                          订 = d,
                          品 = x
                      };
            JArray jsonArray = new JArray();
            foreach (var item in set)
            {
                jsonArray.Add(Pinhua2Helper.JObjectFromMerge(item.订, item.品));
            }

            return jsonArray;
        }

        public static JArray Get销售订单商品(this Pinhua2Context context, string customerId, string orderId)
        {
            var set = from m in context.tb_订单表.AsNoTracking()
                      join d in context.tb_订单表D.AsNoTracking() on m.RecordId equals d.RecordId
                      join x in context.tb_商品表.AsNoTracking() on d.品号 equals x.品号
                      where /*m.往来号 == customerId &&*/ m.业务类型 == "销售订单" && m.单号 == orderId
                      select new
                      {
                          订 = d,
                          品 = x
                      };
            JArray jsonArray = new JArray();
            foreach (var item in set)
            {
                jsonArray.Add(Pinhua2Helper.JObjectFromMerge(item.订, item.品));
            }

            return jsonArray;
        }

        public static JArray Get销售出库商品(this Pinhua2Context context, string customerId)
        {
            if (string.IsNullOrEmpty(customerId))
                return new JArray();

            var set = from m in context.tb_IO.AsNoTracking()
                      join d in context.tb_IOD.AsNoTracking() on m.RecordId equals d.RecordId
                      join x in context.tb_商品表.AsNoTracking() on d.品号 equals x.品号
                      where m.往来号 == customerId && m.类型 == "销售出库"
                      select new
                      {
                          出 = d,
                          品 = x
                      };
            JArray jsonArray = new JArray();
            foreach (var item in set)
            {
                jsonArray.Add(Pinhua2Helper.JObjectFromMerge(item.出, item.品));
            }

            return jsonArray;
        }

        public static JArray Get销售出库商品(this Pinhua2Context context, string customerId, string orderId)
        {
            var set = from m in context.tb_IO.AsNoTracking()
                      join d in context.tb_IOD.AsNoTracking() on m.RecordId equals d.RecordId
                      join x in context.tb_商品表.AsNoTracking() on d.品号 equals x.品号
                      where /*m.往来号 == customerId &&*/ m.单号 == orderId && m.类型 == "销售出库"
                      select new
                      {
                          出 = d,
                          品 = x
                      };
            JArray jsonArray = new JArray();
            foreach (var item in set)
            {
                jsonArray.Add(Pinhua2Helper.JObjectFromMerge(item.出, item.品));
            }

            return jsonArray;
        }

        public static JArray Get销售收款商品(this Pinhua2Context context, string customerId, string orderId)
        {
            var set = from m in context.tb_收付表.AsNoTracking()
                      join d in context.tb_收付表D.AsNoTracking() on m.RecordId equals d.RecordId
                      //join s in context.tb_IOD.AsNoTracking() on d.子单号 equals s.子单号
                      join x in context.tb_商品表.AsNoTracking() on d.品号 equals x.品号
                      where /*m.往来号 == customerId &&*/ m.单号 == orderId && m.类型 == "收款"
                      select new
                      {
                          收 = d,
                          品 = x
                      };
            JArray jsonArray = new JArray();
            foreach (var item in set)
            {
                jsonArray.Add(Pinhua2Helper.JObjectFromMerge(item.收, item.品));
            }

            return jsonArray;
        }

        public static JArray Get采购订单商品(this Pinhua2Context context, string customerId, string orderId)
        {
            if (orderId == null)
                return new JArray();

            var set = from m in context.tb_订单表.AsNoTracking()
                      join d in context.tb_订单表D.AsNoTracking() on m.RecordId equals d.RecordId
                      join x in context.tb_商品表.AsNoTracking() on d.品号 equals x.品号
                      where /*m.往来号 == customerId &&*/ m.业务类型 == "采购订单" && m.单号 == orderId
                      select new
                      {
                          订 = d,
                          品 = x
                      };
            JArray jsonArray = new JArray();
            foreach (var item in set)
            {
                jsonArray.Add(Pinhua2Helper.JObjectFromMerge(item.订, item.品));
            }

            return jsonArray;
        }
    }
}
