using Webby.Core.Domain.Entities;

namespace Webby.Core.Interfaces.Repositories;

public interface ISettingsRepository
{
    Task<Setting?> GetByKeyAsync(string key, CancellationToken ct = default);
    Task<IEnumerable<Setting>> GetAllAsync(CancellationToken ct = default);
    Task UpsertAsync(string key, string? value, CancellationToken ct = default);
}
