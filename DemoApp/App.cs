using Common.Models;
using DemoApp.Interfaces;
using DemoApp.Models;
using MCMathLib;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoApp
{
    public class App
    {
        private readonly ITestService _testService;
        private readonly ILogger<App> _logger;
        private readonly AppSettings _config;
        private readonly IMathProcessor _math;
        private readonly IWebServiceTest _webServiceTest;

        public App(ITestService testService, ILogger<App> logger, IOptions<AppSettings> config, IMathProcessor math, IWebServiceTest webServiceTest)
        {
            _testService = testService;
            _logger = logger;
            _config = config.Value;
            _math = math;
            _webServiceTest = webServiceTest;
        }

        public void Run()
        {
            bool quit = false;
            while (!quit)
            {
                Console.Clear();
                Console.WriteLine(_config.Title);
                Console.WriteLine();
                Console.WriteLine($"Welcome to this simple console application.  Please choose from the following menu options:");
                Console.WriteLine($"1 - Run Calculator function");
                Console.WriteLine($"2 - Run Web Service Test");
                Console.WriteLine($"Any other key - Exit application");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        _testService.Run();
                        break;
                    case "2":
                        _webServiceTest.Run();
                        break;
                    default:
                        quit = true;
                        break;
                }
            }
        }
    }
}
