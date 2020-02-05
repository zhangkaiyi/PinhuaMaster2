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
    public class Pinhua2Views_基础
    {
        protected readonly Pinhua2Context _context;
        public Pinhua2Views_基础(Pinhua2Context context)
        {
            _context = context;
        }

        public IQueryable<tb_商品表> 商品()
        {
            var result = from m in _context.tb_商品表.AsNoTracking()
                         orderby m.品号 descending
                         select m;
            return result;
        }

        public tb_商品表 商品(int recordId)
        {
            var result = 商品().FirstOrDefault(m => m.RecordId == recordId);
            return result;
        }

        public IQueryable<tb_往来表> 往来()
        {
            var result = from m in _context.tb_往来表.AsNoTracking()
                         orderby m.RecordId descending
                         select m;
            return result;
        }
    }
}
