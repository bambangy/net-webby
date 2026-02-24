using Microsoft.EntityFrameworkCore;
using Webby.Core.Domain.Entities;
using Webby.Core.Domain.Enums;
using Webby.Core.Interfaces.Repositories;
using Webby.Infrastructure.Data;

namespace Webby.Infrastructure.Repositories;

public class PageRepository : IPageRepository
{
    private readonly WebbyDbContext _db;

    public PageRepository(WebbyDbContext db) => _db = db;

    public async Task<Page?> GetBySlugAsync(string slug, CancellationToken ct = default)
        => await _db.Pages.FirstOrDefaultAsync(p => p.Slug == slug, ct);

    public async Task<IEnumerable<Page>> GetPublishedAsync(CancellationToken ct = default)
        => await _db.Pages
            .Where(p => p.Status == PageStatus.Published)
            .OrderBy(p => p.SortOrder)
            .ToListAsync(ct);
}
