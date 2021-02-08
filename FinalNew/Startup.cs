using FinalNew.AppCode.Providers;
using FinalNew.Models.DataContext;
using FinalNew.Models.Entity.Membership;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
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

            services.AddControllersWithViews(cfg => {
                var policy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();

                cfg.Filters.Add(new AuthorizeFilter(policy));
            });

            services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<HomeSaleDbContext>()
                .AddDefaultTokenProviders();


            services.Configure<IdentityOptions>(cfg => {

                cfg.User.RequireUniqueEmail = true;
                cfg.Password.RequireDigit = false;
                cfg.Password.RequireNonAlphanumeric = false;
                cfg.Password.RequiredLength = 3;
                cfg.Password.RequireUppercase = false;
                cfg.Password.RequireLowercase = false;

            });

            services.ConfigureApplicationCookie(cfg =>
            {
                cfg.LoginPath = "/az/signin";
                cfg.AccessDeniedPath = "/accesdenied.html";
                cfg.Cookie.Name = "evim";
                cfg.ExpireTimeSpan = TimeSpan.FromMinutes(10);
            });
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

            InitMemmershipDefaults(app);

            app.UseRouting();


            app.UseRequestLocalization(cfg =>
            {
                cfg.AddSupportedCultures("en", "az", "ru");
                cfg.AddSupportedUICultures("en", "az", "ru");
                cfg.RequestCultureProviders.Clear(); 
                cfg.RequestCultureProviders.Add(new AppCultureProvider());
            });



            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapAreaControllerRoute(
                  name: "areas",
                  areaName: "Admin",
                  pattern: "Admin/{controller=dashboard}/{action=index}/{id?}"
                  );

                endpoints.MapControllerRoute(
                     name: "default",
                     pattern: "{lang=az}/{controller=home}/{action=index}/{id?}",
                    constraints: new { lang = "az|en" }
                     );


                endpoints.MapControllerRoute(
                  name: "signin",
                  pattern: "/{lang=az}/signin",
                  defaults: new
                  {
                      lang="az",
                      controller = "Home",
                      Action = "Login"
                  },
                    constraints: new { lang = "az|en" }
                  );

                
                    endpoints.MapControllerRoute(
                name: "AccesDenied",
                pattern: "accesdenied.html",
                defaults: new
                {
                    lang = "az",
                    controller = "Home",
                    Action = "AccesDenied"
                });
               
                    endpoints.MapAreaControllerRoute(
                 name: "AccesDenied",
                 areaName: "Admin",
                 pattern: "accesdenied.html",
                 defaults: new {
                     controller = "DashBoard",
                     Action = "AccesDenied",
                     area="admin"
                 });


            });


        }

        private void InitMemmershipDefaults(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<HomeSaleDbContext>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<AppRole>>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();


                if (!db.Users.Any())
                {
                    if (!db.Roles.Any())
                    {
                        roleManager.CreateAsync(new AppRole
                        {
                            Name = "SuperAdmin"

                        }).Wait();
                    }
                    var admin = new AppUser
                    {
                        UserName = "elcin",
                        Email = "elcinha@code.edu.az"
                    };

                    if (userManager.CreateAsync(admin, "123").Result.Succeeded)
                    {
                        userManager.AddToRoleAsync(admin, "SuperAdmin").Wait();
                    }

                }

            }
        }
    }
}
