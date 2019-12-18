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
    public class dto销售报价 : _BaseTableMain
    {
        [CustomDisplay(10)]
        [MyPriority(Priority.High)]
        public string 单号 { get; set; }

        [CustomDisplay(20)]
        [MyPriority(Priority.High)]
        [MyHiddenCreate]
        public string 业务类型 { get; set; }

        [Required]
        [CustomDisplay(50)]
        [MyEditable]
        [MyPriority(Priority.High)]
        public DateTime? 日期 { get; set; }

        [Required]
        [CustomDisplay(60)]
        [MyEditable]
        [MyPriority(Priority.High)]
        public DateTime? 交期 { get; set; }

        [CustomDisplay(70)]
        [MyEditable]
        [MyPriority(Priority.High)]
        public string 备注 { get; set; }

        [CustomDisplay(40)]
        [Display(Name = "客户名")]
        [MyPriority(Priority.High)]
        [MyHiddenCreate]
        public string 往来 { get; set; }

        [Required]
        [CustomDisplay(30)]
        [Display(Name = "客户号")]
        [MyPriority(Priority.High)]
        [MyViewComponent("SelectForCompany")]
        public string 往来号 { get; set; }
    }

    public class dto销售报价D : _BaseProductDetail
    {
        [CustomDisplay(ForIndex = false, ForCreate = false)]
        [MyHiddenIndex, MyHiddenCreate, MyHiddenDetails, MyHiddenEdit]
        public decimal? 库存 { get; set; }
        public decimal? 个数 { get; set; }
        public decimal? 数量 { get; set; }
        public string 单位 { get; set; }
        public decimal? 单价 { get; set; }
        [MyVueComputed]
        public decimal? 金额 { get; set; }

        [CustomDisplay(ForIndex = false, ForCreate = false)]
        [MyHiddenIndex, MyHiddenCreate, MyHiddenDetails, MyHiddenEdit]
        public decimal? 税率 { get; set; }
        public string 备注 { get; set; }

        [CustomDisplay(ForIndex = false, ForCreate = false)]
        [MyHiddenIndex, MyHiddenCreate, MyHiddenDetails, MyHiddenEdit]
        public decimal? 上次价 { get; set; }

        [CustomDisplay(ForIndex = false, ForCreate = false)]
        [MyHiddenIndex, MyHiddenCreate, MyHiddenDetails, MyHiddenEdit]
        public DateTime? 上次日期 { get; set; }

        [CustomDisplay(ForIndex = false, ForCreate = false)]
        [MyHiddenIndex, MyHiddenCreate, MyHiddenEdit]
        public string 品牌 { get; set; }

        [CustomDisplay(ForCreate = false)]
        public string 状态 { get; set; }
    }

    public class Profile_销售报价 : Profile
    {
        public Profile_销售报价()
        {
            CreateMap<tb_报价表, dto销售报价>();
            CreateMap<tb_报价表D, dto销售报价D>();

            CreateMap<dto销售报价, tb_报价表>();
            CreateMap<dto销售报价D, tb_报价表D>()
                .ForMember(dst => dst.Idx, map => map.Ignore()); // 不映射自增主键
        }
    }
}
