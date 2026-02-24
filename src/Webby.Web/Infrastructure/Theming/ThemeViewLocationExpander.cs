using Microsoft.AspNetCore.Mvc.Razor;
using Webby.Core.Interfaces.Services;

namespace Webby.Web.Infrastructure.Theming;

public class ThemeViewLocationExpander : IViewLocationExpander
{
    private const string ThemeKey = "theme";

    // Called once per request before view resolution.
    // Stores the active theme name so MVC can use it as part of the cache key.
    public void PopulateValues(ViewLocationExpanderContext context)
    {
        var themeService = context.ActionContext.HttpContext
            .RequestServices.GetRequiredService<IThemeService>();

        // IViewLocationExpander has no async path.
        // SettingsService caches settings in-memory, so this is a dictionary lookup
        // after the first request — effectively zero-cost synchronous work.
        var themeName = themeService.GetActiveThemeNameAsync()
            .GetAwaiter().GetResult();

        context.Values[ThemeKey] = themeName;
    }

    // Prepends theme-specific paths before the default view locations.
    // If a theme view exists, it is used. Otherwise MVC falls back to /Views/.
    public IEnumerable<string> ExpandViewLocations(
        ViewLocationExpanderContext context,
        IEnumerable<string> viewLocations)
    {
        if (!context.Values.TryGetValue(ThemeKey, out var themeName)
            || string.IsNullOrWhiteSpace(themeName))
        {
            return viewLocations;
        }

        var themeLocations = new[]
        {
            $"/Themes/{themeName}/Views/{{1}}/{{0}}.cshtml",
            $"/Themes/{themeName}/Views/Shared/{{0}}.cshtml",
        };

        return themeLocations.Concat(viewLocations);
    }
}
