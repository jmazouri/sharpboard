using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpBoard.App.Config;
using SharpBoard.App.Models;

namespace SharpBoard.App.Database
{
    public class DataSource
    {
        private readonly PetaPoco.Database _database;

        public DataSource()
        {
            _database = new PetaPoco.Database("DefaultDBConnection");
            Boards.AddRange(BoardConfig.Boards);
        }

        public static List<Board> Boards = new List<Board>();

        public void LoadAllPosts()
        {
            foreach (Board board in Boards)
            {
                LoadPostsForBoard(board);
            }
        }

        public void LoadPostsForBoard(Board board)
        {
            board.Posts.Clear();
            board.Posts.AddRange(_database.Query<Post>("SELECT * FROM posts WHERE BoardShorthand=@0", board.Shorthand));
        }
    }
}
