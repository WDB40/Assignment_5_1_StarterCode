using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CIS174_TestCoreApp.Filters;
using CIS174_TestCoreApp.Models;
using CIS174_TestCoreApp.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CIS174_TestCoreApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment environment)
        {
            Configuration = configuration;
            HostingEnvironment = environment;
        }

        public IConfiguration Configuration { get; }
        public IHostingEnvironment HostingEnvironment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //var connString = Configuration.GetConnectionString("DefaultConnection");
            var connString = "";

            if (HostingEnvironment.IsDevelopment())
            {
                connString = Configuration["ConnectionString:DefaultConnection"];
            }
            else
            {
                connString = Configuration["ConnectionString:AzureConnection"];
            }

            services.AddDbContext<AccomplishmentDbContext>(
                options => options.UseSqlServer(connString));

            services.AddDbContext<ErrorLogDbContext>(
                options => options.UseSqlServer(connString));

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc(options => {
                options.RespectBrowserAcceptHeader = true;
                options.Filters.Add<ErrorLogFilter>();
            })
                .AddXmlSerializerFormatters();

            services.AddScoped<PersonAccomplishmentDBHelper>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "student",
                    template: "student/{id:int:min(1):max(10)}",
                    defaults: new { Controller = "Student", Action = "Index" });
            });
        }
    }
}
