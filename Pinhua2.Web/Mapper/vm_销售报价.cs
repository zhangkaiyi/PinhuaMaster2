using AutoMapper;
using Pinhua2.Data.Models;
using Pinhua2.Web.Common.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pinhua2.Web.Mapper
{
    public class vm_销售报价 : _BaseTableMain
    {
        [CustomDisplay(10)]
        public string 单号 { get; set; }

        [CustomDisplay(20)]
        public string 业务类型 { get; set; }

        [CustomDisplay(50)]
        public DateTime? 日期 { get; set; }

        [CustomDisplay(60)]
        public DateTime? 交期 { get; set; }

        [CustomDisplay(70)]
        public string 备注 { get; set; }

        [CustomDisplay(40)]
        [Display(Name = "客户名")]
        public string 往来 { get; set; }

        [CustomDisplay(30)]
        [Display(Name = "客户号")]
        public string 往来号 { get; set; }
    }

    public class vm_销售报价D : _BaseTableDetail
    {
        public string 行号 { get; set; }
        public string 子单号 { get; set; }
        public string 品号 { get; set; }
        public string 品名 { get; set; }
        public string 规格 { get; set; }
        public decimal? 库存 { get; set; }
        public string 单位 { get; set; }
        public decimal? 数量 { get; set; }
        public decimal? 单价 { get; set; }
        public decimal? 金额 { get; set; }
        public decimal? 税率 { get; set; }
        public string 备注 { get; set; }
        public decimal? 上次价 { get; set; }
        public DateTime? 上次日期 { get; set; }
        public string 品牌 { get; set; }
        public string 状态 { get; set; }
    }

    public class 销售报价Profile : Profile
    {
        public 销售报价Profile()
        {
            CreateMap<tb_报价表, vm_销售报价>();
            CreateMap<vm_销售报价, tb_报价表>();

            CreateMap<tb_报价表D, vm_销售报价D>();
            CreateMap<vm_销售报价D, tb_报价表D>();
        }
    }
}
