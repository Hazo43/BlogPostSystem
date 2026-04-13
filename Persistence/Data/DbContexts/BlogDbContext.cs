using Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Data.DbContexts
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssemblyReference).Assembly);
        }

       public DbSet<User> Users { get; set; }
       public DbSet<BlogPost> BlogPosts { get; set; }
       public DbSet<Tag> Tags { get; set; }
       public DbSet<Comment> Comments { get; set; }
       public DbSet<Category> Categories { get; set; }
       public DbSet<BlogPostTag> BlogPostTags { get; set; }
    }
}
