using Pinhua2.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pinhua2.Data.Models
{
    public partial class sys设备表: _BaseTableMain
    {
        public string 编号 { get; set; }
        public string 名称 { get; set; }
        public string 规格型号 { get; set; }
        public string 类型 { get; set; }
        public string 厂商 { get; set; }
        public string 属性 { get; set; }
        public decimal? 序号 { get; set; }
        public string 产能公式 { get; set; }
        public decimal? 资产原值 { get; set; }
        public string 折旧方法 { get; set; }
        public decimal? 折旧年限 { get; set; }
        public string 使用部门 { get; set; }
        public DateTime? 购置时间 { get; set; }
        public string 工作日历 { get; set; }
        public string 是否主线 { get; set; }
        public string 备注 { get; set; }
    }
}
