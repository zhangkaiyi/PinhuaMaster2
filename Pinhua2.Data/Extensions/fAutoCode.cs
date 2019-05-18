using Pinhua2.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pinhua2.Data.Extensions
{
    public static class fAutoCodeExtension
    {
        public static string fAutoCode(this Pinhua2Context context, int codeId)
        {
            var id = string.Empty;
            var autoCode = context.sysAutoCode.FirstOrDefault(p => p.AutoCodeId == codeId);
            if (autoCode == null)
                return id;
            id += autoCode.Prefix;
            id += DateTime.Now.ToString(autoCode.DateType.ToString());
            var autoCodeReg = context.sysAutoCodeRegister.FirstOrDefault(p => p.AutoCodeId == codeId && p.PrimaryPart == id);
            if (autoCodeReg != null)
            {
                autoCodeReg.CurrentSeed += 1;
                id += autoCodeReg.CurrentSeed?.ToString($"D{autoCode.SeedLength}");
            }
            else
            {
                context.sysAutoCodeRegister.Add(new Models.sysAutoCodeRegister
                {
                    AutoCodeId = codeId,
                    CurrentSeed = 1,
                    PrimaryPart = id,
                });
                id += 1.ToString($"D{autoCode.SeedLength}");
            }
            context.SaveChanges();

            return id;
        }
    }
}
