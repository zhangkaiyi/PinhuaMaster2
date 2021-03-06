﻿using AutoMapper;
using Pinhua2.Data.Models;
using Pinhua2.Common.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pinhua2.ViewModels
{
    public class dto销售报价 : _BaseTableMain
    {
        [MyOrder(10)]
        [MyFormControl(Visible = true, Readonly = true, Placeholder = "自动生成 ...")]
        public string 单号 { get; set; }

        [MyOrder(20)]
        [MyFormControl(Visible = false, Readonly = true)]
        [MyHidden]
        public string 业务类型 { get; set; }

        [Required]
        [MyOrder(50)]
        public DateTime? 日期 { get; set; }

        [Required]
        [MyOrder(60)]
        public DateTime? 交期 { get; set; }

        [MyOrder(70)]
        [MyFormControl(Visible = false, Readonly = false)]
        public string 备注 { get; set; }

        [Required]
        [MyOrder(30)]
        [Display(Name = "客户号")]
        [MyDropdown]
        public string 往来号 { get; set; }

        [MyOrder(40)]
        [Display(Name = "客户名")]
        [MyFormControl(Visible = false, Readonly = true)]
        [MyHidden]
        public string 往来 { get; set; }

    }

    public class dto销售报价D : _BaseProductDetail
    {
        [MyHiddenIndex, MyHiddenCreate, MyHiddenDetails, MyHiddenEdit]
        [MyHiddenField]
        public decimal? 库存 { get; set; }
        [MyFormControl(Readonly = false)]
        public decimal? 个数 { get; set; }
        public decimal? 数量 { get; set; }
        public string 单位 { get; set; }
        [MyFormControl(Readonly = false)]
        public decimal? 单价 { get; set; }
        [MyVueComputed]
        public decimal? 金额 { get; set; }

        [MyHiddenIndex, MyHiddenCreate, MyHiddenDetails, MyHiddenEdit]
        [MyHiddenField]
        public decimal? 税率 { get; set; }
        public string 备注 { get; set; }

        [MyHiddenIndex, MyHiddenCreate, MyHiddenDetails, MyHiddenEdit]
        [MyHiddenField]
        public decimal? 上次价 { get; set; }

        [MyHiddenIndex, MyHiddenCreate, MyHiddenDetails, MyHiddenEdit]
        [MyHiddenField]
        public DateTime? 上次日期 { get; set; }

        [MyHiddenIndex, MyHiddenCreate, MyHiddenEdit]
        [MyHiddenField]
        public string 品牌 { get; set; }

        [MyHiddenField]
        [MyFormControl(Readonly = false)]
        public string 状态 { get; set; }
    }

    public class Profile_销售报价 : Profile
    {
        public Profile_销售报价()
        {
            CreateMap<tb_报价表, dto销售报价>();
            CreateMap<tb_报价表D, dto销售报价D>();
            CreateMap<tb_商品表, dto销售报价D>();

            CreateMap<dto销售报价, tb_报价表>();
            CreateMap<dto销售报价D, tb_报价表D>()
                .ForMember(dst => dst.Idx, map => map.Ignore()); // 不映射自增主键
            CreateMap<dto销售报价D, tb_商品表>();

            CreateMap<dto商品, dto销售报价D>();
        }
    }
}
