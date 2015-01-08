using System;
using Nancy;
using SharpBoard.App.Config;

namespace SharpBoard.App.Modules
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] = _ => View["Home/Index"];
            Get["/error/{errorcode?}"] = _ =>
            {
                string errorString = ErrorCodes.Codes[ErrorCode.Default];

                if (_.errorcode != null)
                {
                    errorString = ErrorCodes.Codes[Enum.Parse(typeof (ErrorCode), _.errorcode)];
                }

                return View["Shared/Error", errorString].WithStatusCode(HttpStatusCode.NotFound);
            };
        }
    }
}
