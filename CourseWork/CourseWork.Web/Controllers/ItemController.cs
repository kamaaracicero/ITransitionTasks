using CourseWork.BusinessLogic.Services;
using CourseWork.BusinessLogic.StaticServices;
using CourseWork.Core;
using CourseWork.Core.Identity;
using CourseWork.Web.Models.Item;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseWork.Web.Controllers
{
    public class ItemController : Controller
    {
        private readonly UserActivityService _userActivityService;
        private readonly ItemFieldsService _itemFieldsService;
        private readonly UserManager<WebUser> _userManager;
        private readonly IService<CollectionItem> _collectionItemService;
        private readonly IService<CollectionItemTag> _collectionItemTagService;
        private readonly IService<Tag> _tagService;

        public ItemController(UserActivityService userActivityService,
            ItemFieldsService itemFieldsService,
            UserManager<WebUser> userManager,
            IService<CollectionItem> collectionItemService,
            IService<CollectionItemTag> collectionItemTagService,
            IService<Tag> tagService)
        {
            _userActivityService = userActivityService;
            _itemFieldsService = itemFieldsService;
            _userManager = userManager;
            _collectionItemService = collectionItemService;
            _collectionItemTagService = collectionItemTagService;
            _tagService = tagService;
        }

        public async Task<IActionResult> Index(int itemId)
        {
            var items = await _collectionItemService.SelectAsync();
            var likes = await _userActivityService.GetLikes();
            var comments = await _userActivityService.GetComments();
            var itemTags = await _collectionItemTagService.SelectAsync();
            var tags = await _tagService.SelectAsync();
            var fields = await _itemFieldsService.GetItemFields(itemId);
            if (!items.Successfully
                || !likes.Successfully
                || !comments.Successfully
                || !itemTags.Successfully
                || !tags.Successfully
                || !fields.Successfully)
            {
                return BadRequest();
            }

            List<UserCommentViewModel> commentsView = new List<UserCommentViewModel>();
            foreach (var comment in comments.Value.Where(c => c.CollectionItemId == itemId))
            {
                var user = await _userManager.FindByIdAsync(comment.UserId);
                commentsView.Add(new UserCommentViewModel(user, comment));
            }
            List<Tag> tagsView = new List<Tag>();
            foreach (var itemTag in itemTags.Value.Where(i => i.CollectionItemId == itemId))
            {
                tagsView.Add(tags.Value.First(t => t.Id == itemTag.TagId));
            }
            return View(new ItemViewModel
            {
                Id = itemId,
                Likes = likes.Value.Count(l => l.CollectionItemId == itemId),
                Name = items.Value.First(i => i.Id == itemId).Name,
                Comments = commentsView,
                Fields = fields.Value.ToList(),
                Tags = tagsView,
            });
        }

        [Authorize]
        public async Task<IActionResult> Like(int itemId)
        {
            WebUser user = await _userManager.GetUserAsync(User);
            var res = await _userActivityService.AddLike(user, itemId);
            if (!res.Successfully)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(Index), new { itemId = itemId });
        }

        [Authorize]
        public async Task<IActionResult> Comment(int itemId, string commentText)
        {
            WebUser user = await _userManager.GetUserAsync(User);
            var res = await _userActivityService.AddComment(user, itemId, commentText);
            if (!res.Successfully)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(Index), new { itemId = itemId });
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddTag(int itemId, string tagName)
        {
            var tags = await _tagService.SelectAsync();
            if (!tags.Successfully)
            {
                return BadRequest();
            }

            var tag = tags.Value.FirstOrDefault(t => t.Name == tagName);
            if (tag != default)
            {
                var res = await _collectionItemTagService.InsertAsync(new CollectionItemTag(0, itemId, tag.Id));
            }
            return RedirectToAction(nameof(Index), new { itemId = itemId });
        }
    }
}
