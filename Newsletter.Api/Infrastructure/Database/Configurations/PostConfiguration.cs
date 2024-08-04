using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newsletter.Api.Entities;

namespace Newsletter.Api.Infrastructure.Database;

public class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.HasOne(p => p.User)
               .WithMany(p => p.Posts)
               .HasForeignKey(p => p.UserId);

        builder.HasMany(p => p.Votes)
               .WithOne(v => v.Post)
               .HasForeignKey(v => v.PostId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
