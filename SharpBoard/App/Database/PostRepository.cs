using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpBoard.App.Models;

namespace SharpBoard.App.Database
{
    public class PostRepository : DataSource
    {
        public void InsertPost(Post post)
        {
            Database.Insert("posts", "PostId", true, post);
        }
    }
}
