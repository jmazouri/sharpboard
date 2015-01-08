using System;
using System.Linq;
using Nancy;
using Nancy.ModelBinding;
using Nancy.Responses;
using Nancy.Validation;
using SharpBoard.App.Config;
using SharpBoard.App.Database;
using SharpBoard.App.Models;

namespace SharpBoard.App.Modules
{
    public class PostModule : NancyModule
    {
        public PostModule()
            : base("/{shorthand}/post")
        {
            DataSource ds = new DataSource();
            Board foundBoard;

            Before += ctx => 
            {
                foundBoard = BoardConfig.Boards.FirstOrDefault(d => d.Shorthand == ctx.Parameters.shorthand);

                if (foundBoard == null)
                {
                    return new RedirectResponse("/error/" + Util.ErrorNameFromCode(ErrorCode.MissingBoard), RedirectResponse.RedirectType.Temporary);
                }

                return null;
            };

            Get[""] = _ =>
            {
                return View["Post/NewPost"];
            };

            Post[""] = _ =>
            {
                var newPost = this.Bind<Post>();
                var result = this.Validate(newPost);

                if (!result.IsValid)
                {
                }
            };
        }
    }
}
