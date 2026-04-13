using Domain.Entites;
using Domain.Entites.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Data.Configrations
{
    public class BlogPostConfigrations : IEntityTypeConfiguration<BlogPost>
    {
        public void Configure(EntityTypeBuilder<BlogPost> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                   .HasMaxLength(200);

            // Category
            builder.HasOne(x => x.Category)
                   .WithMany(x => x.BlogPosts)
                   .HasForeignKey(x => x.CategoryId);

            // Comment
            builder.HasMany(x => x.Comments)
                   .WithOne(x => x.BlogPost)
                   .HasForeignKey(x => x.PostId);

            // Enum Status 
            // عادي Enum انما وامن بنرجعهالي رجعها ك string كا Database كدا بقولو خزنها في ال 
            builder.Property(x => x.Status).HasConversion(
                            s => s.ToString(), s => Enum.Parse<Status>(s));
        }
    }
}
