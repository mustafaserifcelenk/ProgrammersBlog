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
                    // reloadOnChange : dinamik, appsettings.json de�i�tik�e derlemeye gerek olmadan y�klenecek
                    // connectionstring i�in 2. addjsonfile eklendi
                    config.Sources.Clear();
                    var env = hostingContext.HostingEnvironment;
                    config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                        .AddJsonFile($"apsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
                    // �al��ma ortam�yla ilgili de�erler de y�klensin
                    config.AddEnvironmentVariables();
                    if (args!=null)
                    {
                        config.AddCommandLine(args);
                    }
                    // Bu de�erler her de�i�imle snapshot olarak kaydediliyor, bu snapshot'� g�ndermezsek okuyamaz de�erleri
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
