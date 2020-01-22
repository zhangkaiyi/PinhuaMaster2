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
    public class dto往来 : _BaseTableMain
    {
        [Display(Name = "客户编号")]
        public string 往来号 { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        public string 简称 { get; set; }

        public string 全称 { get; set; }

        [Required]
        public string 联系人 { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        public string 联系电话 { get; set; }

        public string 公司电话 { get; set; }

        public string 传真 { get; set; }

        [Display(Name = "QQ")]
        public string Qq { get; set; }

        [Display(Name = "邮箱")]
        public string Email { get; set; }

        public string 地址 { get; set; }

        public string 开户行 { get; set; }

        public string 组织代码 { get; set; }

        public string 账号 { get; set; }

        public string 状态 { get; set; }

        public string 类型 { get; set; }
    }
    public class dto往来地址 : _BaseTableDetail
    {
        public string 往来号 { get; set; }
        public string 地址 { get; set; }
        public string 联系人 { get; set; }
        public string 电话 { get; set; }
    }
    public class dto往来开票 : _BaseTableDetail
    {
        public string 往来号 { get; set; }
        public string 发票抬头 { get; set; }
        public string 账号 { get; set; }
        public string 税号 { get; set; }
    }
    public class dto往来联系人 : _BaseTableDetail
    {
        public string 往来号 { get; set; }
        public string 联系人 { get; set; }
        public string 部门 { get; set; }
        public string 职位 { get; set; }
        public string 电话 { get; set; }
        public string 手机 { get; set; }
        public string Email { get; set; }
        public string 传真 { get; set; }
        public string Qq { get; set; }
        public string 备注 { get; set; }
    }
    public class Profile往来 : Profile
    {
        public Profile往来()
        {
            CreateMap<tb_往来表, dto往来>();
            CreateMap<dto往来, tb_往来表>()
                .ForMember(dst => dst.类型, map => map.MapFrom(src => string.IsNullOrEmpty(src.类型) ? "客户" : src.类型));
        }
    }
}
