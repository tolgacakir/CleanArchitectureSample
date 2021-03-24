using AspNetCoreRateLimit;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //using var webHost = CreateHostBuilder(args).Build();

            //IIpPolicyStore IpPolicy = webHost.Services.GetRequiredService<IIpPolicyStore>();
            //await IpPolicy.SeedAsync();
            //await webHost.RunAsync();

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
