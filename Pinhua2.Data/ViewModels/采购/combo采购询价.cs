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
    public class combo采购询价
    {
        public tb_报价表 Main { get; set; }
        public tb_报价表D Detail { get; set; }

    }
}
