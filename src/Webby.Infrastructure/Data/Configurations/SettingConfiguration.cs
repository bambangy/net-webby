using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Webby.Core.Domain.Entities;

namespace Webby.Infrastructure.Data.Configurations;

public class SettingConfiguration : IEntityTypeConfiguration<Setting>
{
    public void Configure(EntityTypeBuilder<Setting> builder)
    {
        builder.ToTable("Settings");
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Key).IsRequired().HasMaxLength(200);
        builder.HasIndex(s => s.Key).IsUnique();
        builder.Property(s => s.Value).HasMaxLength(4000);
        builder.Property(s => s.Description).HasMaxLength(500);
    }
}
