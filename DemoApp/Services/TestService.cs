using Common.Models;
using DemoApp.Interfaces;
using DemoApp.Models;
using MCMathLib;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoApp.Services
{
    class TestService : ITestService
    {
        private readonly ILogger<TestService> _logger;
        private readonly AppSettings _config;
        private readonly IMathProcessor _math;

        public TestService(ILogger<TestService> logger, IOptions<AppSettings> config, IMathProcessor math)
        {
            _logger = logger;
            _config = config.Value;
            _math = math;
        }

        public void Run()
        {
            bool close = false;
            while (!close)
            {
                Console.WriteLine("To exit, please press 0....");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "0":
                        close = true;
                        break;
                    default:
                        Console.WriteLine("Enter first number");
                        var res1 = Console.ReadLine();
                        var num1 = Convert.ToInt32(res1);

                        Console.WriteLine("Enter next number");
                        var res2 = Console.ReadLine();
                        var num2 = Convert.ToInt32(res2);

                        Console.WriteLine("What operation (Add/Sub/Mul/Div)?");
                        var op = Console.ReadLine();

                        Console.WriteLine($"Result: {_math.Calculate(num1, num2, op)}");
                        break;

                }
            }


        }
    }
}
