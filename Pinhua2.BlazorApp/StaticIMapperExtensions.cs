using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pinhua2.BlazorApp
{
    public static class Mapper
    {
        public static IMapper Current { get; private set; }

        internal static void Configure(IMapper mapper)
        {
            Current = mapper;
        }
    }

    public static class StaticIMapperExtensions
    {
        public static IApplicationBuilder UseStaticIMapper(this IApplicationBuilder app)
        {
            var mapper = app.ApplicationServices.GetRequiredService<IMapper>();
            Mapper.Configure(mapper);
            return app;
        }
    }
}
