using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TpBooks.Service
{
    public class Contextdto
    {
        public class Contextdto : DbContext
        {
            public DbSet<Bookdto> Books { get; set; }
            public DbSet<Shelvesdto> Shelves { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder options)
                => options.UseSqlite("Data Source=blogging.db");
        }
    }
}
