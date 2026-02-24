using Webby.Core.Domain.Enums;

namespace Webby.Core.Domain.Entities;

public class Post
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public string? Excerpt { get; set; }
    public string? FeaturedImageUrl { get; set; }
    public PostStatus Status { get; set; } = PostStatus.Draft;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime? PublishedAt { get; set; }

    public ICollection<PostTag> PostTags { get; set; } = [];
    public ICollection<PostCategory> PostCategories { get; set; } = [];
}
