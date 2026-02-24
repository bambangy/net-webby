using Webby.Core.Domain.Entities;
using Webby.Core.Domain.Enums;

namespace Webby.Infrastructure.Seed;

public static class SeedData
{
    private static readonly DateTime Jan1 = new(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc);
    private static readonly DateTime Jan15 = new(2026, 1, 15, 0, 0, 0, DateTimeKind.Utc);

    // Used by HasData() in migrations — navigation props must NOT be set
    public static IReadOnlyList<Post> PostsForSeed => new List<Post>
    {
        new Post
        {
            Id = 1,
            Title = "Welcome to Webby",
            Slug = "welcome-to-webby",
            Content = "<p>Welcome to <strong>Webby</strong>, your new CMS built on ASP.NET Core 8 with Tailwind CSS.</p><p>Webby is designed to be simple, fast, and extensible — just like WordPress but for the .NET world.</p>",
            Excerpt = "Get started with Webby, the WordPress-like CMS for .NET developers.",
            Status = PostStatus.Published,
            CreatedAt = Jan1,
            UpdatedAt = Jan1,
            PublishedAt = Jan1
        },
        new Post
        {
            Id = 2,
            Title = "Getting Started with Themes",
            Slug = "getting-started-with-themes",
            Content = "<p>Webby supports folder-based themes. Each theme lives in <code>Themes/{name}/</code> and can override any view. Switching themes is as simple as updating a setting in the database.</p><p>The default theme uses Tailwind CSS and Flowbite components.</p>",
            Excerpt = "Learn how to create and switch themes in Webby.",
            Status = PostStatus.Published,
            CreatedAt = Jan15,
            UpdatedAt = Jan15,
            PublishedAt = Jan15
        }
    };

    // Used by in-memory repos — navigation props can be set
    public static IReadOnlyList<Post> Posts => new List<Post>
    {
        new Post
        {
            Id = 1,
            Title = "Welcome to Webby",
            Slug = "welcome-to-webby",
            Content = "<p>Welcome to <strong>Webby</strong>, your new CMS built on ASP.NET Core 8 with Tailwind CSS.</p><p>Webby is designed to be simple, fast, and extensible — just like WordPress but for the .NET world.</p>",
            Excerpt = "Get started with Webby, the WordPress-like CMS for .NET developers.",
            Status = PostStatus.Published,
            CreatedAt = Jan1,
            UpdatedAt = Jan1,
            PublishedAt = Jan1,
            PostTags = [],
            PostCategories = []
        },
        new Post
        {
            Id = 2,
            Title = "Getting Started with Themes",
            Slug = "getting-started-with-themes",
            Content = "<p>Webby supports folder-based themes. Each theme lives in <code>Themes/{name}/</code> and can override any view. Switching themes is as simple as updating a setting in the database.</p><p>The default theme uses Tailwind CSS and Flowbite components.</p>",
            Excerpt = "Learn how to create and switch themes in Webby.",
            Status = PostStatus.Published,
            CreatedAt = Jan15,
            UpdatedAt = Jan15,
            PublishedAt = Jan15,
            PostTags = [],
            PostCategories = []
        }
    };

    public static IReadOnlyList<Page> PagesForSeed => new List<Page>
    {
        new Page
        {
            Id = 1,
            Title = "About Webby",
            Slug = "about",
            Content = "<p><strong>Webby</strong> is an open-source CMS built with ASP.NET Core 8, Entity Framework Core, and Tailwind CSS.</p><p>It supports MySQL and PostgreSQL databases, folder-based theming, and a WordPress-inspired settings system.</p><p>This is Phase 1 — a simple public site with posts and pages. More features are coming!</p>",
            MetaDescription = "Learn about Webby, the .NET CMS.",
            Status = PageStatus.Published,
            SortOrder = 1,
            CreatedAt = Jan1,
            UpdatedAt = Jan1
        }
    };

    public static IReadOnlyList<Page> Pages => PagesForSeed;

    public static IReadOnlyList<Setting> Settings => new List<Setting>
    {
        new Setting { Id = 1, Key = "site.title",     Value = "Webby",                  Description = "Site display title" },
        new Setting { Id = 2, Key = "site.tagline",   Value = "A .NET CMS",             Description = "Site tagline shown in header" },
        new Setting { Id = 3, Key = "active.theme",   Value = "default",                Description = "Active theme folder name" },
        new Setting { Id = 4, Key = "posts.per.page", Value = "5",                      Description = "Number of posts shown per page on home" },
        new Setting { Id = 5, Key = "admin.email",    Value = "admin@webby.example",    Description = "Administrator email address" }
    };
}
