using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using Pinhua2.Data;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Hosting;
using Blazui.Component;

namespace Pinhua2.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            // Add DbContext
            services.AddDbContext<Pinhua2Context>(
                options => options.UseSqlServer(Configuration.GetConnectionString("Pinhua2Connection"),
                o =>
                {
                    //o.UseRowNumberForPaging();
                    //o.MigrationsAssembly("Pinhua2.Web");
                })
                );
            // Add AutoMapper，全局设置不映射空值
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            //services.AddAutoMapper(cfg =>
            //{
            //    cfg.ForAllMaps((a, b) =>
            //   {
            //       b.ForAllMembers(memberOptions => memberOptions.Condition((src, dest, sourceMember) =>
            //       {
            //           // 空值不映射
            //           if (sourceMember == null)
            //               return false;
            //           else
            //           {
            //               // Guid 为空（“00000000-0000-0000-0000-000000000000”）时，不映射
            //               if (sourceMember?.GetType() == typeof(Guid) && sourceMember.ToString() == Guid.Empty.ToString())
            //               {
            //                   return false;
            //               }
            //               return true;
            //           }
            //       }));
            //   });
            //}, AppDomain.CurrentDomain.GetAssemblies());

            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.AddMaps(AppDomain.CurrentDomain.GetAssemblies());
                //cfg.ForAllMaps((a, b) =>
                //{
                //    b.ForAllMembers(memberOptions => memberOptions.Condition((src, dest, sourceMember) =>
                //    {
                //        // 空值不映射
                //        if (sourceMember == null)
                //            return false;
                //        else
                //        {
                //            // Guid 为空（“00000000-0000-0000-0000-000000000000”）时，不映射
                //            if (sourceMember?.GetType() == typeof(Guid) && sourceMember.ToString() == Guid.Empty.ToString())
                //            {
                //                return false;
                //            }
                //            return true;
                //        }
                //    }));
                //});
            });

            services.AddLocalization(options =>
            {
                options.ResourcesPath = "Resources";
            });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            
            services.AddServerSideBlazor();

            services.AddMvc().AddNewtonsoftJson()
                .AddDataAnnotationsLocalization(options =>
                {
                    options.DataAnnotationLocalizerProvider = (type, factory) =>
                        factory.Create(typeof(SharedResource));
                })
                .AddRazorRuntimeCompilation();

            services.AddBlazuiServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapBlazorHub();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
