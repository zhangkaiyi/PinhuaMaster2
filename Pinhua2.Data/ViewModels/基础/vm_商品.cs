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
        [MyPriority(Priority.High)]
        [CustomDisplay(ForIndex = false, ForCreate = true, ForRead = true, ForUpdate = true, ForDelete = true)]
        [MyHiddenRef]
        public string 单位 { get; set; }

        [MyPriority(Priority.High)]
        [CustomDisplay(ForIndex = false, ForCreate = true, ForRead = true, ForUpdate = true, ForDelete = true)]
        [MyHiddenRef]
        public string 分类1 { get; set; }

        [MyPriority(Priority.High)]
        [CustomDisplay(ForIndex = false, ForCreate = true, ForRead = true, ForUpdate = true, ForDelete = true)]
        [MyHiddenRef]
        public string 分类2 { get; set; }

        [MyPriority(Priority.High)]
        [CustomDisplay(10, ForIndex = false, ForCreate = false, ForRead = true, ForUpdate = false, ForDelete = false)]
        public string 状态 { get; set; }

        [MyPriority(Priority.Medium)]
        [CustomDisplay(ForIndex = false, ForCreate = true, ForRead = true, ForUpdate = true, ForDelete = true)]
        [MyHiddenRef]
        public string 条码 { get; set; }

        [MyPriority(Priority.Medium)]
        [CustomDisplay(ForIndex = true, ForCreate = true, ForRead = true, ForUpdate = true, ForDelete = true)]
        public string 备注 { get; set; }

        [MyPriority(Priority.Medium)]
        [CustomDisplay(ForIndex = true, ForCreate = true, ForRead = true, ForUpdate = true, ForDelete = false)]
        [MyHiddenRef]
        public string 图片 { get; set; }

        [MyPriority(Priority.Medium)]
        [CustomDisplay(ForIndex = true, ForCreate = true, ForRead = true, ForUpdate = true, ForDelete = true)]
        [MyHiddenRef]
        public decimal? 采购价 { get; set; }
    }


    public class 商品_地板Profile : Profile
    {
        public 商品_地板Profile()
        {
            CreateMap<tb_商品表, dto商品>();
            CreateMap<dto商品, tb_商品表>();
        }
    }
}
