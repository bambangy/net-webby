using Webby.Core.Domain.Enums;

namespace Webby.Core.Domain.Entities;

public class Page
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public string? MetaDescription { get; set; }
    public PageStatus Status { get; set; } = PageStatus.Draft;
    public int SortOrder { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
