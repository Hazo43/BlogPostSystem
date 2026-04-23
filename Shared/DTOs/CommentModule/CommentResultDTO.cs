namespace Shared.DTOs.CommentModule
{
    public record CommentResultDTO
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public string AuthorName { get; set; } = string.Empty;
        public string PostTitle { get; set; } = string.Empty;
    }
}
