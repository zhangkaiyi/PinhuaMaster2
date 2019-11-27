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
    public class vm_付款单 : _BaseTableMain
    {
        [MyPriority(Priority.High)]
        [CustomDisplay(10)]
        public string 类型 { get; set; }

        [MyPriority(Priority.High)]
        [CustomDisplay(20)]
        public string 单号 { get; set; }

        [MyPriority(Priority.High)]
        [Required]
        [CustomDisplay(25, ForIndex = false)]
        public string 往来号 { get; set; }

        [MyPriority(Priority.High)]
        [CustomDisplay(26)]
        public string 往来 { get; set; }

        [MyPriority(Priority.High)]
        [CustomDisplay(27)]
        public string 小类 { get; set; }

        [MyPriority(Priority.High)]
        [CustomDisplay(28)]
        public string 关联单号 { get; set; }

        [MyPriority(Priority.High)]
        [Required]
        [CustomDisplay(30)]
        public decimal? 付 { get; set; }

        [MyPriority(Priority.High)]
        [CustomDisplay(40)]
        public DateTime? 日期 { get; set; }

        [MyPriority(Priority.High)]
        public string 备注 { get; set; }

        [MyPriority(Priority.High)]
        [CustomDisplay(31)]
        public decimal? 分配 { get; set; }

        [MyPriority(Priority.High)]
        [CustomDisplay(ForIndex = false)]
        public string 发票号 { get; set; }
    }

    public class vm_付款单D : _BaseProductDetail
    {
        public decimal? 个数 { get; set; }
        public decimal? 数量 { get; set; }
        public string 单位 { get; set; }
        public decimal? 金额 { get; set; }
        public decimal? 已付款额 { get; set; }
        public decimal? 待付款额 { get; set; }
        public decimal? 可分配 { get; set; }
        [Required]
        public decimal? 分配金额 { get; set; }
        public string 备注 { get; set; }
    }

    public class 付款单Profile : Profile
    {
        public 付款单Profile()
        {
            CreateMap<tb_收付表, vm_付款单>();
            CreateMap<vm_付款单, tb_收付表>();

            CreateMap<tb_收付表D, vm_付款单D>()
                .ForMember(dst => dst.已付款额, map => map.MapFrom(src => src.已收付款额))
                .ForMember(dst => dst.待付款额, map => map.MapFrom(src => src.待收付款额))
                .ForMember(dst => dst.可分配, map => map.MapFrom(src => src.可收付款额))
                .ForMember(dst => dst.分配金额, map => map.MapFrom(src => src.本次收额));
            CreateMap<vm_付款单D, tb_收付表D>()
                .ForMember(dst => dst.已收付款额, map => map.MapFrom(src => src.已付款额))
                .ForMember(dst => dst.待收付款额, map => map.MapFrom(src => src.待付款额))
                .ForMember(dst => dst.可收付款额, map => map.MapFrom(src => src.可分配))
                .ForMember(dst => dst.本次收额, map => map.MapFrom(src => src.分配金额));
        }
    }
}
