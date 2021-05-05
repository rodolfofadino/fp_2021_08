using Fiap.Application.Interfaces;
using Fiap.Application.Services;
using Fiap.Application.Validations;
using Fiap.Domain.Models;
using Fiap.Infrastructure.Clients;
using Fiap.IoC;
using Fiap.Persistence.Contexts;
using Fiap.Presentation.Web.Middlewares;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Presentation.Web
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
            services.AddDataProtection()
                .SetApplicationName("fiap")
                .PersistKeysToFileSystem(new System.IO.DirectoryInfo(@"C:\Users\Rodolfof\source\repos\fiap2021\Fiap\web"));

            services.AddAuthentication("fiap")
            .AddCookie("fiap", o => {
                o.LoginPath = "/account/index";
                o.AccessDeniedPath = "/account/denied";
            });

            services.AddMemoryCache();

            services.AddControllersWithViews().AddFluentValidation();
            //.AddRazorRuntimeCompilation();

            //services.AddRepository<Aluno>();

            DependencyContainer.RegisterServices(services);

            services.Configure<GzipCompressionProviderOptions>(o => o.Level = System.IO.Compression.CompressionLevel.Optimal);

            services.AddResponseCompression(o => {

                o.Providers.Add<GzipCompressionProvider>();
                //o.Providers.Add<BrotliCompressionProvider>();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMeuMiddlewareFiap();

            if (env.EnvironmentName == "Development")
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseResponseCompression();

            app.UseStaticFiles(new StaticFileOptions()
            {

                OnPrepareResponse = ctx =>
                {
                    var duration = 60 * 60 * 24 * 200;
                    ctx.Context.Response.Headers[HeaderNames.CacheControl]
                    = "public,max-age=" + duration;
                }

            });

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                    );
            });
        }
    }
}
