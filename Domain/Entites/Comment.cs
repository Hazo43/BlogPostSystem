using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class Comment : BaseEntity<int>
    {

        public string Content { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }

        #region Relations

        // o PostId (Foreign Key referencing BlogPost) 
        public BlogPost BlogPost { get; set; }
        public int PostId { get; set; }

        // o AuthorId(Foreign Key referencing User)
        public User User { get; set; }
        public int AuthorId { get; set; }
        #endregion
    }
}
