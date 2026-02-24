using Webby.Core.Domain.Entities;

namespace Webby.Core.Interfaces.Repositories;

public interface IPageRepository
{
    Task<Page?> GetBySlugAsync(string slug, CancellationToken ct = default);
    Task<IEnumerable<Page>> GetPublishedAsync(CancellationToken ct = default);
}
