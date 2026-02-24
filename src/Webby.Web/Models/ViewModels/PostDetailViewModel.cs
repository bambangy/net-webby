using Webby.Core.Domain.Entities;

namespace Webby.Web.Models.ViewModels;

public class PostDetailViewModel
{
    public string Title { get; init; } = string.Empty;
    public string Content { get; init; } = string.Empty;
    public string? Excerpt { get; init; }
    public string? FeaturedImageUrl { get; init; }
    public DateTime? PublishedAt { get; init; }
    public IReadOnlyList<string> Tags { get; init; } = [];
    public IReadOnlyList<string> Categories { get; init; } = [];

    public static PostDetailViewModel FromDomain(Post post) => new()
    {
        Title = post.Title,
        Content = post.Content,
        Excerpt = post.Excerpt,
        FeaturedImageUrl = post.FeaturedImageUrl,
        PublishedAt = post.PublishedAt,
        Tags = post.PostTags.Select(pt => pt.Tag.Name).ToList(),
        Categories = post.PostCategories.Select(pc => pc.Category.Name).ToList()
    };
}
