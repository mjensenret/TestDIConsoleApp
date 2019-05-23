using Common.Models;
using DemoApp.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoApp.Services
{
    class WebServiceTest : IWebServiceTest
    {
        private readonly WebServiceConfiguration _config;

        public WebServiceTest(IOptions<WebServiceConfiguration> config)
        {
            _config = config.Value;
        }

        public void Run()
        {
            Console.WriteLine($"URL: {_config.URL}");
            Console.WriteLine($"UserName: {_config.UserName}");
            Console.WriteLine($"Password: {_config.Password}");
        }
    }
}
