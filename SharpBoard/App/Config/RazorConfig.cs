using System.Collections.Generic;
using Nancy.ViewEngines.Razor;

namespace SharpBoard.App.Config
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
