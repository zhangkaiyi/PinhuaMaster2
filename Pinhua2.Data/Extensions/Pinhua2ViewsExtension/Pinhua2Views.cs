using Microsoft.EntityFrameworkCore;
using Pinhua2.Data.Models;
using Pinhua2.Data.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Newtonsoft.Json.Linq;
using Pinhua2.ViewModels;

namespace Pinhua2.Data
{
    public static partial class Pinhua2ViewsExtension
    {
        public static Pinhua2Views GetViews(this Pinhua2Context context)
        {
            return new Pinhua2Views(context);
        }
    }

    public class Pinhua2Views
    {
        protected readonly Pinhua2Context _context;
        public Pinhua2Views(Pinhua2Context context)
        {
            _context = context;
        }

        public Pinhua2Views_基础 基础 => new Pinhua2Views_基础(_context);
        public Pinhua2Views_销售 销售 => new Pinhua2Views_销售(_context);
        public Pinhua2Views_采购 采购 => new Pinhua2Views_采购(_context);
    }

}
