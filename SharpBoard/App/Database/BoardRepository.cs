using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpBoard.App.Config;
using SharpBoard.App.Models;

namespace SharpBoard.App.Database
{
    public class BoardRepository : DataSource
    {
        private static readonly List<Board> Boards = new List<Board>();

        public BoardRepository()
        {
            Boards.AddRange(BoardConfig.Boards);
        }

        public void LoadAllPosts()
        {
            foreach (var board in Boards)
            {
                LoadPostsForBoard(board);
            }
        }

        public void LoadPostsForBoard(Board board)
        {
            board.Posts.Clear();
            board.Posts.AddRange(Database.Query<Post>("SELECT * FROM \"posts\" WHERE \"BoardShorthand\"=@0 ORDER BY \"Time\" DESC", board.Shorthand));
        }

        public void LoadPostsForBoard(Board board, int start, int count)
        {
            board.Posts.Clear();
            board.Posts.AddRange(Database.Query<Post>("SELECT * FROM \"posts\" WHERE \"BoardShorthand\"=@0 ORDER BY \"Time\" DESC LIMIT @1 OFFSET @2", board.Shorthand, count, start));
        }

        public Board GetBoardFromShorthand(string shorthand)
        {
            return Boards.FirstOrDefault(d => d.Shorthand == shorthand);
        }

        public int PageCountForBoard(Board board, int maxPerPage)
        {
            return Database.ExecuteScalar<int>("SELECT (COUNT(*) / @0) FROM \"posts\" WHERE \"BoardShorthand\"=@1", maxPerPage, board.Shorthand);
        }
    }
}
