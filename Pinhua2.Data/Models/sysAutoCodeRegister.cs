using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pinhua2.Data.Models
{
    public partial class sysAutoCodeRegister
    {
        [Key]
        public int Idx { get; set; }
        public int? AutoCodeId { get; set; }
        public int? CurrentSeed { get; set; }
        public string PrimaryPart { get; set; }

    }
}
