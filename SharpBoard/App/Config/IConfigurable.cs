using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpBoard.App.Config
{
    public interface IConfigurable
    {
        string JsonData { get; set; }
        string JsonPath { get; }
        IConfigurable Default { get; }
        void Load();
    }
}
