using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProgrammersBlog.Services.AutoMapper.Profiles;
using ProgrammersBlog.Services.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammersBlog.Mvc
{
    // iki nuget kuracaðýz: 1) automapper 2) razor runtime compilation
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews().AddRazorRuntimeCompilation(); // Sen bir MVC uygulamasýsýn
            services.AddAutoMapper(typeof(CategoryProfile), typeof(ArticleProfile)); //Derlenme esnasýnda automapper'ýn buradaki sýnýflarý taramasýný saðlýyor 
            services.LoadMyServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages(); // Olmayan bir sayfaya gittiðimizde 404 döndürme
            }
            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                    name: "Admin",
                    areaName: "Admin",
                    pattern: "Admin/{controller=Home}/{action=Index}/{id?}"
                    ); // Eðer birden fazla area kullanýlacaksa normal bir mapcontrollerroute olarak oluþturulur bu ve pattern'de Admin kýsmýna süslü parantezler içinde area eklenir controller gibi
                endpoints.MapDefaultControllerRoute(); // Default olarak site açýldýðýnda Home Controller Index'e gider
            });
        }
    }
}
