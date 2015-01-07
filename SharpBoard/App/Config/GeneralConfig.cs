using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using SharpBoard.App.Models;

namespace SharpBoard.App.Config
{
    public static class GeneralConfig
    {
        public static int PostsPerPage { get; set; }
 
        public static void Load()
        {
            string jsonData = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "Data", "Config", "General.json"));
            dynamic loadedData = JsonConvert.DeserializeObject(jsonData);

            PostsPerPage = loadedData.PostsPerPage;
        }
    }
}