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
        [MyPriority(Priority.High)]
        [CustomDisplay(10)]
        [Display(Name = "大类")]
        public string 类型 { get; set; }

        [MyPriority(Priority.High)]
        [CustomDisplay(15, ForCreate = true, ForUpdate = true)]
        public string 小类 { get; set; }

        [MyPriority(Priority.Medium)]
        [CustomDisplay(5.2, ForCreate = true, ForUpdate = true)]
        public string 关联单号 { get; set; }

        [MyPriority(Priority.High)]
        [CustomDisplay(5.1)]
        public string 单号 { get; set; }

        [MyPriority(Priority.High)]
        [Required]
        [CustomDisplay(25, ForIndex = false)]
        [MyViewComponent("SelectForCompany")]
        virtual public string 往来号 { get; set; }

        [MyPriority(Priority.High)]
        [CustomDisplay(26)]
        [MyHiddenCreate]
        public string 往来 { get; set; }

        [MyPriority(Priority.High)]
        [Required]
        [CustomDisplay(30.2)]
        [MyEditable]
        //[MyVue]
        [MyVueVModel("vm_Main")]
        public decimal? 收 { get; set; }

        [Required]
        [MyPriority(Priority.High)]
        [CustomDisplay(30.1)]
        public DateTime? 日期 { get; set; }

        [MyPriority(Priority.Medium)]
        [MyEditable]
        public string 备注 { get; set; }

        [MyPriority(Priority.Medium)]
        [CustomDisplay(30.3)]
        public decimal? 分配 { get; set; }

        [MyPriority(Priority.High)]
        [CustomDisplay(ForIndex = false)]
        [MyHiddenIndex, MyHiddenCreate, MyHiddenDetails, MyHiddenEdit]
        public string 发票号 { get; set; }
    }

    public class vm_收款单D : _BaseProductDetail
    {
        [MyHiddenRef]
        public decimal? 个数 { get; set; }
        [MyHiddenRef]
        public decimal? 数量 { get; set; }
        [MyHiddenRef]
        public string 单位 { get; set; }
        [MyHiddenRef]
        public decimal? 单价 { get; set; }
        public decimal? 金额 { get; set; }
        public decimal? 已收款额 { get; set; }
        public decimal? 待收款额 { get; set; }
        public decimal? 可分配 { get; set; }
        [Required]
        [MyEditable]
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
            CreateMap<view_AllOrdersPay, vm_收款单D>()
                .ForMember(dst => dst.已收款额, map => map.MapFrom(src => src.已收))
                .ForMember(dst => dst.待收款额, map => map.MapFrom(src => src.待收));
        }
    }
}
