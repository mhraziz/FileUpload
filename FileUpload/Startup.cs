using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using FileUpload.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FileUpload
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuartion = configuration;
        }

        public IConfiguration Configuartion { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(Configuartion.GetConnectionString("DatabaseConnection")));
        }

        /*public void ConfigureServices(IServiceCollection services)
        {
            //Getting Connection String from appsettings.json
            
            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(Configuartion.GetConnectionString("DatabaseConnection")));
            // services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connection));
            // OR
            //services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connection, b => b.UseRowNumberForPaging()));

            services.AddControllersWithViews();
        }*/
        public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            //app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Demo}/{action=Index}/{id?}");
            });
        }

    }
}
