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
    public class vm_采购订单 : _BaseTableMain
    {
        [CustomDisplay(10)]
        [MyMinWidth(100)]
        [MyPrimary]
        public string 单号 { get; set; }

        [CustomDisplay(20)]
        [MyMinWidth(100)]
        [MyPrimary]
        public string 业务类型 { get; set; }

        [CustomDisplay(ForIndex = false, ForRead = false)]
        public string 仓 { get; set; }

        [Required]
        [CustomDisplay(30)]
        [MyMinWidth(120)]
        [MyPrimary]
        public DateTime? 日期 { get; set; }

        [Required]
        [CustomDisplay(40)]
        [MyMinWidth(120)]
        [MyPrimary]
        public DateTime? 交期 { get; set; }

        [CustomDisplay(50)]
        [MyMinWidth(120)]
        [MyPrimary]
        public string 备注 { get; set; }

        [CustomDisplay(21)]
        [MyPrimary]
        [Display(Name = "客户名")]
        [MyMinWidth(100)]
        [MyEditable]
        public string 往来 { get; set; }

        [Required]
        [CustomDisplay(20)]
        [Display(Name = "客户号")]
        [MyMinWidth(100)]
        [MyPrimary]
        public string 往来号 { get; set; }

        [CustomDisplay(9)]
        [Display(Name = "询价单")]
        [MyMinWidth(100)]
        [MyPrimary]
        public string 报价单 { get; set; }

        [CustomDisplay(25)]
        [MyMinWidth(100)]
        [MyPrimary]
        public decimal? 应付 { get; set; }
    }

    public class vm_采购订单D : _BaseTableDetail
    {
        public string 品号 { get; set; }
        public string 品名 { get; set; }
        public string 别名 { get; set; }
        public string 型号 { get; set; }
        public string 规格 { get; set; }
        public decimal? 长度 { get; set; }
        public decimal? 宽度 { get; set; }
        public decimal? 高度 { get; set; }
        public decimal? 面厚 { get; set; }
        public decimal? 库存 { get; set; }
        public string 单位 { get; set; }
        public decimal? 个数 { get; set; }
        public decimal? 数量 { get; set; }
        public decimal? 单价 { get; set; }
        public decimal? 金额 { get; set; }
        public decimal? 税率 { get; set; }
        public string 备注 { get; set; }
        public string 品牌 { get; set; }
        public string 状态 { get; set; }
    }

    public class 采购订单Profile : Profile
    {
        public 采购订单Profile()
        {
            CreateMap<tb_订单表, vm_采购订单>();
            //.ForMember(dst => dst.报价单, map => map.MapFrom(src => src.报价单));
            CreateMap<vm_采购订单, tb_订单表>()
                .BeforeMap((src, dst) =>
                {
                })
                .AfterMap((src, dst) =>
                {
                    dst.报价单 = src.报价单 ?? string.Empty;
                    dst.备注 = src.备注 ?? string.Empty;
                    dst.应付 = src.应付 ?? 0;
                });


            CreateMap<tb_订单表D, vm_采购订单D>();
            CreateMap<vm_采购订单D, tb_订单表D>()
                .ForMember(dst => dst.Idx, map => map.Ignore()); // 不映射自增主键
        }
    }
}
