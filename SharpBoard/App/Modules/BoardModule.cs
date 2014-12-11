﻿using System.Linq;
using Nancy;
using SharpBoard.App.Config;
using SharpBoard.App.Models;

namespace SharpBoard.App.Modules
{
    public class BoardModule : NancyModule
    {
        public BoardModule()
        {
            Get["/{shorthand}"] = _ =>
            {
                Board foundBoard = BoardConfig.Boards.FirstOrDefault(d => d.Shorthand == _.shorthand);

                if (foundBoard != null)
                {
                    return View["Boards/SingleBoard", foundBoard];
                }

                return View["Shared/Error", "Board does not exist."];
            };
        }
    }
}