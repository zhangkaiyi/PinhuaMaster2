using AutoMapper;
using Pinhua2.Common.Attributes;
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
        [CustomDisplay(10)]
        public string 类型 { get; set; } = "收款";
        [CustomDisplay(30)]
        public string 往来 { get; set; }
        [Required]
        [CustomDisplay(ForIndex = false)]
        public string 往来号 { get; set; }
        [Required]
        [CustomDisplay(30)]
        public decimal? 收 { get; set; }
        [CustomDisplay(20)]
        public string 单号 { get; set; }
        public DateTime? 日期 { get; set; }
        public string 备注 { get; set; }
        [CustomDisplay(31)]
        public decimal? 分配 { get; set; }
        [CustomDisplay(ForIndex = false)]
        public string 发票号 { get; set; }
    }

    public class vm_收款单D : _BaseTableDetail
    {
        public string 品号 { get; set; }
        public string 型号 { get; set; }
        public string 品名 { get; set; }
        public string 别名 { get; set; }
        public decimal? 个数 { get; set; }
        public decimal? 数量 { get; set; }
        public string 单位 { get; set; }
        public decimal? 金额 { get; set; }
        public decimal? 已收款额 { get; set; }
        public decimal? 待收款额 { get; set; }
        public decimal? 可分配 { get; set; }
        public decimal? 分配金额 { get; set; }
        public string 备注 { get; set; }
    }

    public class 收款单Profile : Profile
    {
        public 收款单Profile()
        {
            CreateMap<tb_收付表, vm_收款单>();
            CreateMap<vm_收款单, tb_收付表>();

            CreateMap<tb_收付表D, vm_收款单D>()
                .ForMember(dst => dst.已收款额, map => map.MapFrom(src => src.已收付款额))
                .ForMember(dst => dst.待收款额, map => map.MapFrom(src => src.待收付款额))
                .ForMember(dst => dst.可分配, map => map.MapFrom(src => src.可收付款额))
                .ForMember(dst => dst.分配金额, map => map.MapFrom(src => src.本次收额));
            CreateMap<vm_收款单D, tb_收付表D>()
                .ForMember(dst => dst.已收付款额, map => map.MapFrom(src => src.已收款额))
                .ForMember(dst => dst.待收付款额, map => map.MapFrom(src => src.待收款额))
                .ForMember(dst => dst.可收付款额, map => map.MapFrom(src => src.可分配))
                .ForMember(dst => dst.本次收额, map => map.MapFrom(src => src.分配金额));
        }
    }
}
