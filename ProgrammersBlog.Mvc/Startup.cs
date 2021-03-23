using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProgrammersBlog.Mvc.AutoMapper.Profiles;
using ProgrammersBlog.Mvc.Helpers.Abstract;
using ProgrammersBlog.Mvc.Helpers.Concrete;
using ProgrammersBlog.Services.AutoMapper.Profiles;
using ProgrammersBlog.Services.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProgrammersBlog.Mvc
{
    // iki nuget kuracaðýz: 1) automapper 2) razor runtime compilation
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews().AddRazorRuntimeCompilation().AddJsonOptions(opt=> 
            {

                // Data ile gelen veriyi parse ederek bir deðiþken içerisine atýyoruz
                // const ajaxModel = jQuery.parseJson(data);
                // Deðiþken içerisindeki sonuç durumunu kontrol ediyoruz
                //if(ajaxModel.ResultStatus === 0){}
                opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                //JsonStringEnumConverter(JsonNamingPolicy.CamelCase) 'de kullanabilirsiniz bu þu özelliði getirir
                //if(ajaxModel.ResultStatus === "success"){}

                // Modeller içine yapýlan includelarýnda sorunsuz çalýþabilmesi için, bu buglý o yüzden controllerda da vereceðiz ama yine de yazdýk
                opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
            }).AddNToastNotifyToastr();

            services.AddSession();
            // Sen bir MVC uygulamasýsýn
            services.AddAutoMapper(typeof(CategoryProfile), typeof(ArticleProfile), typeof(UserProfile), typeof(ViewModelsProfile), typeof(CommentProfile)); //Derlenme esnasýnda automapper'ýn buradaki sýnýflarý taramasýný saðlýyor 
            services.LoadMyServices(connectionString:Configuration.GetConnectionString("localDB"));
            services.AddScoped<IImageHelper, ImageHelper>();
            services.ConfigureApplicationCookie(options=> 
            {
                options.LoginPath = new PathString("/Admin/User/Login"); //Kullanýcýnýn login olacaðý sayfa
                options.LogoutPath = new PathString("/Admin/User/Logout");
                options.Cookie = new CookieBuilder
                {
                    Name = "ProgrammersBlog",
                    HttpOnly = true, //Cookie deðerlerini sadece Http üzerinden (XSS saldýrýlarý için)
                    SameSite = SameSiteMode.Strict, // Cookie bilgilerinin sadece kendi sitemizden geldiðinde iþlenmesini saðlayacak ayar (CSRF saldýrýlarý için, cookie bilgilerini çalan saldýrgan bu cookie bilgilerini farklý bir siteden sunucuya gönderiyor)
                    SecurePolicy = CookieSecurePolicy.SameAsRequest //bunu always yapmak gerekir
                };
                options.SlidingExpiration = true; //Kullanýcýnýn login deðerleri kaç gün geçerli kalsýn
                options.ExpireTimeSpan = System.TimeSpan.FromDays(7);
                options.AccessDeniedPath = new PathString("/Admin/User/AccessDenied");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages(); // Olmayan bir sayfaya gittiðimizde 404 döndürme
            }
            app.UseSession();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseNToastNotify();
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
