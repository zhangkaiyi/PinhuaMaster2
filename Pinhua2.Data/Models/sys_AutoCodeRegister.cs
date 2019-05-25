using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pinhua2.Data.Models
{
    [Table("sys_AutoCodeRegister")]
    public partial class sys_AutoCodeRegister
    {
        [Key]
        public int Idx { get; set; }
        public int? AutoCodeId { get; set; }
        public int? CurrentSeed { get; set; }
        public string PrimaryPart { get; set; }

    }
}
