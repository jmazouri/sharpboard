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
        static int Main(string[] args)
        {
            string envUrl = Environment.GetEnvironmentVariable("SharpboardURL", EnvironmentVariableTarget.Machine);

            if (envUrl == null)
            {
                Console.WriteLine("Error: System environment variable \"SharpboardURL\" not found! Make sure you set it at the machine level!");
                return 203;
            }

            Uri hostUri = new Uri("http://localhost:80");

            try
            {
                hostUri = new Uri(envUrl);
            }
            catch (UriFormatException)
            {
                Console.WriteLine("Error: URI \"{0}\" is malformed. Using default of \"{1}\"", envUrl, hostUri.OriginalString);
                return 1;
            }
            
            using (var host = new NancyHost(hostUri))
            {
                Console.WriteLine("Starting Host...");
                host.Start();
                Console.WriteLine("Started!");

                Console.ReadLine();
                return 0;
            }
        }
    }
}
