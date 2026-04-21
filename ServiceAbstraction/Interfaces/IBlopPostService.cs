using Shared.DTOs.BlogPostModule;

namespace ServiceAbstraction.Interfaces
{
    public interface IBlopPostService
    {
        //  Retrieve all blog posts With ( status and Category )
        Task<IEnumerable<BlogPostResultDTO>> GetAllAsync(BlogPostSpecificationParameter parameter);

        //  Retrieve blog post By id
        Task<BlogPostResultDTO?> GetByIdAsync(int postId);

        //  Update blog post By id
        Task<BlogPostResultDTO> UpdateAsync(int postId, UpdateBlogPostDTO blogDTO);

        // Create Blog Post 
        Task<BlogPostResultDTO> CreateAsync(BlogPostRequestDTO blogDto);

        // Delete Blog Post By Id 
        Task<bool> DeleteAsync(int postId);

    }

}
