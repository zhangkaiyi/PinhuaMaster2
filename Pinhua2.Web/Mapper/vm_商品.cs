using AutoMapper;
using Pinhua2.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pinhua2.Web.Mapper
{
    public class vm_商品_地板 : _BaseTableMain
    {
        public string 品号 { get; set; }
        public string 品名 { get; set; }
        public string 拼音码 { get; set; }
        public string 规格 { get; set; }
        public decimal? 长度 { get; set; }
        public decimal? 宽度 { get; set; }
        public decimal? 高度 { get; set; }
        public decimal? 面厚 { get; set; }
        public string 分类1 { get; set; }
        public string 分类2 { get; set; }
        public string 状态 { get; set; }
        public string 大类 { get; set; }
        public string 别名 { get; set; }
        public string 表面处理 { get; set; }
        public string 条码 { get; set; }
        public string 备注 { get; set; }
        public string 图片 { get; set; }
        public int? 图片I { get; set; }
    }


    public class 商品_地板Profile : Profile
    {
        public 商品_地板Profile()
        {
            CreateMap<tb_商品表, vm_商品_地板>();
            CreateMap<vm_商品_地板, tb_商品表>();
        }
    }
}
