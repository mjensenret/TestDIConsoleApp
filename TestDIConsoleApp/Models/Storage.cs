using System;
using System.Collections.Generic;
using System.Text;
using TestDIConsoleApp.Interfaces;

namespace TestDIConsoleApp.Models
{
    public class Storage : IStorage
    {
        public string BlobStorage { get; set; }
        public string Database { get; set; }
        public string TableStorage { get; set; }
    }
}
