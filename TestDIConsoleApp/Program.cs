using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Autofac;
using Autofac.Configuration;
using Autofac.Extensions;
using System;
using MCMathLib;
using System.IO;
using static TestDIConsoleApp.Service1;
using System.Threading.Tasks;
using TestDIConsoleApp.Models;
using System.Reflection;
using System.Linq;
using Logger;
using ILogger = Microsoft.Extensions.Logging.ILogger;
using Autofac.Extensions.DependencyInjection;

namespace TestDIConsoleApp
{
    internal class Program
    {
        public static IContainer Container;
        public static IConfigurationRoot Configuration;

        public static async Task Main(string[] args)
        {
            //var services = new ServiceCollection();
            //ConfigureServices(services);
            //var serviceProvider = services.BuildServiceProvider();

            RegisterServices();

            App app = Container.Resolve<App>();

            await app.Run();
        }

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            // configure logging
            serviceCollection
                .AddLogging(b => b
                    .AddDebug()
                    .AddConsole()
                    .SetMinimumLevel(LogLevel.Debug)
                );

            // build config
            var config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", false, true)
               .AddEnvironmentVariables()
               .Build();

            serviceCollection.AddOptions();
            //serviceCollection.Configure<AppSettings>(config.GetSection("App"));


            // add services
            serviceCollection.AddTransient<Service2>();
            serviceCollection.AddTransient<Service1>();
            serviceCollection.AddTransient<MathInterface>();

            // add app
            serviceCollection.AddTransient<App>();
        }

        private static void RegisterServices()
        {
            var collection = new ServiceCollection();
            collection.AddLogging(b => b
                .AddDebug()
                .SetMinimumLevel(LogLevel.Debug)
            );

            var config = new ConfigurationBuilder();
            config
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

            var module = new ConfigurationModule(config.Build());

            var builder = new ContainerBuilder();

            builder.Populate(collection);            

            builder.RegisterType<App>();
            builder.RegisterType<MathProcessor>().As<IMathProcessor>();
            

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(t => t.Name.EndsWith("Processor"))
                .As(t => t.GetInterfaces().FirstOrDefault(
                    i => i.Name == "I" + t.Name));

            builder.RegisterModule(module);

            Container = builder.Build();

        }
    }
}
