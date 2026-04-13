using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Data.Configrations
{
    public class BlogPostTagConfigrations : IEntityTypeConfiguration<BlogPostTag>
    {
        public void Configure(EntityTypeBuilder<BlogPostTag> builder)
        {
            builder.HasKey( k => new { k.PostId, k.TagId } );

            // BlogPost
            builder.HasOne(x => x.BlogPost)
                   .WithMany(x => x.BlogPostTags)
                   .HasForeignKey(x => x.PostId);

            // Tag
            builder.HasOne( x => x.Tag)
                   .WithMany( x => x.BlogPostTags)
                   .HasForeignKey( x => x.TagId);
        }
    }
}
