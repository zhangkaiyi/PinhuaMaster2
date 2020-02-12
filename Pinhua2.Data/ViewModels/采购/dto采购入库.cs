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
    public class dto采购入库 : _BaseTableMain
    {
        public string 单号 { get; set; }

        public string 类型 { get; set; }

        [Required] public DateTime? 日期 { get; set; }

        public string 备注 { get; set; }

        [Display(Name = "客户名")]
        public string 往来 { get; set; }

        [Required] public string 往来号 { get; set; }

        public string 退单 { get; set; }

        public string 物流单号 { get; set; }

        public string 仓 { get; set; }
    }

    public class dto采购入库D : _BaseProductDetail
    {
        public string 品牌 { get; set; }
        public string 单位 { get; set; }
        public decimal? 单价 { get; set; }
        public decimal? 金额 { get; set; }
        public decimal? 税率 { get; set; }
        public string 备注 { get; set; }
        public decimal? 质保 { get; set; }
        public string 批次 { get; set; }
        public string 条码 { get; set; }
        public string 库位 { get; set; }
        public string 库存 { get; set; }
        public string 仓 { get; set; }
        public decimal? 个数 { get; set; }
        public decimal? 数量 { get; set; }
        public decimal? 计划数 { get; set; }
        public decimal? 已完数 { get; set; }
    }

    public class 采购入库Profile : Profile
    {
        public 采购入库Profile()
        {
            CreateMap<tb_IO, dto采购入库>();
            //.ForMember(dst => dst.报价单, map => map.MapFrom(src => src.报价单));
            CreateMap<dto采购入库, tb_IO>()
                .BeforeMap((src, dst) =>
                {
                })
                .AfterMap((src, dst) =>
                {
                    dst.备注 = src.备注 ?? string.Empty;
                    dst.物流单号 = src.物流单号 ?? string.Empty;
                });


            CreateMap<tb_IOD, dto采购入库D>()
                .ForMember(dst => dst.个数, map => map.MapFrom(src => src.收));
            CreateMap<dto采购入库D, tb_IOD>()
                .ForMember(dst => dst.收, map => map.MapFrom(src => src.个数))
                .ForMember(dst => dst.Idx, map => map.Ignore()); // 不映射自增主键

            CreateMap<dto采购入库D, tb_订单表D>()
                .ForMember(dst => dst.个数, map => map.MapFrom(src => src.个数));
            CreateMap<tb_订单表D, dto采购入库D>()
                .ForMember(dst => dst.个数, map => map.MapFrom(src => src.个数))
                .ForMember(dst => dst.Idx, map => map.Ignore()); // 不映射自增主键

            CreateMap<dto采购订单D, dto采购入库D>()
                .ForMember(dst => dst.Idx, map => map.Ignore()); // 不映射自增主键

            CreateMap<view_AllOrdersIO, dto采购入库D>();
            CreateMap<dto采购入库D, view_AllOrdersIO>();
        }
    }
}
