using Domain.Entites.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class User : BaseEntity<int>
    {

        public string Username { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string PasswordHash { get; set; } = default!;
        public Role Role { get; set; }

        #region Relations

        // Blog System ( 1 - m )
        public ICollection<BlogPost> BlogPosts { get; set; }

        // Comment ( 1 - m )
        public ICollection<Comment> Comments { get; set; }



        #endregion

    }

}
