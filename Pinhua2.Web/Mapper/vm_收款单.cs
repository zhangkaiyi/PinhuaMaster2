using AutoMapper;
using Pinhua2.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pinhua2.Web.Mapper
{
    public class vm_收款单 : _BaseTableMain
    {
        public string 类型 { get; set; } = "收款";
        public string 往来 { get; set; }
        public string 往来号 { get; set; }
        public decimal? 收 { get; set; }
        public string 单号 { get; set; }
        public DateTime? 日期 { get; set; }
        public string 备注 { get; set; }
        public decimal? 分配 { get; set; }
        public string 发票号 { get; set; }
    }

    public class vm_收款单D : _BaseTableDetail
    {
        public string 描述 { get; set; }
        public decimal? 数量 { get; set; }
        public string 单位 { get; set; }
        public decimal? 金额 { get; set; }
        [Display(Name = "已收款额")]
        public decimal? 已收付款额 { get; set; }
        [Display(Name = "可分配")]
        public decimal? 可收付款额 { get; set; }
        [Display(Name = "待分配")]
        public decimal? 待收付款额 { get; set; }
        [Display(Name = "分配金额")]
        public decimal? 本次收额 { get; set; }
        public string 备注 { get; set; }
    }

    public class 收款单Profile : Profile
    {
        public 收款单Profile()
        {
            CreateMap<tb_收付表, vm_收款单>();
            CreateMap<vm_收款单, tb_收付表>();

            CreateMap<tb_收付表D, vm_收款单D>();
            CreateMap<vm_收款单D, tb_收付表D>();
        }
    }
}
