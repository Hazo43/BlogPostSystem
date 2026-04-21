namespace Shared.DTOs.BlogPostModule
{
    public record BlogPostResultDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } // اتعمل ايمتا يعني 
        public DateTime? UpdatedAt { get; set; } // اتحدث ايمتا يعني 
        public string Status { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string AuthorName { get; set; } = string.Empty;
        public List<string> Tags { get; set; } = new();
    }
}
