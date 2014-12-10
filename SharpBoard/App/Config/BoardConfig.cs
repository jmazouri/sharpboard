using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using SharpBoard.App.Models;

namespace SharpBoard.App.Config
{
    public static  class BoardConfig
    {
        public static List<Board> Boards = new List<Board>();
 
        public static void Load()
        {
            string jsonData = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "Data", "Config", "Boards.json"));
            var loadedData = JsonConvert.DeserializeAnonymousType(jsonData, new { Defaults = new Board(), Boards });

            Boards = loadedData.Boards.Select(d => new Board()
            {
                Name = d.Name,
                Shorthand = d.Shorthand,
                MaxPages = (d.MaxPages == 0 ? loadedData.Defaults.MaxPages : d.MaxPages)
            }).ToList();
        }
    }
}