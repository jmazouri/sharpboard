using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy.Hosting.Self;

namespace SharpBoard
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var host = new NancyHost(new Uri("http://localhost:1234")))
            {
                Console.WriteLine("Starting Host...");
                host.Start();
                Console.WriteLine("Started!");

                Console.ReadLine();
            }
        }
    }
}
