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
    public class vm_采购申请 : _BaseTableMain
    {
        [MyPriority(Priority.High)]
        public string 单号 { get; set; }

        [MyPriority(Priority.High)]
        [Display(Name = "客户单号")]
        public string 往来单号 { get; set; }

        [MyPriority(Priority.High)]
        public string 业务类型 { get; set; } = "采购申请";

        [MyPriority(Priority.High)]
        public DateTime? 日期 { get; set; }

        [MyPriority(Priority.High)]
        public DateTime? 交期 { get; set; }

        [MyPriority(Priority.High)]
        public string 备注 { get; set; }
    }

    public class vm_采购申请D : _BaseProductDetail
    {
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

    public class 采购申请Profile : Profile
    {
        public 采购申请Profile()
        {
            CreateMap<tb_需求表, vm_采购申请>();
            //.ForMember(dst => dst.报价单, map => map.MapFrom(src => src.报价单));
            CreateMap<vm_采购申请, tb_需求表>();


            CreateMap<tb_需求表D, vm_采购申请D>();
            CreateMap<vm_采购申请D, tb_需求表D>()
                .ForMember(dst => dst.Idx, map => map.Ignore()); // 不映射自增主键
        }
    }
}
