using AutoMapper;
using Pinhua2.Common.Attributes;
using Pinhua2.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pinhua2.ViewModels
{
    public class vm_供应商 : _BaseTableMain
    {
        //[Required]
        [MyPriority(Priority.High)]
        [Display(Name = "供应商编号")]
        public string 往来号 { get; set; }

        [MyPriority(Priority.High)]
        [Required(ErrorMessage = "The {0} field is required.")]
        public string 简称 { get; set; }

        [MyPriority(Priority.High)]
        public string 全称 { get; set; }

        [MyPriority(Priority.High)]
        [Required(ErrorMessage = "The {0} field is required.")]
        public string 联系人 { get; set; }

        [MyPriority(Priority.High)]
        [Required(ErrorMessage = "The {0} field is required.")]
        public string 联系电话 { get; set; }

        [MyPriority(Priority.High)]
        public string 公司电话 { get; set; }

        [MyPriority(Priority.High)]
        public string 传真 { get; set; }

        [MyPriority(Priority.High)]
        [Display(Name = "QQ")]
        public string Qq { get; set; }

        [MyPriority(Priority.High)]
        [Display(Name = "邮箱")]
        public string Email { get; set; }

        [MyPriority(Priority.High)]
        public string 地址 { get; set; }

        [MyPriority(Priority.High)]
        public string 开户行 { get; set; }

        [MyPriority(Priority.High)]
        public string 组织代码 { get; set; }

        [MyPriority(Priority.High)]
        public string 账号 { get; set; }

        [MyPriority(Priority.High)]
        [CustomDisplay(10)]
        public string 状态 { get; set; }

        [MyPriority(Priority.High)]
        [CustomDisplay(20)]
        public string 类型 { get; set; }
    }

    public class 供应商Profile : Profile
    {
        public 供应商Profile()
        {
            CreateMap<tb_往来表, vm_供应商>();
            //.ForMember(dst => dst.ExcelServerRcid, map => map.MapFrom(src => src.ExcelServerRcid))
            //.ForMember(dst => dst.DeliveryDate, map => map.MapFrom(src => src.DeliveryDate.Value.ToString("yyyy-MM-dd")));
            CreateMap<vm_供应商, tb_往来表>();
            //.ForMember(dst => dst.ExcelServerRcid, map => map.MapFrom(src => src.ExcelServerRcid))
            //.ForMember(dst => dst.DeliveryDate, map => map.MapFrom(src => src.DeliveryDate));
        }
    }
}
