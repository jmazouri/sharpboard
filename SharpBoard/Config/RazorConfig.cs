using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy.ViewEngines.Razor;

namespace SharpBoard.Config
{
    public class RazorConfig : IRazorConfiguration
    {
        public IEnumerable<string> GetAssemblyNames()
        {
            yield return "SharpBoard";
        }

        public IEnumerable<string> GetDefaultNamespaces()
        {
            yield return "SharpBoard.Models";
        }

        public bool AutoIncludeModelNamespace
        {
            get { return true; }
        }
    }
}
