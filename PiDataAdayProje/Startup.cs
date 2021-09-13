using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PiDataAdayProje.Models.Entities;
using PiDataAdayProje.ProjectContext;
using PiDataAdayProje.Repositories.Abstract;
using PiDataAdayProje.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PiDataAdayProje
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
            services.AddScoped<IEmlakRepository,EmlakRepository>();
            services.AddScoped<IIsyeriRepository, IsYeriRepository>();
            services.AddScoped<IMusteriRepository, MusteriRepository>();
            services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer("server=.;database=PiDataAdayDb;uid=yusuf;pwd=123"));
            services.AddIdentity<AppUser, AppRole>(x =>
            {
                x.Password.RequireDigit = false;
                x.Password.RequiredLength = 3;
                x.Password.RequireUppercase = false;
                x.Password.RequireLowercase = false;
                x.Password.RequireNonAlphanumeric = false;
            }).AddEntityFrameworkStores<ApplicationDbContext>();
            services.ConfigureApplicationCookie(x =>
            {
                x.LoginPath = new PathString("/User/Login");
                x.ExpireTimeSpan = TimeSpan.FromDays(2);
                x.SlidingExpiration = true;
                x.Cookie = new CookieBuilder
                {
                    Name = "UserCookie",
                    SecurePolicy = CookieSecurePolicy.Always,
                    HttpOnly = true,
                    SameSite = SameSiteMode.None,
                };
                x.AccessDeniedPath=new PathString("/User/AccessDenied");
            });
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
