using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class BlogPostTag
    {
        public BlogPost BlogPost { get; set; }
        public int PostId { get; set; }
        public Tag Tag { get; set; }
        public int TagId { get; set; }
    }
}
