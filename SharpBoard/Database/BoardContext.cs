using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpBoard.Models;

namespace SharpBoard.Database
{
    public class BoardContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
    }
}
