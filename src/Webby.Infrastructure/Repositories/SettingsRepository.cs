using Microsoft.EntityFrameworkCore;
using Webby.Core.Domain.Entities;
using Webby.Core.Interfaces.Repositories;
using Webby.Infrastructure.Data;

namespace Webby.Infrastructure.Repositories;

public class SettingsRepository : ISettingsRepository
{
    private readonly WebbyDbContext _db;

    public SettingsRepository(WebbyDbContext db) => _db = db;

    public async Task<Setting?> GetByKeyAsync(string key, CancellationToken ct = default)
        => await _db.Settings.FirstOrDefaultAsync(s => s.Key == key, ct);

    public async Task<IEnumerable<Setting>> GetAllAsync(CancellationToken ct = default)
        => await _db.Settings.ToListAsync(ct);

    public async Task UpsertAsync(string key, string? value, CancellationToken ct = default)
    {
        var existing = await _db.Settings.FirstOrDefaultAsync(s => s.Key == key, ct);
        if (existing is not null)
        {
            existing.Value = value;
        }
        else
        {
            _db.Settings.Add(new Setting { Key = key, Value = value });
        }

        await _db.SaveChangesAsync(ct);
    }
}
