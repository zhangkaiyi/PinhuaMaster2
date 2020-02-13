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
    public class dto采购询价 : _BaseTableMain
    {
        public string 单号 { get; set; }

        public string 业务类型 { get; set; } = "采购询价";

        public string 需求单 { get; set; }
        public bool 来自需求单 { get; set; }

        [Display(Name = "供应商名")]
        public string 往来 { get; set; }

        [Display(Name = "供应商号")]
        [Required] public string 往来号 { get; set; }

        [Required] public DateTime? 日期 { get; set; }

        [Required] public DateTime? 交期 { get; set; }

        public string 备注 { get; set; }
    }

    public class dto采购询价D : _BaseProductDetail
    {
        public decimal? 库存 { get; set; }
        public decimal? 个数 { get; set; }
        public decimal? 数量 { get; set; }
        public string 单位 { get; set; }
        public decimal? 单价 { get; set; }
        public decimal? 金额 { get; set; }
        public decimal? 税率 { get; set; }
        public string 备注 { get; set; }
        public decimal? 上次价 { get; set; }
        public DateTime? 上次日期 { get; set; }
        public string 品牌 { get; set; }
        public string 状态 { get; set; }
    }

    public class 采购询价Profile : Profile
    {
        public 采购询价Profile()
        {
            CreateMap<tb_报价表, dto采购询价>();
            CreateMap<dto采购询价, tb_报价表>();

            CreateMap<tb_报价表D, dto采购询价D>()
                .ForMember(dst => dst.Idx, map => map.Ignore());

            CreateMap<dto采购询价D, tb_报价表D>()
                .ForMember(dst => dst.Idx, map => map.Ignore()); // 不映射自增主键

            CreateMap<tb_需求表D, dto采购询价D>()
                .ForMember(dst => dst.Idx, map => map.Ignore());

            CreateMap<dto采购申请D, dto采购询价D>()
                .ForMember(dst => dst.状态, map => map.Ignore())
                .ForMember(dst => dst.Idx, map => map.Ignore());

            CreateMap<dto商品, dto采购询价D>()
                .ForMember(dst => dst.Idx, map => map.Ignore());
        }
    }
}
