using Microsoft.EntityFrameworkCore;
using Webby.Core.Domain.Entities;
using Webby.Core.Domain.Enums;
using Webby.Core.Interfaces.Repositories;
using Webby.Infrastructure.Data;

namespace Webby.Infrastructure.Repositories;

public class PostRepository : IPostRepository
{
    private readonly WebbyDbContext _db;

    public PostRepository(WebbyDbContext db) => _db = db;

    public async Task<IEnumerable<Post>> GetPublishedAsync(int page, int pageSize, CancellationToken ct = default)
        => await _db.Posts
            .Where(p => p.Status == PostStatus.Published)
            .OrderByDescending(p => p.PublishedAt)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Include(p => p.PostTags).ThenInclude(pt => pt.Tag)
            .Include(p => p.PostCategories).ThenInclude(pc => pc.Category)
            .ToListAsync(ct);

    public async Task<int> CountPublishedAsync(CancellationToken ct = default)
        => await _db.Posts.CountAsync(p => p.Status == PostStatus.Published, ct);

    public async Task<Post?> GetBySlugAsync(string slug, CancellationToken ct = default)
        => await _db.Posts
            .Include(p => p.PostTags).ThenInclude(pt => pt.Tag)
            .Include(p => p.PostCategories).ThenInclude(pc => pc.Category)
            .FirstOrDefaultAsync(p => p.Slug == slug, ct);
}
