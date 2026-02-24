using Webby.Core.Domain.Entities;

namespace Webby.Core.Interfaces.Repositories;

public interface IPostRepository
{
    Task<IEnumerable<Post>> GetPublishedAsync(int page, int pageSize, CancellationToken ct = default);
    Task<int> CountPublishedAsync(CancellationToken ct = default);
    Task<Post?> GetBySlugAsync(string slug, CancellationToken ct = default);
}
