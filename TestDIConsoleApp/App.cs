using Autofac;
using MCMathLib;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestDIConsoleApp.Models;

namespace TestDIConsoleApp
{
    public class App
    {
        private readonly ILogger<App> _logger;
        private readonly IContainer _appSettings;
        private readonly IMathProcessor _math;


        //public App(IOptions<AppSettings> appSettings, ILogger<App> logger, MathProcessor math)
        //{
        //    _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        //    _appSettings = appSettings?.Value ?? throw new ArgumentNullException(nameof(appSettings));
        //    _math = math;
        //}

        public App(IMathProcessor math, ILogger<App> logger/*, IContainer configuration*/)
        {
            _math = math;
            _logger = logger;
            //_appSettings = configuration;
        }

        public async Task Run()
        {
            _logger.LogDebug("App Started......");
            //_logger.LogDebug(_appSettings.ToString());
            bool quit = false;
            while (!quit)
            {
                _logger.LogDebug("Running.....");
                Console.WriteLine("If you would like to calculate, please press 1, else press 0 to exit");
                var choice = Console.ReadLine();

                if(choice == "0")
                {
                    _logger.LogDebug("Exit has been pressed.....");
                    quit = true;
                }
                else
                {
                    Console.WriteLine("Enter first number");
                    var res1 = Console.ReadLine();
                    var num1 = Convert.ToInt32(res1);
                    _logger.LogDebug($"First number entered: {num1}");

                    Console.WriteLine("Enter next number");
                    var res2 = Console.ReadLine();
                    var num2 = Convert.ToInt32(res2);
                    _logger.LogDebug($"Second number entered: {num2}");

                    Console.WriteLine("What operation (Add/Sub/Mul/Div)?");
                    var op = Console.ReadLine();
                    _logger.LogDebug($"Operation entered: {op}");

                    Console.WriteLine($"Result: {_math.Calculate(num1, num2, op)}");
                    _logger.LogDebug($"Result: {_math.Calculate(num1, num2, op)}");
                }

            }


            await Task.CompletedTask;
        }
    }
}
