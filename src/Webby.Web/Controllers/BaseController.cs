using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Webby.Core.Domain.Constants;
using Webby.Core.Interfaces.Services;

namespace Webby.Web.Controllers;

public abstract class BaseController : Controller
{
    protected readonly ISettingsService SettingsService;

    protected BaseController(ISettingsService settingsService)
    {
        SettingsService = settingsService;
    }

    public override async Task OnActionExecutionAsync(
        ActionExecutingContext context,
        ActionExecutionDelegate next)
    {
        ViewBag.SiteTitle = await SettingsService.GetAsync(SettingKeys.SiteTitle, "Webby");
        ViewBag.SiteTagline = await SettingsService.GetAsync(SettingKeys.SiteTagline, "A .NET CMS");
        await next();
    }
}
