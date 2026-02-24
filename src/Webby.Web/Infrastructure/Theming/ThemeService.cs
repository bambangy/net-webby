using Webby.Core.Domain.Constants;
using Webby.Core.Interfaces.Services;

namespace Webby.Web.Infrastructure.Theming;

public class ThemeService : IThemeService
{
    private readonly ISettingsService _settingsService;

    public ThemeService(ISettingsService settingsService)
    {
        _settingsService = settingsService;
    }

    public async Task<string> GetActiveThemeNameAsync(CancellationToken ct = default)
        => await _settingsService.GetAsync(SettingKeys.ActiveTheme, "default", ct);
}
