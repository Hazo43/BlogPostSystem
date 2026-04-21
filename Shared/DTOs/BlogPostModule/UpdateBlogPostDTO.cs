namespace Shared.DTOs.BlogPostModule
{
    public record UpdateBlogPostDTO
    {
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
        public string Status { get; set; } = string.Empty;
        public List<int> TagIds { get; set; } = new();
    }
}
