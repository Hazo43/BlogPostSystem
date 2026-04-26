using Domain.Entites;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Data.DbContexts
{
    public class BlogDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Identity عشان ال
            base.OnModelCreating(modelBuilder);
          
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssemblyReference).Assembly);
        }
       public DbSet<BlogPost> BlogPosts { get; set; }
       public DbSet<Tag> Tags { get; set; }
       public DbSet<Comment> Comments { get; set; }
       public DbSet<Category> Categories { get; set; }
       public DbSet<BlogPostTag> BlogPostTags { get; set; }
    }
}
