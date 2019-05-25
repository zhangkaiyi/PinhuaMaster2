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
    public class vm_商品_地板 : _BaseTableMain
    {
        [CustomDisplay(ForIndex = true, ForCreate = true, ForRead = true, ForUpdate = true, ForDelete = true)]
        public string 品号 { get; set; }

        [Required]
        [CustomDisplay(ForIndex = true, ForCreate = true, ForRead = true, ForUpdate = true, ForDelete = true)]
        public string 品名 { get; set; }

        [CustomDisplay(ForIndex = true, ForCreate = true, ForRead = true, ForUpdate = true, ForDelete = true)]
        public string 别名 { get; set; }

        [CustomDisplay(ForIndex = true, ForCreate = true, ForRead = true, ForUpdate = true, ForDelete = true)]
        public string 型号 { get; set; }

        [CustomDisplay(ForIndex = true, ForCreate = true, ForRead = true, ForUpdate = true, ForDelete = true)]
        public string 规格 { get; set; }

        [CustomDisplay(ForIndex = false, ForCreate = true, ForRead = false, ForUpdate = true, ForDelete = false)]
        public decimal? 长度 { get; set; }

        [CustomDisplay(ForIndex = false, ForCreate = true, ForRead = false, ForUpdate = true, ForDelete = false)]
        public decimal? 宽度 { get; set; }

        [CustomDisplay(ForIndex = false, ForCreate = true, ForRead = false, ForUpdate = true, ForDelete = false)]
        public decimal? 高度 { get; set; }

        [CustomDisplay(ForIndex = false, ForCreate = true, ForRead = false, ForUpdate = true, ForDelete = false)]
        public decimal? 面厚 { get; set; }

        [CustomDisplay(ForIndex = false, ForCreate = true, ForRead = true, ForUpdate = true, ForDelete = true)]
        public string 单位 { get; set; }

        [CustomDisplay(ForIndex = false, ForCreate = true, ForRead = true, ForUpdate = true, ForDelete = true)]
        public string 分类1 { get; set; }

        [CustomDisplay(ForIndex = false, ForCreate = true, ForRead = true, ForUpdate = true, ForDelete = true)]
        public string 分类2 { get; set; }

        [CustomDisplay(ForIndex = false, ForCreate = false, ForRead = true, ForUpdate = false, ForDelete = false)]
        public string 状态 { get; set; }

        [CustomDisplay(ForIndex = false, ForCreate = true, ForRead = true, ForUpdate = true, ForDelete = true)]
        public string 条码 { get; set; }

        [CustomDisplay(ForIndex = true, ForCreate = true, ForRead = true, ForUpdate = true, ForDelete = true)]
        public string 备注 { get; set; }

        [CustomDisplay(ForIndex = true, ForCreate = true, ForRead = true, ForUpdate = true, ForDelete = false)]
        public string 图片 { get; set; }
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
