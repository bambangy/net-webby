using Microsoft.AspNetCore.Mvc;
using Webby.Core.Interfaces.Repositories;
using Webby.Core.Interfaces.Services;
using Webby.Web.Models.ViewModels;

namespace Webby.Web.Controllers;

public class PostController : BaseController
{
    private readonly IPostRepository _postRepository;

    public PostController(IPostRepository postRepository, ISettingsService settingsService)
        : base(settingsService)
    {
        _postRepository = postRepository;
    }

    [Route("post/{slug}")]
    public async Task<IActionResult> Detail(string slug)
    {
        var post = await _postRepository.GetBySlugAsync(slug);
        if (post is null) return NotFound();

        var vm = PostDetailViewModel.FromDomain(post);
        return View(vm);
    }
}
