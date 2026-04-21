namespace Domain.Entites
{
    public class BlogPostTag
    {
        public BlogPost BlogPost { get; set; }
        public int PostId { get; set; }
        public Tag Tag { get; set; }
        public int TagId { get; set; }
    }
}
