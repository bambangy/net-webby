using Webby.Core.Domain.Entities;
using Webby.Core.Domain.Enums;
using Webby.Core.Interfaces.Repositories;
using Webby.Infrastructure.Seed;

namespace Webby.Infrastructure.Repositories;

public class InMemoryPageRepository : IPageRepository
{
    private readonly IReadOnlyList<Page> _pages = SeedData.Pages;

    public Task<Page?> GetBySlugAsync(string slug, CancellationToken ct = default)
    {
        var page = _pages.FirstOrDefault(p => p.Slug == slug);
        return Task.FromResult(page);
    }

    public Task<IEnumerable<Page>> GetPublishedAsync(CancellationToken ct = default)
    {
        IEnumerable<Page> result = _pages
            .Where(p => p.Status == PageStatus.Published)
            .OrderBy(p => p.SortOrder);

        return Task.FromResult(result);
    }
}
