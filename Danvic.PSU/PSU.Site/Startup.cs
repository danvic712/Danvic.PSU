using Controllers.PSU.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PSU.EFCore;
using System;
using System.Reflection;

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

            services.AddMvc();

            //Policy-based authorization
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Administrator", policy =>
                    policy.Requirements.Add(new RoleRequirement("Administrator")));
                options.AddPolicy("Instructor", policy =>
                    policy.Requirements.Add(new RoleRequirement("Instructor")));
                options.AddPolicy("Student", policy =>
                    policy.Requirements.Add(new RoleRequirement("Student")));
            });

            services.AddSession();
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

            app.UseSession();

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
