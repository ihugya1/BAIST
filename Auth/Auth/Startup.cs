using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fluent.Infrastructure.FluentModel;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Auth
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
                //  This  lambda  determines  whether  user  consent  for  non-essential  cookies  is  needed  for  a  given  request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = Microsoft.AspNetCore.Http.SameSiteMode.None;
            });
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(CookieOptions =>
            {
                CookieOptions.LoginPath = "/Login";
                CookieOptions.LogoutPath = "/Admin/Logout";
                CookieOptions.SlidingExpiration = true;
                CookieOptions.AccessDeniedPath = "/Admin/Forbidden";
                CookieOptions.ExpireTimeSpan = TimeSpan.FromDays(2);
                CookieOptions.Cookie.HttpOnly = true;
            });
            services.AddRazorPages();
          
            services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireAdmin", policy =>
                policy.RequireRole("Admin"));
            });
            services.AddRazorPages(options =>
            {
                options.Conventions.AuthorizeFolder("/Common/Admin", "RequireAdmin");
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
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
