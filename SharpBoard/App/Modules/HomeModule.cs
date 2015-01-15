using System;
using Nancy;
using SharpBoard.App.Config;

namespace SharpBoard.App.Modules
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] = _ => View["Home/Index", new {PartialTitle = "Home"}];
            Get["/error/{errorcode?}"] = _ =>
            {
                string errorString = ErrorHandling.Codes[ErrorCode.Default];

                if (_.errorcode != null)
                {
                    errorString = ErrorHandling.Codes[Enum.Parse(typeof (ErrorCode), _.errorcode)];
                }

                return View["Shared/Error", new {errorString, PartialTitle = "Error"}].WithStatusCode(HttpStatusCode.NotFound);
            };
        }
    }
}
