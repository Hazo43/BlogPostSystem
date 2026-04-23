using Domain.Entites;

namespace Service.Specifications
{
    public class CommentByPostIdSpecification : BaseSpecifications<Comment, int>
    {
        public CommentByPostIdSpecification(int id) : base(c => c.Id == id)
        {
            AddInclude(c => c.User);    // AuthorName (UserName)
            AddInclude(c => c.BlogPost);// PostTittle
        }
    }
}
