using Domain.Entites.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class User : IdentityUser<int>
    {
        public string DisplayName { get; set; } = string.Empty;

        #region Relations

        // Blog System ( 1 - m )
        public ICollection<BlogPost> BlogPosts { get; set; }

        // Comment ( 1 - m )
        public ICollection<Comment> Comments { get; set; }



        #endregion

    }

}
