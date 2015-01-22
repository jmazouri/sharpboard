using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using SharpBoard.App.Models;

namespace SharpBoard.App.Config
{
    public class GeneralConfig : Configuration
    {
        public static int PostsPerPage { get; set; }

        protected override string JsonPath
        {
            get { return Path.Combine("Data", "Config", "General.json"); }
        }

        protected override Configuration Default
        {
            get { return new GeneralConfig(); }
        }

        public override void Load()
        {
            base.Load();

            dynamic loadedData = JsonConvert.DeserializeObject(JsonData);
            PostsPerPage = loadedData.PostsPerPage;
        }
    }
}