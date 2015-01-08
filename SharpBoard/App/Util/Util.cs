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
    }
}
