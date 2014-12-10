using Nancy;

namespace SharpBoard.App.Modules
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] = _ => View["Home/Index"];
        }
    }
}
