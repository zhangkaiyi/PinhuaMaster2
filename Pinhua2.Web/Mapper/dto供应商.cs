using AutoMapper;
using Pinhua2.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pinhua2.Web.Mapper
{
    public class dto供应商
    {
        public int RecordId { get; set; }
        //[Required]
        [Display(Name = "供应商编号")]
        public string 往来号 { get; set; }
        [Required(ErrorMessage = "The {0} field is required.")]
        public string 简称 { get; set; }
        public string 全称 { get; set; }
        [Required(ErrorMessage = "The {0} field is required.")]
        public string 联系人 { get; set; }
        [Required(ErrorMessage = "The {0} field is required.")]
        public string 联系电话 { get; set; }
        public string 公司电话 { get; set; }
        public string 传真 { get; set; }
        public string Qq { get; set; }
        public string Email { get; set; }
        public string 地址 { get; set; }
        public string 开户行 { get; set; }
        public string 组织代码 { get; set; }
        public string 账号 { get; set; }
        public string 状态 { get; set; }
        public string 类型 { get; set; }
    }

    public class 供应商Profile : Profile
    {
        public 供应商Profile()
        {
            CreateMap<sys往来表, dto供应商>();
            //.ForMember(dst => dst.ExcelServerRcid, map => map.MapFrom(src => src.ExcelServerRcid))
            //.ForMember(dst => dst.DeliveryDate, map => map.MapFrom(src => src.DeliveryDate.Value.ToString("yyyy-MM-dd")));
            CreateMap<dto供应商, sys往来表>();
            //.ForMember(dst => dst.ExcelServerRcid, map => map.MapFrom(src => src.ExcelServerRcid))
            //.ForMember(dst => dst.DeliveryDate, map => map.MapFrom(src => src.DeliveryDate));
        }
    }
}
