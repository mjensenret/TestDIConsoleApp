using System;
using System.Collections.Generic;
using System.Text;
using TestDIConsoleApp.Interfaces;

namespace TestDIConsoleApp.Models
{
    public class Config : IConfig
    {
        public FirstJob FirstJob { get; set; }
        public Storage Storage { get; set; }
    }
}
