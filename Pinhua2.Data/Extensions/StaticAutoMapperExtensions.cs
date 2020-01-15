using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pinhua2.Data
{
    public static class StaticAutoMapper
    {
        public static IMapper Current { get; private set; }

        internal static void Configure(IMapper mapper)
        {
            Current = mapper;
        }
    }

    public static class StaticAutoMapperExtensions
    {
        public static IApplicationBuilder UseStaticAutoMapper(this IApplicationBuilder app)
        {
            var mapper = app.ApplicationServices.GetRequiredService<IMapper>();
            StaticAutoMapper.Configure(mapper);
            return app;
        }
    }
}
