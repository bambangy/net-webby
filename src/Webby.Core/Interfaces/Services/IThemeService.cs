namespace Webby.Core.Interfaces.Services;

public interface IThemeService
{
    Task<string> GetActiveThemeNameAsync(CancellationToken ct = default);
}
