using Common.Models;
using DemoApp.Interfaces;
using DemoApp.Models;
using DemoApp.Services;
using MCMathLib;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace DemoApp
{
    internal class Program
    {

        //public static IConfigurationRoot Configuration;


        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");


            //WriteDate();

            //Console.ReadKey();

            // Create service collection
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            //Create service provider
            var serviceProvider = serviceCollection.BuildServiceProvider();

            //Entry to run app
            serviceProvider.GetService<App>().Run();
        }

        public static void WriteDate()
        {
            //using (var scope = Container.BeginLifetimeScope())
            //{
            //    var writer = scope.Resolve<IDateWriter>();
            //    writer.WriteDate();
            //}
        }

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            // add logging
            serviceCollection
                .AddLogging(l => l
                    .AddDebug()
                    //.AddConsole()
                    );

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false)
                .Build();

            serviceCollection.AddOptions();
            serviceCollection.Configure<AppSettings>(configuration.GetSection("BaseConfiguration"));
            serviceCollection.Configure<WebServiceConfiguration>(configuration.GetSection("WebServiceConfiguration"));

            // add services
            serviceCollection.AddTransient<ITestService, TestService>();
            serviceCollection.AddTransient<IMathProcessor, MathProcessor>();
            serviceCollection.AddSingleton<IWebServiceTest, WebServiceTest>();

            // add app
            serviceCollection.AddTransient<App>();
        }
        
    }
}
