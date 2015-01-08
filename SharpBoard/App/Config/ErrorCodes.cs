using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpBoard.App.Config
{
    public static class ErrorCodes
    {
        public static Dictionary<ErrorCode, string> Codes = new Dictionary<ErrorCode, string>
        {
            {ErrorCode.MissingBoard, "Board does not exist."},
            {ErrorCode.Default, "Some kind of error occurred. Sorry!"}
        }; 
    }

    public enum ErrorCode
    {
        MissingBoard,
        Default
    }
}
