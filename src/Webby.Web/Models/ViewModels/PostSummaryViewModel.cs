using Webby.Core.Domain.Entities;

namespace Webby.Web.Models.ViewModels;

public class PostSummaryViewModel
{
    public string Title { get; init; } = string.Empty;
    public string Slug { get; init; } = string.Empty;
    public string? Excerpt { get; init; }
    public string? FeaturedImageUrl { get; init; }
    public DateTime? PublishedAt { get; init; }

    public static PostSummaryViewModel FromDomain(Post post) => new()
    {
        Title = post.Title,
        Slug = post.Slug,
        Excerpt = post.Excerpt,
        FeaturedImageUrl = post.FeaturedImageUrl,
        PublishedAt = post.PublishedAt
    };
}
