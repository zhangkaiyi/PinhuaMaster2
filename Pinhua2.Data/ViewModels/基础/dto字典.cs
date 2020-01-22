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
    public class dto字典 : _BaseTableMain
    {
        [Required(ErrorMessage = "{0} 是必需的")]
        public string 字典号 { get; set; }
        [Required(ErrorMessage = "{0} 是必需的")]
        public string 字典名 { get; set; }
        public string 组号 { get; set; }
        public string 组名 { get; set; }
    }

    public class dto字典D : _BaseTableDetail
    {
        public string 编号 { get; set; }
        public string 名称 { get; set; }
        public string 代码 { get; set; }
        public string 字典号 { get; set; }
        public string 组号 { get; set; }
    }

    public class 字典Profile : Profile
    {
        public 字典Profile()
        {
            CreateMap<tb_字典表, dto字典>();
            CreateMap<dto字典, tb_字典表>();

            CreateMap<tb_字典表D, dto字典D>();
            CreateMap<dto字典D, tb_字典表D>();
        }
    }
}
