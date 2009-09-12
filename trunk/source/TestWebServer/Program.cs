using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetAutoUpdate.Tests;
using System.IO;

namespace TestWebServer
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = Path.Combine(Environment.CurrentDirectory, @"..\..\Source\TestWebServer\Data");
            var webServer = new WebServer(new FileInfo(path).FullName, 12345);

            Console.WriteLine("Test web server started. This web server is only hosting static content.");
            Console.WriteLine("Press any key to quit...");
            Console.ReadKey();
        }
    }
}
