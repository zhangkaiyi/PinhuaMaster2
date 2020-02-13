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
    public class dto销售订单 : _BaseTableMain
    {
        [CustomDisplay(10)]
        [MyPriority(Priority.High)]
        public string 单号 { get; set; }

        [CustomDisplay(20)]
        [MyPriority(Priority.High)]
        [MyHiddenCreate]
        public string 业务类型 { get; set; }

        [CustomDisplay(ForIndex = false)]
        [MyPriority(Priority.High)]
        [MyHiddenCreate]
        public string 仓 { get; set; }

        [Required]
        [CustomDisplay(30)]
        [MyPriority(Priority.High)]
        public DateTime? 日期 { get; set; }

        [Required]
        [CustomDisplay(40)]
        [MyPriority(Priority.High)]
        public DateTime? 交期 { get; set; }

        [CustomDisplay(50)]
        [MyPriority(Priority.High)]
        public string 备注 { get; set; }

        [CustomDisplay(21)]
        [Display(Name = "客户名")]
        [MyPriority(Priority.High)]
        [MyHiddenCreate]
        public string 往来 { get; set; }

        [Required]
        [CustomDisplay(20)]
        [Display(Name = "客户号")]
        [MyPriority(Priority.High)]
        [MyViewComponent("SelectForCompany")]
        public string 往来号 { get; set; }

        [CustomDisplay(9)]
        [MyPriority(Priority.High)]
        public string 报价单 { get; set; }

        public bool 来自报价单 { get; set; }

        [CustomDisplay(25)]
        [MyPriority(Priority.Medium)]
        public decimal? 应收 { get; set; }

        [CustomDisplay(26)]
        [MyPriority(Priority.Medium)]
        public string 已收 { get; set; }

        [CustomDisplay(27)]
        [MyPriority(Priority.Medium)]
        public string 待收 { get; set; }
    }

    public class dto销售订单D : _BaseProductDetail
    {
        [MyHiddenIndex, MyHiddenCreate, MyHiddenDetails, MyHiddenEdit]
        public decimal? 库存 { get; set; }
        public string 单位 { get; set; }
        public decimal? 个数 { get; set; }
        public decimal? 数量 { get; set; }
        public decimal? 单价 { get; set; }
        [MyVueComputed]
        public decimal? 金额 { get; set; }
        [MyHiddenIndex, MyHiddenCreate, MyHiddenDetails, MyHiddenEdit]
        public decimal? 税率 { get; set; }
        public string 备注 { get; set; }
        [MyHiddenIndex, MyHiddenCreate, MyHiddenDetails, MyHiddenEdit]
        public decimal? 最新价 { get; set; }
        [MyHiddenIndex, MyHiddenCreate, MyHiddenDetails, MyHiddenEdit]
        public DateTime? 新价日期 { get; set; }
        [MyHiddenIndex, MyHiddenCreate, MyHiddenDetails, MyHiddenEdit]
        public string 品牌 { get; set; }
        public string 状态 { get; set; }
        [MyHiddenIndex, MyHiddenCreate, MyHiddenDetails, MyHiddenEdit]
        public string 质保 { get; set; }
    }

    public class vm_D
    {
        public vm_D()
        {
            D = new dto销售订单D();
            P = new tb_商品表();
        }
        public dto销售订单D D { get; set; }
        public tb_商品表 P { get; set; }
    }


    public class Profile_销售订单 : Profile
    {
        public Profile_销售订单()
        {
            CreateMap<tb_订单表, dto销售订单>();
            CreateMap<tb_订单表D, dto销售订单D>();
            CreateMap<tb_商品表, dto销售订单D>();

            CreateMap<dto销售订单, tb_订单表>()
                .BeforeMap((src, dst) =>
                {
                })
                .AfterMap((src, dst) =>
                {
                    dst.报价单 = src.报价单 ?? string.Empty;
                    dst.备注 = src.备注 ?? string.Empty;
                    dst.应收 = src.应收 ?? 0;
                });
            CreateMap<dto销售订单D, tb_订单表D>()
                .ForMember(dst => dst.Idx, map => map.Ignore()); // 不映射自增主键

            CreateMap<dto商品, dto销售订单D>();

            CreateMap<dto销售报价D, dto销售订单D>()
                .ForMember(dst => dst.Idx, map => map.Ignore()); // 不映射自增主键
        }
    }
}
