using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpBoard.App.Config;

namespace SharpBoard
{
    public static class Util
    {
        public static string ErrorNameFromCode(ErrorCode code)
        {
            return Enum.GetName(typeof (ErrorCode), code);
        }

        public static Uri GetUri()
        {
            string envUrl = Environment.GetEnvironmentVariable("SharpboardURL", EnvironmentVariableTarget.Machine);

            if (envUrl == null)
            {
                Console.WriteLine("Error: System environment variable \"SharpboardURL\" not found! Make sure you set it at the machine level!");
            }

            Uri hostUri = new Uri("http://localhost:80");

            try
            {
                hostUri = new Uri(envUrl);
            }
            catch (UriFormatException)
            {
                Console.WriteLine("Error: URI \"{0}\" is malformed. Using default of \"{1}\"", envUrl, hostUri.OriginalString);
            }

            return hostUri;
        }
    }
}
