using Pinhua2.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pinhua2.Data.Models
{
    public partial class sys员工表: _BaseTableMain
    {
        public string 工号 { get; set; }
        public string 姓名 { get; set; }
        public string 部门 { get; set; }
        public string 职位 { get; set; }
        public string 手机 { get; set; }
        public string 电话 { get; set; }
        public string 宅电 { get; set; }
        public string 学历 { get; set; }
        public string 婚姻 { get; set; }
        public DateTime? 生日 { get; set; }
        public string 状态 { get; set; }
        public DateTime? 入职日期 { get; set; }
        public DateTime? 离职日期 { get; set; }
        public string 是否签合同 { get; set; }
        public DateTime? 合同签订日期 { get; set; }
        public DateTime? 合同到期日期 { get; set; }
        public string 是否购社保 { get; set; }
        public DateTime? 社保开始日期 { get; set; }
        public DateTime? 社保退交日期 { get; set; }
        public decimal? 基本工资 { get; set; }
        public string 属性 { get; set; }
        public string 身份证号 { get; set; }
        public string 性别 { get; set; }
        public string 地址 { get; set; }
        public string 紧急联系人 { get; set; }
        public string 紧急联系方式 { get; set; }
        public string 紧急联系人关系 { get; set; }
        public string 紧急联系人地址 { get; set; }
    }
}
