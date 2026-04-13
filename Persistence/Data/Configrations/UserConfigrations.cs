using Domain.Entites;
using Domain.Entites.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configrations
{
    public class UserConfigrations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Username)
                   .HasMaxLength(100);

            builder.Property(x => x.Email)
                   .HasMaxLength(100).IsRequired();     
            
             builder.Property(x => x.PasswordHash)
                    .IsRequired();

            // BlogPost
            builder.HasMany(x => x.BlogPosts)
                   .WithOne(x => x.User)
                   .HasForeignKey(x => x.AuthorId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Comment
            builder.HasMany(x => x.Comments)
                   .WithOne(x => x.User)
                   .HasForeignKey(x => x.AuthorId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Enum Role
            // عادي Enum انما وامن بنرجعهالي رجعها ك string كا Database كدا بقولو خزنها في ال 
            builder.Property(x => x.Role).HasConversion(
                             r => r.ToString(), r => Enum.Parse<Role>(r));
        }
    }
}
