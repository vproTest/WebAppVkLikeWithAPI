using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebAppVkLike.Models;

namespace WebAppVkLike.EFClasses
{
    public class LikeInitializer : DropCreateDatabaseIfModelChanges<LikeContext>
    {
        protected override void Seed(LikeContext context)
        {
            base.Seed(context);

            Page first = new Page { Name = "FirstPage" };
            Page second = new Page { Name = "SecondPage" };
            context.Pages.AddRange(new List<Page> { first, second });
            context.SaveChanges();
        }
    }
}