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
        private readonly IService<Tag> _tagService;

        public ItemController(UserActivityService userActivityService,
            ItemFieldsService itemFieldsService,
            UserManager<WebUser> userManager,
            IService<CollectionItem> collectionItemService,
            IService<Tag> tagService)
        {
            _userActivityService = userActivityService;
            _itemFieldsService = itemFieldsService;
            _userManager = userManager;
            _collectionItemService = collectionItemService;
            _tagService = tagService;
        }

        public async Task<IActionResult> Index(int itemId)
        {
            var items = await _collectionItemService.SelectAsync();
            var likes = await _userActivityService.GetLikes();
            var comments = await _userActivityService.GetComments();
            var tags = await _tagService.SelectAsync();
            var fields = await _itemFieldsService.GetItemFields(itemId);
            if (!items.Successfully
                || !likes.Successfully
                || !comments.Successfully
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
            return View(new ItemViewModel
            {
                Id = itemId,
                Likes = likes.Value.Count(l => l.CollectionItemId == itemId),
                Name = items.Value.First(i => i.Id == itemId).Name,
                Comments = commentsView,
                Fields = fields.Value.ToList(),
                Tags = tags.Value.Where(t => t.CollectionItemId == itemId).ToList(),
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
            var res = await _tagService.InsertAsync(new Tag(0, tagName, itemId));

            return RedirectToAction(nameof(Index), new { itemId = itemId });
        }
    }
}
