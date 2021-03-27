using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NLog.Web;

namespace ProgrammersBlog.Mvc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args).ConfigureAppConfiguration((hostingContext, config) =>
                {
                    // reloadOnChange : dinamik, appsettings.json deðiþtikçe derlemeye gerek olmadan yüklenecek
                    // connectionstring için 2. addjsonfile eklendi
                    config.Sources.Clear();
                    var env = hostingContext.HostingEnvironment;
                    config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                        .AddJsonFile($"apsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
                    // Çalýþma ortamýyla ilgili deðerler de yüklensin
                    config.AddEnvironmentVariables();
                    if (args!=null)
                    {
                        config.AddCommandLine(args);
                    }
                    // Bu deðerler her deðiþimle snapshot olarak kaydediliyor, bu snapshot'ý göndermezsek okuyamaz deðerleri
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                }).ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                }).UseNLog();
    }
}
