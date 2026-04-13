using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class Category : BaseEntity<int>
    {
        public string Name { get; set; } = string.Empty;

        #region Relations

        public ICollection<BlogPost> BlogPosts { get; set; }
        #endregion
    }
}
