using System.Data.Entity;
using SharpBoard.App.Models;

namespace SharpBoard.App.Database
{
    public class BoardContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
    }
}
