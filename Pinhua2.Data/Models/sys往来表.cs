using Pinhua2.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pinhua2.Data.Models
{
    [Table("tb_往来表")]
    public partial class tb_往来表: _BaseTableMain
    {
        public string 往来号 { get; set; }
        public string 简称 { get; set; }
        public string 全称 { get; set; }
        public string 联系人 { get; set; }
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
        public string 登记部门 { get; set; }
        public string 类型 { get; set; }
        public string 币种 { get; set; }
        public string 负责人 { get; set; }
        public string 付款方式 { get; set; }
        public string 税收组 { get; set; }
        public decimal? 信用额 { get; set; }
        public DateTime? 登记日期 { get; set; }
    }
}
