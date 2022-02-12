using System;
using System.IO;
using Lion.CodeGenerator.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;

namespace Lion.CodeGenerator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
          
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureKestrel((context, options) => { options.Limits.MaxRequestBodySize = 1024 * 50; });
                    webBuilder.UseStartup<Startup>();
                })
                .UseSerilog((context, loggerConfiguration) =>
                {
                    SerilogToEsExtensions.SetSerilogConfiguration(
                        loggerConfiguration,
                        context.Configuration);
                }).UseAutofac();
    }
}
