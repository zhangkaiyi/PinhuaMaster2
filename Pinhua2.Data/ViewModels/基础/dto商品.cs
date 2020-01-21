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
    public class dto商品 : _BaseProductMain
    {
        [Required]
        public override string 品名 { get; set; }

        [MyHiddenField]
        public string 单位 { get; set; }

        [MyHiddenField]
        [Required]
        public string 分类1 { get; set; }

        [MyHiddenField]
        public string 分类2 { get; set; }

        [MyOrder(10)]
        public string 状态 { get; set; }

        [MyHiddenField]
        public string 条码 { get; set; }

        public string 备注 { get; set; }

        [MyHiddenField]
        public string 图片 { get; set; }

        [MyHiddenField]
        public decimal? 采购价 { get; set; }
    }


    public class 商品Profile : Profile
    {
        public 商品Profile()
        {
            CreateMap<tb_商品表, dto商品>();
            CreateMap<dto商品, tb_商品表>();
        }
    }
}
