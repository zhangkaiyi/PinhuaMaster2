using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pinhua2.Data.Models
{
    public enum AutoCodeDateType
    {
        yy = 6,
        yyMM = 7,
        yyMMdd = 8,
        yyyy = 9,
        yyyyMM = 10,
        yyyyMMdd = 11
    }
    [Table("sys_AutoCode")]
    public partial class sys_AutoCode
    {
        [Key/*, DatabaseGenerated(DatabaseGeneratedOption.None)*/]
        public int AutoCodeId { get; set; }
        public string AutoCodeName { get; set; }
        public string Prefix { get; set; }
        public int? SysVar { get; set; }
        public string DateType { get; set; }
        public int? SeedLength { get; set; }
        public int? SeedStart { get; set; }
        public int? RunBeforeSave { get; set; }
        public int? AllowMore { get; set; }
        public int? AllowBatch { get; set; }
        public int? ReuseType { get; set; }
        public int? CreateUser { get; set; }
        public DateTime? CreateTime { get; set; }
        public int? IsActive { get; set; }
        public string Memo { get; set; }
    }
}
