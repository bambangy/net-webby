using Webby.Core.Interfaces.Repositories;
using Webby.Core.Interfaces.Services;

namespace Webby.Infrastructure.Services;

public class SettingsService : ISettingsService
{
    private readonly ISettingsRepository _repository;
    private Dictionary<string, string?>? _cache;

    public SettingsService(ISettingsRepository repository)
    {
        _repository = repository;
    }

    public async Task<string?> GetAsync(string key, CancellationToken ct = default)
    {
        await EnsureCacheAsync(ct);
        return _cache!.TryGetValue(key, out var value) ? value : null;
    }

    public async Task<string> GetAsync(string key, string defaultValue, CancellationToken ct = default)
        => await GetAsync(key, ct) ?? defaultValue;

    public async Task SetAsync(string key, string? value, CancellationToken ct = default)
    {
        await _repository.UpsertAsync(key, value, ct);
        _cache = null;
    }

    public async Task<Dictionary<string, string?>> GetAllAsync(CancellationToken ct = default)
    {
        await EnsureCacheAsync(ct);
        return new Dictionary<string, string?>(_cache!);
    }

    private async Task EnsureCacheAsync(CancellationToken ct)
    {
        if (_cache is null)
        {
            var all = await _repository.GetAllAsync(ct);
            _cache = all.ToDictionary(s => s.Key, s => s.Value);
        }
    }
}
