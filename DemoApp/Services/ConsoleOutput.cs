using DemoApp.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DemoApp.Services
{
    public class ConsoleOutput : IOutput
    {
        public void Write(string content)
        {
            Console.WriteLine(content);
        }
    }
}
