using CourseWork.BusinessLogic.Services;
using CourseWork.Core;
using CourseWork.Web.Models.Tags;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CourseWork.Web.Controllers
{
    [Authorize]
    public class TagsController : Controller
    {
        private readonly IService<Tag> _tagsService;

        public TagsController(IService<Tag> tagsService)
        {
            _tagsService = tagsService;
        }

        public async Task<IActionResult> Index()
        {
            var res = await _tagsService.SelectAsync();
            if (!res.Successfully)
                return BadRequest();
            return View(new TagsViewModel
            {
                Tags = res.Value.ToList(),
            });
        }
    }
}
