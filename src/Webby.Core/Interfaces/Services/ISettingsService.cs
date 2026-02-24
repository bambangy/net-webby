namespace Webby.Core.Interfaces.Services;

public interface ISettingsService
{
    Task<string?> GetAsync(string key, CancellationToken ct = default);
    Task<string> GetAsync(string key, string defaultValue, CancellationToken ct = default);
    Task SetAsync(string key, string? value, CancellationToken ct = default);
    Task<Dictionary<string, string?>> GetAllAsync(CancellationToken ct = default);
}
