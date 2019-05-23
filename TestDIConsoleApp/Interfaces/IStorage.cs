using System;
using System.Collections.Generic;
using System.Text;

namespace TestDIConsoleApp.Interfaces
{
    public interface IStorage
    {
        string BlobStorage { get; }
        string Database { get; }
        string TableStorage { get; }
    }
}
