using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PSU.EFCore;
using PSU.Entity.Identity;

namespace PSU.Site
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
            services.AddDbContext<ApplicationDbContext>(options => options.UseMySQL(Configuration.GetConnectionString("SQLConnection")));

            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = true;//是否需要包含数字（0 ~ 9）
                options.Password.RequiredLength = 8;//密码最小长度
                options.Password.RequireNonAlphanumeric = false;//是否包含非字母或数字字符
                options.Password.RequireUppercase = true;//是否需要包含大写字母（A ~ Z）
                options.Password.RequireLowercase = false;//是否需要包含小写字母（a ~ z）
                options.Password.RequiredUniqueChars = 6;//密码中不同字符的数目

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);//账户锁定时间
                options.Lockout.MaxFailedAccessAttempts = 10;//最大尝试次数
                options.Lockout.AllowedForNewUsers = true;

                // User settings
                options.User.RequireUniqueEmail = true;
            });

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.Cookie.Expiration = TimeSpan.FromDays(150);
                options.LoginPath = "/Secret/Login"; // If the LoginPath is not set here, ASP.NET Core will default to /Account/Login
                options.LogoutPath = "/Secret/Logout"; // If the LogoutPath is not set here, ASP.NET Core will default to /Account/Logout
                options.AccessDeniedPath = "/Secret/AccessDenied"; // If the AccessDeniedPath is not set here, ASP.NET Core will default to /Account/AccessDenied
                options.SlidingExpiration = true;
            });

            //var skipHTTPS = Configuration.GetValue<bool>("LocalTest:skipHTTPS");
            //services.Configure<MvcOptions>(options =>
            //{
            //    // Set LocalTest:skipHTTPS to true to skip SSL requrement in debug mode. This is useful when not using Visual Studio.
            //    if (Environment.IsDevelopment() && !skipHTTPS)
            //    {
            //        options.Filters.Add(new RequireHttpsAttribute());
            //    }
            //});

            //反射加载接口实现类，批量注入
            Assembly assembly = Assembly.Load("PSU.Domain");
            foreach (var implement in assembly.GetTypes())
            {
                Type[] interfaceType = implement.GetInterfaces();
                foreach (var service in interfaceType)
                {
                    services.AddTransient(service, implement);
                }
            }

            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                                 .RequireAuthenticatedUser()
                                 .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Secret/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "areas",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Secret}/{action=Login}/{id?}");
            });
        }
    }
}
