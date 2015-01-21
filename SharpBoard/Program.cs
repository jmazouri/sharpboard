using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy.Hosting.Self;
using Topshelf;

namespace SharpBoard
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.Service<NancyHost>(s =>
                {
                    s.ConstructUsing(name => new NancyHost(Util.GetUri()));
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });

                x.RunAsLocalSystem();
                x.StartAutomatically();

                
                x.SetDescription("SharpBoard Image Board Server");
                x.SetDisplayName("Sharpboard");
                x.SetServiceName("Sharpboard");
            });
        }
    }
}
