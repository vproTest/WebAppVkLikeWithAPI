using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppVkLike.Models
{
    public class Page
    {
        public Page()
        {
            Likes = new List<Like>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Like> Likes { get; set; }
    }
}