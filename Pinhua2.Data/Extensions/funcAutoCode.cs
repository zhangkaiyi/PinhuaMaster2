using Microsoft.EntityFrameworkCore;
using Pinhua2.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pinhua2.Data.Extensions
{
    public static class funcAutoCodeExtension
    {
        public static string funcAutoCode(this Pinhua2Context context, string codeName)
        {
            var autoCode = context.sys_AutoCode.AsNoTracking().FirstOrDefault(p => p.AutoCodeName == codeName);
            if (autoCode == null)
                return string.Empty;
            else
                return funcAutoCode(context, autoCode.AutoCodeId);
        }
        public static string funcAutoCode(this Pinhua2Context context, int codeId)
        {
            var id = string.Empty;
            var autoCode = context.sys_AutoCode.FirstOrDefault(p => p.AutoCodeId == codeId);
            if (autoCode == null)
                return id;
            id += autoCode.Prefix;
            if (!string.IsNullOrEmpty(autoCode.DateType))
            {
                id += DateTime.Now.ToString(autoCode.DateType);
            }
            var autoCodeReg = context.sys_AutoCodeRegister.FirstOrDefault(p => p.AutoCodeId == codeId && p.PrimaryPart == id);
            if (autoCodeReg != null)
            {
                autoCodeReg.CurrentSeed += 1;
                id += autoCodeReg.CurrentSeed?.ToString($"D{autoCode.SeedLength}");
            }
            else
            {
                context.sys_AutoCodeRegister.Add(new Models.sys_AutoCodeRegister
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
