using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NixonE.DAL;
using NixonE.Models;
using NixonE.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NixonE
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
            services.AddControllersWithViews();
            services.AddDbContext<NixonDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DConnection"));
            });

            services.AddIdentity<AppUser, IdentityRole>(options =>
             {
                 options.Password.RequireDigit = true;
                 options.Password.RequiredLength = 8;
                 options.Password.RequireLowercase = true;
                 options.Password.RequireUppercase = true;
                 options.Password.RequireNonAlphanumeric = true;

                 options.User.RequireUniqueEmail = true;

                 options.Lockout.AllowedForNewUsers = true;
                 options.Lockout.MaxFailedAccessAttempts = 10;
                 options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(20);
             }).AddDefaultTokenProviders().AddEntityFrameworkStores<NixonDbContext>();

            services.AddScoped<LayoutService>();
            services.AddHttpContextAccessor();
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
                app.UseStatusCodePagesWithRedirects("/ErrorPage/{0}");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                        name: "areas",
                        pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
                    );
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
