using Webby.Core.Domain.Entities;
using Webby.Core.Domain.Enums;
using Webby.Core.Interfaces.Repositories;
using Webby.Infrastructure.Seed;

namespace Webby.Infrastructure.Repositories;

public class InMemoryPostRepository : IPostRepository
{
    private readonly IReadOnlyList<Post> _posts = SeedData.Posts;

    public Task<IEnumerable<Post>> GetPublishedAsync(int page, int pageSize, CancellationToken ct = default)
    {
        var result = _posts
            .Where(p => p.Status == PostStatus.Published)
            .OrderByDescending(p => p.PublishedAt)
            .Skip((page - 1) * pageSize)
            .Take(pageSize);

        return Task.FromResult(result);
    }

    public Task<int> CountPublishedAsync(CancellationToken ct = default)
    {
        var count = _posts.Count(p => p.Status == PostStatus.Published);
        return Task.FromResult(count);
    }

    public Task<Post?> GetBySlugAsync(string slug, CancellationToken ct = default)
    {
        var post = _posts.FirstOrDefault(p => p.Slug == slug);
        return Task.FromResult(post);
    }
}
