using System;
using System.Collections.Generic;
using System.Text;
 using Microsoft.EntityFrameworkCore;

namespace EF_Core_SetUP1
{
    class BloggingDb : DbContext
    {

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        // The following configures EF to create a Sqlite database file as `C:\blogging.db`.
        // For Mac or Linux, change this to `/tmp/blogging.db` or any other absolute path.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(@"Server=.;Database=BloggingDbVC;User Id = sa; Password=sa123; ");

        //DESKTOP-J1GS9KA

    }
}



