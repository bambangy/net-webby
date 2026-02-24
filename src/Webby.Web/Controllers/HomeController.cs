using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Webby.Core.Domain.Constants;
using Webby.Core.Interfaces.Repositories;
using Webby.Core.Interfaces.Services;
using Webby.Web.Models;
using Webby.Web.Models.ViewModels;

namespace Webby.Web.Controllers;

public class HomeController : BaseController
{
    private readonly IPostRepository _postRepository;

    public HomeController(IPostRepository postRepository, ISettingsService settingsService)
        : base(settingsService)
    {
        _postRepository = postRepository;
    }

    public async Task<IActionResult> Index(int page = 1)
    {
        var pageSizeStr = await SettingsService.GetAsync(SettingKeys.PostsPerPage, "5");
        var pageSize = int.TryParse(pageSizeStr, out var ps) ? ps : 5;

        var posts = await _postRepository.GetPublishedAsync(page, pageSize);
        var totalCount = await _postRepository.CountPublishedAsync();

        var vm = new PostListViewModel
        {
            Posts = posts.Select(PostSummaryViewModel.FromDomain).ToList(),
            CurrentPage = page,
            PageSize = pageSize,
            TotalCount = totalCount
        };

        return View(vm);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
        });
    }
}
