using Domain.Entites.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class BlogPost : BaseEntity<int>
    {


        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } // اتعمل ايمتا يعني 
        public DateTime? UpdatedAt { get; set; } // اتحدث ايمتا يعني 
        public Status Status { get; set; }

        #region Relations

        public ICollection<Comment> Comments { get; set; }

        // 1- o AuthorId (Foreign Key referencing User) 
        public User User { get; set; }
        public int AuthorId { get; set; }

        // 2- o Tags (Many-to-Many relationship with Tags) 
        // BlogPostTag هنا عملنا جدول تالت
        public ICollection<BlogPostTag> BlogPostTags { get; set; }

        // 3- o CategoryId (Foreign Key referencing Category) 
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        #endregion
    }
}
