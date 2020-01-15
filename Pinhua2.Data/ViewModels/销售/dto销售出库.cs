using AutoMapper;
using Pinhua2.Data.Models;
using Pinhua2.Common.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pinhua2.ViewModels
{
    public class dto销售出库 : _BaseTableMain
    {
        [CustomDisplay(10)]
        [MyPriority(Priority.High)]
        public string 单号 { get; set; }

        [CustomDisplay(20)]
        [MyPriority(Priority.High)]
        public string 类型 { get; set; }

        [Required]
        [CustomDisplay(30)]
        [MyPriority(Priority.High)]
        public DateTime? 日期 { get; set; }

        [CustomDisplay(50)]
        [MyPriority(Priority.High)]
        public string 备注 { get; set; }

        [CustomDisplay(21)]
        [MyPriority(Priority.High)]
        [Display(Name = "客户名")]
        [MyHiddenCreate]
        public string 往来 { get; set; }

        [Required]
        [CustomDisplay(20)]
        [Display(Name = "客户号")]
        [MyPriority(Priority.High)]
        [MyViewComponent("SelectForCompany")]
        public string 往来号 { get; set; }

        [CustomDisplay(9)]
        [MyPriority(Priority.Medium)]
        public string 退单 { get; set; }

        //[CustomDisplay(44)]
        //public string 订单号 { get; set; }

        [CustomDisplay(45)]
        [MyPriority(Priority.Medium)]
        public string 物流单号 { get; set; }

        [CustomDisplay(ForIndex = false, ForRead = false)]
        [MyHiddenIndex, MyHiddenCreate, MyHiddenDetails, MyHiddenEdit]
        public string 仓 { get; set; }
    }

    public class dto销售出库D : _BaseProductDetail
    {
        [MyHiddenIndex, MyHiddenCreate, MyHiddenDetails, MyHiddenEdit]
        public string 品牌 { get; set; }
        public string 单位 { get; set; }
        public decimal? 单价 { get; set; }
        [MyVueComputed]
        public decimal? 金额 { get; set; }
        [MyHiddenIndex, MyHiddenCreate, MyHiddenDetails, MyHiddenEdit]
        public decimal? 税率 { get; set; }
        public string 备注 { get; set; }
        [MyHiddenIndex, MyHiddenCreate, MyHiddenDetails, MyHiddenEdit]
        public decimal? 质保 { get; set; }
        [MyHiddenIndex, MyHiddenCreate, MyHiddenDetails, MyHiddenEdit]
        public string 批次 { get; set; }
        [MyHiddenIndex, MyHiddenCreate, MyHiddenDetails, MyHiddenEdit]
        public string 条码 { get; set; }
        [MyHiddenIndex, MyHiddenCreate, MyHiddenDetails, MyHiddenEdit]
        public string 库位 { get; set; }
        [MyHiddenIndex, MyHiddenCreate, MyHiddenDetails, MyHiddenEdit]
        public string 库存 { get; set; }
        [MyHiddenIndex, MyHiddenCreate, MyHiddenDetails, MyHiddenEdit]
        public string 仓 { get; set; }

        //[Display(Name = "个数")]
        public decimal? 个数 { get; set; }
        public decimal? 数量 { get; set; }
        public decimal? 计划数 { get; set; }
        public decimal? 已完数 { get; set; }
    }



    public class 销售出库Profile : Profile
    {
        public 销售出库Profile()
        {
            CreateMap<tb_IO, dto销售出库>();
            //.ForMember(dst => dst.报价单, map => map.MapFrom(src => src.报价单));
            CreateMap<dto销售出库, tb_IO>()
                .BeforeMap((src, dst) =>
                {
                })
                .AfterMap((src, dst) =>
                {
                    dst.备注 = src.备注 ?? string.Empty;
                    dst.物流单号 = src.物流单号 ?? string.Empty;
                });


            CreateMap<tb_IOD, dto销售出库D>()
                .ForMember(dst => dst.个数, map => map.MapFrom(src => src.发));
            CreateMap<dto销售出库D, tb_IOD>()
                .ForMember(dst => dst.发, map => map.MapFrom(src => src.个数))
                .ForMember(dst => dst.Idx, map => map.Ignore()); // 不映射自增主键

            CreateMap<dto销售出库D, tb_订单表D>()
                .ForMember(dst => dst.个数, map => map.MapFrom(src => src.个数));
            CreateMap<tb_订单表D, dto销售出库D>()
                .ForMember(dst => dst.个数, map => map.MapFrom(src => src.个数))
                .ForMember(dst => dst.Idx, map => map.Ignore()); // 不映射自增主键
        }
    }
}
