using CourseWork.BusinessLogic.Services;
using CourseWork.BusinessLogic.StaticServices;
using CourseWork.Core;
using CourseWork.Web.Models.Items;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseWork.Web.Controllers
{
    public class ItemsController : Controller
    {
        private readonly SearchItemService _searchService;
        private readonly UserActivityService _userActivityService;
        private readonly ItemFieldsService _itemFieldsService;
        private readonly IService<CollectionItem> _itemService;
        private readonly IService<CollectionRequiredFields> _requiredFieldsService;

        public ItemsController(SearchItemService searchService,
            UserActivityService userActivityService,
            ItemFieldsService itemFieldsService,
            IService<CollectionItem> itemService,
            IService<CollectionRequiredFields> requiredFieldsService)
        {
            _searchService = searchService;
            _userActivityService = userActivityService;
            _itemFieldsService = itemFieldsService;
            _itemService = itemService;
            _requiredFieldsService = requiredFieldsService;
        }

        public async Task<IActionResult> Index(int collectionId = 0, string searchString = null)
        {
            ItemsViewModel model = new ItemsViewModel();
            IEnumerable<CollectionItem> items = new List<CollectionItem>();
            if (collectionId != 0 && string.IsNullOrEmpty(searchString))
            {
                var serviceRes = await _itemService.SelectAsync();
                var fieldsRes = await _requiredFieldsService.SelectAsync();
                if (!serviceRes.Successfully || !fieldsRes.Successfully)
                {
                    return BadRequest();
                }
                items = serviceRes.Value.Where(i => i.CollectionId == collectionId);
                model.CollectionId = collectionId;
                model.Fields = fieldsRes.Value.First(f => f.CollectionId == collectionId).GetSpecifiedFields();
            }
            else if (collectionId == 0 && !string.IsNullOrEmpty(searchString))
            {
                var serviceRes = await _searchService.SearchItems(searchString);
                if (!serviceRes.Successfully)
                {
                    return BadRequest();
                }
                items = serviceRes.Value;
                model.Fields = new List<string>();
            }

            var likesRes = await _userActivityService.GetLikes();
            var commentsRes = await _userActivityService.GetComments();
            if (!likesRes.Successfully || !commentsRes.Successfully)
            {
                return BadRequest();
            }

            model.Items = items.Select(i => new ItemViewModel
            {
                Id = i.Id,
                Name = i.Name,
                Comments = commentsRes.Value.Count(c => c.CollectionItemId == i.Id),
                Likes = likesRes.Value.Count(l => l.CollectionItemId == i.Id),
            }).ToList();

            return View(model);
        }

        public IActionResult CantCreate()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create(int collectionId)
        {
            if (collectionId == 0)
            {
                return LocalRedirect("~/Collections/Index");
            }
            var fields = await _requiredFieldsService.SelectAsync();
            if (!fields.Successfully)
            {
                return RedirectToAction(nameof(Index), new { collectionId = collectionId });
            }

            return View(new CreateItemViewModel(collectionId, fields.Value.First(f => f.CollectionId == collectionId)));
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind] CreateItemViewModel viewModel)
        {
            var item = new CollectionItem(0, viewModel.CollectionId, viewModel.Name);
            var itemRes = await _itemService.InsertAsync(item);
            if (!itemRes.Successfully)
            {
                return BadRequest();
            }
            var fields = viewModel.GetFields(item.Id);
            var fieldsRes = await _itemFieldsService.AddFields(item.Id, fields);

            if (!fieldsRes.Successfully)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(Index), new { collectionId = viewModel.CollectionId });
        }

        public async Task<IActionResult> DeleteItem(int itemId, string returnUrl)
        {
            var items = await _itemService.SelectAsync();
            if (!items.Successfully)
                return BadRequest();

            var item = items.Value.FirstOrDefault(i => i.Id == itemId);
            if (item == default)
                return BadRequest();

            var res = await _itemService.DeleteAsync(item);
            return LocalRedirect(returnUrl);
        }
    }
}
