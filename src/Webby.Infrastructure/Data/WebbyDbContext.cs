using Microsoft.EntityFrameworkCore;
using Webby.Core.Domain.Entities;
using Webby.Infrastructure.Seed;

namespace Webby.Infrastructure.Data;

public class WebbyDbContext : DbContext
{
    public WebbyDbContext(DbContextOptions<WebbyDbContext> options)
        : base(options) { }

    public DbSet<Post> Posts => Set<Post>();
    public DbSet<Page> Pages => Set<Page>();
    public DbSet<Setting> Settings => Set<Setting>();
    public DbSet<Tag> Tags => Set<Tag>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<PostTag> PostTags => Set<PostTag>();
    public DbSet<PostCategory> PostCategories => Set<PostCategory>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(WebbyDbContext).Assembly);

        modelBuilder.Entity<Setting>().HasData(SeedData.Settings);
        modelBuilder.Entity<Post>().HasData(SeedData.PostsForSeed);
        modelBuilder.Entity<Page>().HasData(SeedData.PagesForSeed);

        base.OnModelCreating(modelBuilder);
    }
}
