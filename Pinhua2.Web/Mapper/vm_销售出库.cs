using AutoMapper;
using Pinhua2.Data.Models;
using Pinhua2.Common.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pinhua2.Web.Mapper
{
    public class vm_销售出库 : _BaseTableMain
    {
        [CustomDisplay(10)]
        [MyPrimary]
        public string 单号 { get; set; }

        [CustomDisplay(20)]
        [MyPrimary]
        public string 类型 { get; set; }

        [Required]
        [CustomDisplay(30)]
        [MyPrimary]
        public DateTime? 日期 { get; set; }

        [CustomDisplay(50)]
        [MyPrimary]
        public string 备注 { get; set; }

        [CustomDisplay(21)]
        [Display(Name = "客户名")]
        [MyPrimary]
        public string 往来 { get; set; }

        [Required]
        [CustomDisplay(20)]
        [Display(Name = "客户号")]
        [MyPrimary]
        public string 往来号 { get; set; }

        [CustomDisplay(9)]
        [MyPrimary]
        public string 退单 { get; set; }

        //[CustomDisplay(44)]
        //public string 订单号 { get; set; }

        [CustomDisplay(45)]
        [MyPrimary]
        public string 物流单号 { get; set; }

        [CustomDisplay(ForIndex = false, ForRead = false)]
        public string 仓 { get; set; }
    }

    public class vm_销售出库D : _BaseTableDetail
    {
        public string 品号 { get; set; }
        public string 品名 { get; set; }
        public string 品牌 { get; set; }
        public string 单位 { get; set; }
        public decimal? 单价 { get; set; }
        public decimal? 金额 { get; set; }
        public decimal? 税率 { get; set; }
        public string 备注 { get; set; }
        public decimal? 质保 { get; set; }
        public string 批次 { get; set; }
        public string 条码 { get; set; }
        public string 规格 { get; set; }
        public string 库位 { get; set; }
        public string 库存 { get; set; }
        public string 仓 { get; set; }

        [Display(Name = "个数")]
        public decimal? 发 { get; set; }
        public decimal? 计划数 { get; set; }
        public decimal? 已完数 { get; set; }
    }



    public class 销售出库Profile : Profile
    {
        public 销售出库Profile()
        {
            CreateMap<tb_IO, vm_销售出库>();
            //.ForMember(dst => dst.报价单, map => map.MapFrom(src => src.报价单));
            CreateMap<vm_销售出库, tb_IO>()
                .BeforeMap((src, dst) =>
                {
                })
                .AfterMap((src, dst) =>
                {
                    dst.备注 = src.备注 ?? string.Empty;
                    dst.物流单号 = src.物流单号 ?? string.Empty;
                });


            CreateMap<tb_IOD, vm_销售出库D>();
            CreateMap<vm_销售出库D, tb_IOD>()
                .ForMember(dst => dst.Idx, map => map.Ignore()); // 不映射自增主键
        }
    }
}
