using AutoMapper;
using Pinhua2.Common.Attributes;
using Pinhua2.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pinhua2.ViewModels
{
    public class dto收款单 : _BaseTableMain
    {
        public string 关联单号 { get; set; }

        public string 单号 { get; set; }

        [Required] public string 往来号 { get; set; }

        public  string 往来 { get; set; }

        [Required] public DateTime? 日期 { get; set; }

        [Display(Name = "大类")]
        [Required] public string 类型 { get; set; }

        [Required] public string 小类 { get; set; }

        [Display(Name = "金额")]
        [Required] public decimal? 收 { get; set; }

        [Required] public decimal? 分配 { get; set; }

        public string 发票号 { get; set; }

        public string 备注 { get; set; }
    }

    public class dto收款单D : _BaseProductDetail
    {
        public decimal? 个数 { get; set; }
        public decimal? 数量 { get; set; }
        public string 单位 { get; set; }
        public decimal? 单价 { get; set; }
        public decimal? 金额 { get; set; }
        public decimal? 已收款额 { get; set; }
        public decimal? 待收款额 { get; set; }
        public decimal? 可分配 { get; set; }
        [Required] public decimal? 分配金额 { get; set; }
        public string 备注 { get; set; }
    }

    public class 收款单Profile : Profile
    {
        public 收款单Profile()
        {
            CreateMap<tb_收付表, dto收款单>();
            CreateMap<dto收款单, tb_收付表>();

            CreateMap<tb_收付表D, dto收款单D>()
                .ForMember(dst => dst.已收款额, map => map.MapFrom(src => src.已收付款额))
                .ForMember(dst => dst.待收款额, map => map.MapFrom(src => src.待收付款额))
                .ForMember(dst => dst.可分配, map => map.MapFrom(src => src.可收付款额))
                .ForMember(dst => dst.分配金额, map => map.MapFrom(src => src.本次收额));
            CreateMap<dto收款单D, tb_收付表D>()
                .ForMember(dst => dst.已收付款额, map => map.MapFrom(src => src.已收款额))
                .ForMember(dst => dst.待收付款额, map => map.MapFrom(src => src.待收款额))
                .ForMember(dst => dst.可收付款额, map => map.MapFrom(src => src.可分配))
                .ForMember(dst => dst.本次收额, map => map.MapFrom(src => src.分配金额));
            CreateMap<view_AllOrdersPay, dto收款单D>()
                .ForMember(dst => dst.已收款额, map => map.MapFrom(src => src.已收))
                .ForMember(dst => dst.待收款额, map => map.MapFrom(src => src.待收));
            CreateMap<dto收款单D, view_AllOrdersPay>()
                .ForMember(dst => dst.已收, map => map.MapFrom(src => src.已收款额))
                .ForMember(dst => dst.待收, map => map.MapFrom(src => src.待收款额));
        }
    }
}
