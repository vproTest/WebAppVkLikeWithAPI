using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppVkLike.Models
{
    public class Like
    {
        public int Id { get; set; }
        public DateTime LkDateTime { get; set; }
        public int ? PageId { get; set; }

        public virtual Page Page { get; set; }
    }
}