using System.Linq;
using Nancy;
using SharpBoard.App.Config;
using SharpBoard.App.Database;
using SharpBoard.App.Models;

namespace SharpBoard.App.Modules
{
    public class BoardModule : NancyModule
    {
        public BoardModule()
        {
            DataSource ds = new DataSource();

            Get["/{shorthand}/{page?0}"] = _ =>
            {
                Board foundBoard = BoardConfig.Boards.FirstOrDefault(d => d.Shorthand == _.shorthand);

                if (foundBoard != null)
                {
                    ds.LoadPostsForBoard(foundBoard, ((_.page) * GeneralConfig.PostsPerPage), GeneralConfig.PostsPerPage);
                    int curPages = ds.PageCountForBoard(foundBoard, GeneralConfig.PostsPerPage);

                    return View["Boards/SingleBoard", new {foundBoard, curPages, currentPage = _.page, PartialTitle = foundBoard.FullName}];
                }

                return View["Shared/Error", "Board does not exist."];
            };
        }
    }
}
