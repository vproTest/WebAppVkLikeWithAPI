using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebAppVkLike.Models;

namespace WebAppVkLike.EFClasses
{
    public class LikeContext : DbContext
    {
        public LikeContext()
        {
            Database.SetInitializer(new LikeInitializer());

            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;

            Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public DbSet<Like> Likes { get; set; }
        public DbSet<Page> Pages { get; set; }
    }
}