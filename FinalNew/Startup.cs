using FinalHomeSale.Models.DataContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalNew
{

    public class Startup
    {
        readonly IConfiguration conf;
        public Startup(IConfiguration conf)
        {
            this.conf = conf;
        }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<HomeSaleDbContext>(cfg =>
            {
                //cfg.UseInMemoryDatabase(databaseName: "HomeSale"); 

                cfg.UseSqlServer(conf.GetConnectionString("cString"));
            });

            services.AddControllersWithViews();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.Seed();

            app.UseStaticFiles();

            app.UseRouting();


            app.UseEndpoints(endpoints =>
            {

                endpoints.MapAreaControllerRoute(
                  name: "areas",
                  areaName: "Admin",
                  pattern: "Admin/{controller=dashboard}/{action=index}/{id?}"
                  );

                endpoints.MapControllerRoute(
                     name: "default",
                     pattern: "{controller=home}/{action=index}/{id?}"
                     );

            });
        }
    }
}
