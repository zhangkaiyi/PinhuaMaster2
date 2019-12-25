using Microsoft.EntityFrameworkCore;
using Pinhua2.Data.Models;
using Pinhua2.Data.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Pinhua2.Data
{
    public static partial class Pinhua2SelectListExtension
    {
        static public IList<SelectListItem> SelectList_地板计量单位(this Pinhua2Context _context)
        {
            var dic = from p in _context.tb_字典表.AsNoTracking()
                      join d in _context.tb_字典表D.AsNoTracking() on p.RecordId equals d.RecordId
                      where p.字典名 == "地板计量单位"
                      select d;

            var unitSelectList = new List<SelectListItem>();

            foreach (var item in dic)
            {
                unitSelectList.Add(new SelectListItem
                {
                    Text = item.名称,
                    Value = item.名称
                });
            }
            return unitSelectList;
        }

        static public IList<SelectListItem> SelectList_客户(this Pinhua2Context _context)
        {
            var customers = _context.tb_往来表.AsNoTracking().Where(c => c.类型 == "客户");

            var customerSelectList = new List<SelectListItem>();

            customerSelectList.Add(new SelectListItem
            {
                Text = "无",
                Value = "",
            });
            foreach (var customer in customers)
            {
                customerSelectList.Add(new SelectListItem
                {
                    Text = customer.往来号 + " - " + customer.简称,
                    Value = customer.往来号
                });
            }
            return customerSelectList;
        }

        static public List<SelectListItem> DropdownOptions_客户(this Pinhua2Context _context)
        {
            var customers = _context.tb_往来表.AsNoTracking().Where(c => c.类型 == "客户");

            var customerSelectList = new List<SelectListItem>();

            foreach (var customer in customers)
            {
                customerSelectList.Add(new SelectListItem
                {
                    Text = customer.往来号 + " - " + customer.简称,
                    Value = customer.往来号
                });
            }
            return customerSelectList;
        }

        static public IList<SelectListItem> SelectList_供应商(this Pinhua2Context _context)
        {
            var customers = _context.tb_往来表.AsNoTracking().Where(c => c.类型 == "供应商");

            var customerSelectList = new List<SelectListItem>();

            customerSelectList.Add(new SelectListItem
            {
                Text = "无",
                Value = "",
            });
            foreach (var customer in customers)
            {
                customerSelectList.Add(new SelectListItem
                {
                    Text = customer.往来号 + " - " + customer.简称,
                    Value = customer.往来号
                });
            }
            return customerSelectList;
        }
    }
}
