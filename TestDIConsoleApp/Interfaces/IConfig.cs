using System;
using System.Collections.Generic;
using System.Text;
using TestDIConsoleApp.Models;

namespace TestDIConsoleApp.Interfaces
{
    public interface IConfig
    {
        FirstJob FirstJob { get; }
        Storage Storage { get; }
    }
}
