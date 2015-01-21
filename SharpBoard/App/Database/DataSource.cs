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
        protected static PetaPoco.Database Database;

        protected DataSource()
        {
            if (Database == null)
            {
                Database = new PetaPoco.Database("DefaultDBConnection");
            }
        }
    }
}
