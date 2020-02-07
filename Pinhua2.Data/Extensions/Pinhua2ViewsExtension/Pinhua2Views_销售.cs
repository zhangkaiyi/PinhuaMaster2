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
    public class Pinhua2Views_销售
    {
        protected readonly Pinhua2Context _context;
        public Pinhua2Views_销售(Pinhua2Context context)
        {
            _context = context;
        }

        public IQueryable<tb_报价表> 销售报价()
        {
            var result = from m in _context.tb_报价表.AsNoTracking()
                         where m.业务类型 == "销售报价"
                         orderby m.日期 descending, m.往来号 ascending
                         select m;
            return result;
        }

        public IQueryable<tb_报价表D> 销售报价D()
        {
            var result = from m in 销售报价()
                         join d in _context.tb_报价表D.AsNoTracking() on m.RecordId equals d.RecordId
                         orderby d.RecordId descending, d.RN ascending
                         select d;
            return result;
        }

        public List<combo销售报价> 销售报价combo()
        {
            var result = from m in _context.tb_报价表.AsNoTracking()
                         join d in _context.tb_报价表D.AsNoTracking() on m.RecordId equals d.RecordId
                         where m.业务类型 == "销售报价"
                         orderby m.日期 descending, m.往来号 ascending
                         select new combo销售报价
                         {
                             Main = m,
                             Detail = d
                         };
            return result.ToList();
        }

        public IQueryable<tb_报价表D> 销售报价D(int recordId)
        {
            var result = from d in 销售报价D()
                         where d.RecordId == recordId
                         select d;
            return result;
        }

        public IQueryable<tb_订单表> 销售订单()
        {
            var result = from m in _context.tb_订单表.AsNoTracking()
                         where m.业务类型 == "销售订单"
                         orderby m.日期 descending, m.往来号 ascending
                         select m;
            return result;
        }

        public IQueryable<tb_订单表D> 销售订单D()
        {
            var result = from m in 销售订单()
                         join d in _context.tb_订单表D.AsNoTracking() on m.RecordId equals d.RecordId
                         orderby d.RecordId descending, d.RN ascending
                         select d;
            return result;
        }

        public IQueryable<tb_订单表D> 销售订单D(int recordId)
        {
            var result = from d in 销售订单D()
                         where d.RecordId == recordId
                         select d;
            return result;
        }

        public List<combo销售订单> 销售订单combo()
        {
            var result = from m in _context.tb_订单表.AsNoTracking()
                         join d in _context.tb_订单表D.AsNoTracking() on m.RecordId equals d.RecordId
                         where m.业务类型 == "销售订单"
                         orderby m.日期 descending, m.往来号 ascending
                         select new combo销售订单
                         {
                             Main = m,
                             Detail = d
                         };
            return result.ToList();
        }

        public IQueryable<tb_IO> 销售出库()
        {
            var result = from m in _context.tb_IO.AsNoTracking()
                         where m.类型 == "销售出库"
                         orderby m.日期 descending, m.往来号 ascending
                         select m;
            return result;
        }

        public tb_IO 销售出库(int recordId)
        {
            return 销售出库().FirstOrDefault(m => m.RecordId == recordId);
        }

        public IQueryable<tb_IOD> 销售出库D()
        {
            var result = from m in 销售出库()
                         join d in _context.tb_IOD.AsNoTracking() on m.RecordId equals d.RecordId
                         orderby d.RecordId descending, d.RN ascending
                         select d;
            return result;
        }

        public IQueryable<tb_IOD> 销售出库D(int recordId)
        {
            var result = from d in 销售出库D()
                         where d.RecordId == recordId
                         select d;
            return result;
        }

        public IQueryable<tb_收付表> 销售收款()
        {
            var result = from m in _context.tb_收付表.AsNoTracking()
                         where m.类型 == "收款"
                         orderby m.日期 descending, m.往来号 ascending
                         select m;
            return result;
        }

        public tb_收付表 销售收款(int recordId)
        {
            return 销售收款().FirstOrDefault(m => m.RecordId == recordId);
        }

        public IQueryable<tb_收付表D> 销售收款D()
        {
            var result = from m in 销售收款()
                         join d in _context.tb_收付表D.AsNoTracking() on m.RecordId equals d.RecordId
                         orderby d.RecordId descending, d.RN ascending
                         select d;
            return result;
        }

        public IQueryable<tb_收付表D> 销售收款D(int recordId)
        {
            var result = from d in 销售收款D()
                         where d.RecordId == recordId
                         select d;
            return result;
        }
    }
}
