using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Rest.Web
{
    public class Program
    {
        public  static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();

            //var builder = WebAssemblyHostBuilder.CreateDefault(args);

            //builder.Services
            //  .AddBlazorise(options =>
            //  {
            //      options.ChangeTextOnKeyPress = true;
            //  })
            //  .AddBootstrapProviders()
            //  .AddFontAwesomeIcons();

            //builder.Services.AddSingleton(new HttpClient
            //{
            //    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
            //});

            //builder.RootComponents.Add<App>("#app");

            //var host = builder.Build();

            //await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
