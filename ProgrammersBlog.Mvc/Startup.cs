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
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProgrammersBlog.Mvc
{
    // iki nuget kuraca��z: 1) automapper 2) razor runtime compilation
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews().AddRazorRuntimeCompilation().AddJsonOptions(opt=> 
            {

                // Data ile gelen veriyi parse ederek bir de�i�ken i�erisine at�yoruz
                // const ajaxModel = jQuery.parseJson(data);
                // De�i�ken i�erisindeki sonu� durumunu kontrol ediyoruz
                //if(ajaxModel.ResultStatus === 0){}
                opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                //JsonStringEnumConverter(JsonNamingPolicy.CamelCase) 'de kullanabilirsiniz bu �u �zelli�i getirir
                //if(ajaxModel.ResultStatus === "success"){}

                // Modeller i�ine yap�lan includelar�nda sorunsuz �al��abilmesi i�in, bu bugl� o y�zden controllerda da verece�iz ama yine de yazd�k
                opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;




            }); // Sen bir MVC uygulamas�s�n
            services.AddAutoMapper(typeof(CategoryProfile), typeof(ArticleProfile)); //Derlenme esnas�nda automapper'�n buradaki s�n�flar� taramas�n� sa�l�yor 
            services.LoadMyServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages(); // Olmayan bir sayfaya gitti�imizde 404 d�nd�rme
            }
            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                    name: "Admin",
                    areaName: "Admin",
                    pattern: "Admin/{controller=Home}/{action=Index}/{id?}"
                    ); // E�er birden fazla area kullan�lacaksa normal bir mapcontrollerroute olarak olu�turulur bu ve pattern'de Admin k�sm�na s�sl� parantezler i�inde area eklenir controller gibi
                endpoints.MapDefaultControllerRoute(); // Default olarak site a��ld���nda Home Controller Index'e gider
            });
        }
    }
}
