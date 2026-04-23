namespace Shared.DTOs.CommentModule
{
    public record CommentRequestDTO
    {
        public string Content { get; set; } = string.Empty;
        public int PostId { get; set; }
        public int AuthorId { get; set; }
    }
}
