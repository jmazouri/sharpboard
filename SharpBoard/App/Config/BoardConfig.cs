using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using NLog;
using SharpBoard.App.Models;

namespace SharpBoard.App.Config
{
    public class BoardConfig : Configuration
    {
        public readonly List<Board> Boards = new List<Board>();
 
        public override void Load()
        {
            base.Load();

            var loadedData = JsonConvert.DeserializeAnonymousType(JsonData, new { Defaults = new Board(), Boards });
            Boards.Clear();
            Boards.AddRange(loadedData.Boards.Select(d => new Board()
            {
                Name = d.Name,
                Shorthand = d.Shorthand,
                MaxPages = (d.MaxPages == 0 ? loadedData.Defaults.MaxPages : d.MaxPages)
            }));
        }

        protected override string JsonPath
        {
            get { return Path.Combine("Data", "Config", "Boards.json"); }
        }

        protected override Configuration Default
        {
            get
            {
                BoardConfig ret = new BoardConfig();

                Board b = new Board()
                {
                    Name = "Random",
                    Shorthand = "b",
                    MaxPages = 10
                };

                ret.Boards.Add(b);

                return ret;
            }
        }
    }
}