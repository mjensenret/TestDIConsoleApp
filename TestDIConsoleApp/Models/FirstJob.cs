using System;
using System.Collections.Generic;
using System.Text;
using TestDIConsoleApp.Interfaces;

namespace TestDIConsoleApp.Models
{
    public class FirstJob : IFirstJob
    {
        public string Name { get; set; }
        public TimeSpan Trigger => TimeSpan.FromSeconds(TriggerInSeconds);
        public int TriggerInSeconds { get; set; }
    }
}
