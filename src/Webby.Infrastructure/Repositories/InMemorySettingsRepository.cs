using Webby.Core.Domain.Entities;
using Webby.Core.Interfaces.Repositories;
using Webby.Infrastructure.Seed;

namespace Webby.Infrastructure.Repositories;

public class InMemorySettingsRepository : ISettingsRepository
{
    private readonly List<Setting> _settings = SeedData.Settings.ToList();

    public Task<Setting?> GetByKeyAsync(string key, CancellationToken ct = default)
    {
        var setting = _settings.FirstOrDefault(s => s.Key == key);
        return Task.FromResult(setting);
    }

    public Task<IEnumerable<Setting>> GetAllAsync(CancellationToken ct = default)
    {
        return Task.FromResult<IEnumerable<Setting>>(_settings);
    }

    public Task UpsertAsync(string key, string? value, CancellationToken ct = default)
    {
        var existing = _settings.FirstOrDefault(s => s.Key == key);
        if (existing is not null)
            existing.Value = value;
        else
            _settings.Add(new Setting { Key = key, Value = value });

        return Task.CompletedTask;
    }
}
