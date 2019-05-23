using System;
using System.Collections.Generic;
using System.Text;

namespace TestDIConsoleApp.Interfaces
{
    public interface IFirstJob
    {
        string Name { get; }
        TimeSpan Trigger { get; }
    }
}
