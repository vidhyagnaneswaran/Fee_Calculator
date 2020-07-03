using System.IO;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace FeeCalculator.Client
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>

        Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
               .ConfigureWebHostDefaults(webHostBuilder =>
               {
                   webHostBuilder
                      .UseContentRoot(Directory.GetCurrentDirectory())
                      .UseIISIntegration()
                      .UseStartup<Startup>();
               });

        //Host.CreateDefaultBuilder(args)
        //        .ConfigureWebHostDefaults(webBuilder =>
        //        {
        //    webBuilder.UseStartup<Startup>();
        //});
    }
}
