using Domain.Entites;
using ServiceAbstraction;
using Shared.Enums;

namespace Service.Specifications
{
    public class BlogPostWithCategoryAndStatus : BaseSpecifications<BlogPost, int>
    {
        // Get All
        public BlogPostWithCategoryAndStatus(BlogPostSpecificationParameter parameter) :
            base(b => (!parameter.CategoryId.HasValue || b.CategoryId == parameter.CategoryId) &&
                       (!parameter.Status.HasValue || b.Status == parameter.Status))
        {
            AddInclude(b => b.Category);
            AddInclude(b => b.User);
            AddInclude(x => x.BlogPostTags);
            AddInclude("BlogPostTags.Tag");

            switch (parameter.Sort)
            {
                case BlogPostSort.CreatedAtAsc:
                    AddOrderBy(b => b.CreatedAt);
                    break;
                case BlogPostSort.CreatedAtDesc:
                    AddOrderByDesc(b => b.CreatedAt);
                    break;
                case BlogPostSort.TitleAsc:
                    AddOrderBy(b => b.Title);
                    break;
                case BlogPostSort.TitleDesc:
                    AddOrderByDesc(b => b.Title);
                    break;
                case BlogPostSort.UpdatedAtAsc:
                    AddOrderBy(b => b.UpdatedAt);
                    break;
                case BlogPostSort.UpdatedAtDSec:
                    AddOrderByDesc(b => b.UpdatedAt);
                    break;
                default:
                    AddOrderBy(b => b.Id);
                    break;

            }
        }

        // Get By Id 
        public BlogPostWithCategoryAndStatus(int id) : base(b => b.Id == id)
        {
            AddInclude(b => b.Category);
            AddInclude(b => b.User);
            AddInclude(b => b.BlogPostTags);
            AddInclude("BlogPostTags.Tag");
        }
    }
}
