using System.Linq;
using Nancy;
using Nancy.Responses;
using SharpBoard.App.Config;
using SharpBoard.App.Database;
using SharpBoard.App.Models;

namespace SharpBoard.App.Modules
{
    public class BoardModule : NancyModule
    {
        public BoardModule()
        {
            Get["/{shorthand}/{page?0}"] = _ =>
            {
                BoardRepository repo = new BoardRepository();

                Board foundBoard = repo.GetBoardFromShorthand(_.shorthand);

                if (foundBoard != null)
                {
                    repo.LoadPostsForBoard(foundBoard, ((_.page) * GeneralConfig.PostsPerPage), GeneralConfig.PostsPerPage);
                    int curPages = repo.PageCountForBoard(foundBoard, GeneralConfig.PostsPerPage);

                    return View["Boards/SingleBoard", new {foundBoard, curPages, currentPage = _.page, PartialTitle = foundBoard.FullName}];
                }

                return new RedirectResponse("/error/" + Util.ErrorNameFromCode(ErrorCode.MissingBoard), RedirectResponse.RedirectType.Temporary);
            };
        }
    }
}
