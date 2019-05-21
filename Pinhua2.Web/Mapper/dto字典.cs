using AutoMapper;
using Pinhua2.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pinhua2.Web.Mapper
{
    public class dto字典 : _BaseTableMain
    {
        [Required(ErrorMessage = "The {0} field is required.")]
        public string 字典名 { get; set; }
        public string 组 { get; set; }
        public string 创建人 { get; set; }
        public DateTime? 创建日 { get; set; }
    }

    public class dto字典Detail : _BaseTableDetail
    {
        public decimal? RN { get; set; }
        public string 名称 { get; set; }
        public string 描述 { get; set; }
        public string 代码 { get; set; }
        public string 字典名 { get; set; }
        public string 组 { get; set; }
    }

    public class 字典Profile : Profile
    {
        public 字典Profile()
        {
            CreateMap<sys字典表, dto字典>();
            CreateMap<dto字典, sys字典表>();

            CreateMap<sys字典表, dto字典Detail>();
            CreateMap<dto字典Detail, sys字典表>();
        }
    }
}
