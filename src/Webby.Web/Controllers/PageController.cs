using Microsoft.AspNetCore.Mvc;
using Webby.Core.Interfaces.Repositories;
using Webby.Core.Interfaces.Services;
using Webby.Web.Models.ViewModels;

namespace Webby.Web.Controllers;

public class PageController : BaseController
{
    private readonly IPageRepository _pageRepository;

    public PageController(IPageRepository pageRepository, ISettingsService settingsService)
        : base(settingsService)
    {
        _pageRepository = pageRepository;
    }

    [Route("about")]
    public async Task<IActionResult> About()
    {
        var page = await _pageRepository.GetBySlugAsync("about");
        if (page is null) return NotFound();

        var vm = new AboutViewModel
        {
            Title = page.Title,
            Content = page.Content
        };

        return View(vm);
    }
}
