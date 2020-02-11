using Microsoft.EntityFrameworkCore;
using Pinhua2.Data.Models;
using Pinhua2.Data.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Newtonsoft.Json.Linq;
using Pinhua2.ViewModels;

namespace Pinhua2.Data
{
    public class Pinhua2Views_采购
    {
        protected readonly Pinhua2Context _context;
        public Pinhua2Views_采购(Pinhua2Context context)
        {
            _context = context;
        }

        public IQueryable<tb_需求表> 采购申请()
        {
            var result = from m in _context.tb_需求表.AsNoTracking()
                         where m.业务类型 == "采购申请"
                         orderby m.日期 descending, m.往来号 ascending
                         select m;
            return result;
        }

        public IQueryable<tb_需求表D> 采购申请D()
        {
            var result = from m in 采购申请()
                         join d in _context.tb_需求表D.AsNoTracking() on m.RecordId equals d.RecordId
                         orderby d.RecordId descending, d.RN ascending
                         select d;
            return result;
        }

        public IQueryable<tb_需求表D> 采购申请D(int recordId)
        {
            var result = from d in 采购申请D()
                         where d.RecordId == recordId
                         select d;
            return result;
        }

        public List<combo采购申请> 采购申请combo()
        {
            var result = from m in _context.tb_需求表.AsNoTracking()
                         join d in _context.tb_需求表D.AsNoTracking() on m.RecordId equals d.RecordId
                         where m.业务类型 == "采购申请"
                         orderby m.日期 descending, m.往来单号 ascending, d.RN ascending
                         select new combo采购申请
                         {
                             Main = m,
                             Detail = d
                         };
            return result.ToList();
        }

        public IQueryable<tb_报价表> 采购询价()
        {
            var result = from m in _context.tb_报价表.AsNoTracking()
                         where m.业务类型 == "采购询价"
                         orderby m.日期 descending, m.往来号 ascending
                         select m;
            return result;
        }

        public IQueryable<tb_报价表D> 采购询价D()
        {
            var result = from m in 采购询价()
                         join d in _context.tb_报价表D.AsNoTracking() on m.RecordId equals d.RecordId
                         orderby d.RecordId descending, d.RN ascending
                         select d;
            return result;
        }

        public IQueryable<tb_报价表D> 采购询价D(int recordId)
        {
            var result = from d in 采购询价D()
                         where d.RecordId == recordId
                         select d;
            return result;
        }

        public IQueryable<tb_订单表> 采购订单()
        {
            var result = from m in _context.tb_订单表.AsNoTracking()
                         where m.业务类型 == "采购订单"
                         orderby m.日期 descending, m.往来号 ascending
                         select m;
            return result;
        }

        public IQueryable<tb_订单表D> 采购订单D()
        {
            var result = from m in 采购订单()
                         join d in _context.tb_订单表D.AsNoTracking() on m.RecordId equals d.RecordId
                         orderby d.RecordId descending, d.RN ascending
                         select d;
            return result;
        }

        public IQueryable<tb_订单表D> 采购订单D(int recordId)
        {
            var result = from d in 采购订单D()
                         where d.RecordId == recordId
                         select d;
            return result;
        }

        public IQueryable<tb_IO> 采购入库()
        {
            var result = from m in _context.tb_IO.AsNoTracking()
                         where m.类型 == "采购入库"
                         orderby m.日期 descending, m.往来号 ascending
                         select m;
            return result;
        }

        public IQueryable<tb_IOD> 采购入库D()
        {
            var result = from m in 采购入库()
                         join d in _context.tb_IOD.AsNoTracking() on m.RecordId equals d.RecordId
                         orderby d.RecordId descending, d.RN ascending
                         select d;
            return result;
        }

        public IQueryable<tb_IOD> 采购入库D(int recordId)
        {
            var result = from d in 采购入库D()
                         where d.RecordId == recordId
                         select d;
            return result;
        }

        public IQueryable<tb_收付表> 采购付款()
        {
            var result = from m in _context.tb_收付表.AsNoTracking()
                         where m.类型 == "付款"
                         orderby m.日期 descending, m.往来号 ascending
                         select m;
            return result;
        }

        public tb_收付表 采购付款(int recordId)
        {
            return 采购付款().FirstOrDefault(m => m.RecordId == recordId);
        }

        public IQueryable<tb_收付表D> 采购付款D()
        {
            var result = from m in 采购付款()
                         join d in _context.tb_收付表D.AsNoTracking() on m.RecordId equals d.RecordId
                         orderby d.RecordId descending, d.RN ascending
                         select d;
            return result;
        }

        public IQueryable<tb_收付表D> 采购付款D(int recordId)
        {
            var result = from d in 采购付款D()
                         where d.RecordId == recordId
                         select d;
            return result;
        }
    }
}
