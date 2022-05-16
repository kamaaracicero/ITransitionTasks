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

        [HttpPost]
        public async Task<IActionResult> AddTag(string tagName)
        {
            var res = await _tagsService.InsertAsync(new Tag(0, tagName));
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> RemoveTag(int tagId)
        {
            var res = await _tagsService.SelectAsync();
            if (!res.Successfully)
                return BadRequest();

            var tag = res.Value.FirstOrDefault(t => t.Id == tagId);
            if (tag == null)
                return BadRequest();

            var deleteRes = await _tagsService.DeleteAsync(tag);
            return RedirectToAction(nameof(Index));
        }
    }
}
