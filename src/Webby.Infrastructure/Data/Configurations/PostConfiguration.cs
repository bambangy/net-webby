using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Webby.Core.Domain.Entities;

namespace Webby.Infrastructure.Data.Configurations;

public class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.ToTable("Posts");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Title).IsRequired().HasMaxLength(500);
        builder.Property(p => p.Slug).IsRequired().HasMaxLength(500);
        builder.HasIndex(p => p.Slug).IsUnique();
        builder.Property(p => p.Content).IsRequired();
        builder.Property(p => p.Excerpt).HasMaxLength(1000);
        builder.Property(p => p.FeaturedImageUrl).HasMaxLength(2000);
        builder.Property(p => p.Status).HasConversion<string>();
        builder.Property(p => p.CreatedAt).IsRequired();
        builder.Property(p => p.UpdatedAt).IsRequired();
    }
}
