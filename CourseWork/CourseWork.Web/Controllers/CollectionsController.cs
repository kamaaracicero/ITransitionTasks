﻿using CourseWork.BusinessLogic.Converters;
using CourseWork.BusinessLogic.Services;
using CourseWork.Core;
using CourseWork.Core.Identity;
using CourseWork.Web.Models.Collections;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseWork.Web.Controllers
{
    public class CollectionsController : Controller
    {
        private readonly IService<Collection> _collectionService;
        private readonly IService<CollectionTheme> _collectionThemeService;
        private readonly IService<CollectionRequiredFields> _collectionRequiredFields;
        private readonly IService<ImageSize> _imageSizeService;
        private readonly IConverter<IFormFile, string> _imageConvert;

        private readonly UserManager<WebUser> _userManager;

        public CollectionsController(IService<Collection> collectionService,
            IService<CollectionTheme> collectionThemeService,
            IService<CollectionRequiredFields> collectionRequiredFields,
            IService<ImageSize> imageSizeService,
            IConverter<IFormFile, string> imageConvert,
            UserManager<WebUser> userManager)
        {
            _collectionService = collectionService;
            _collectionThemeService = collectionThemeService;
            _collectionRequiredFields = collectionRequiredFields;
            _imageSizeService = imageSizeService;
            _imageConvert = imageConvert;

            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string userId = null)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return await SeeCommonCollections();
            }
            else
            {
                return await SeeUserCollections(userId);
            }
        }

        private async Task<IActionResult> SeeCommonCollections()
        {
            var collectionsRes = await _collectionService.SelectAsync();
            var themesRes = await _collectionThemeService.SelectAsync();
            var sizesRes = await _imageSizeService.SelectAsync();
            if (!collectionsRes.Successfully || !themesRes.Successfully || !sizesRes.Successfully)
            {
                return BadRequest();
            }

            List<CollectionViewModel> collectionViewModels = new List<CollectionViewModel>();
            foreach (var collection in collectionsRes.Value)
            {
                collectionViewModels.Add(new CollectionViewModel
                {
                    Id = collection.Id,
                    Title = collection.Title,
                    Author = (await _userManager.FindByIdAsync(collection.UserId)).UserName,
                    Description = collection.Description,
                    Theme = themesRes.Value.First(item => item.Id == collection.CollectionThemeId).Theme,
                    Image = "data:image/png;base64," + collection.Image,
                    ImageHeight = sizesRes.Value.First(item => item.CollectionId == collection.Id).Height,
                    ImageWidth = sizesRes.Value.First(item => item.CollectionId == collection.Id).Width,
                });
            }

            return View(new CollectionsViewModel { Collections = collectionViewModels });
        }

        private async Task<IActionResult> SeeUserCollections(string userId)
        {
            var collectionsRes = await _collectionService.SelectAsync();
            var themesRes = await _collectionThemeService.SelectAsync();
            var sizesRes = await _imageSizeService.SelectAsync();
            if (!collectionsRes.Successfully || !themesRes.Successfully || !sizesRes.Successfully)
            {
                return BadRequest();
            }

            List<CollectionViewModel> collectionViewModels = new List<CollectionViewModel>();
            foreach (var collection in collectionsRes.Value.Where(c => c.UserId == userId))
            {
                collectionViewModels.Add(new CollectionViewModel
                {
                    Id = collection.Id,
                    Title = collection.Title,
                    Author = (await _userManager.FindByIdAsync(collection.UserId)).UserName,
                    Description = collection.Description,
                    Theme = themesRes.Value.First(item => item.Id == collection.CollectionThemeId).Theme,
                    Image = "data:image/png;base64," + collection.Image,
                    ImageHeight = sizesRes.Value.First(item => item.CollectionId == collection.Id).Height,
                    ImageWidth = sizesRes.Value.First(item => item.CollectionId == collection.Id).Width,
                });
            }

            return View(new CollectionsViewModel { Collections = collectionViewModels });
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var themes = await _collectionThemeService.SelectAsync();
            if (!themes.Successfully)
            {
                return BadRequest();
            }
            else
            {
                return View(new CreateCollectionViewModel { PossibleThemes = themes.Value });
            }
        }

        public async Task<IActionResult> Create([Bind] CreateCollectionViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var collection = new Collection
                {
                    UserId = _userManager.GetUserId(User),
                    Description = viewModel.Decription,
                    Image = _imageConvert.Convert(viewModel.ImageFile),
                    Title = viewModel.Title,
                    CollectionThemeId = viewModel.Theme,
                };
                var collectionRes = await _collectionService.InsertAsync(collection);
                var imageRes = await _imageSizeService.InsertAsync(new ImageSize(0, collection.Id, 150, 150));
                var fieldsRes = await _collectionRequiredFields.InsertAsync(viewModel.ConvertToRequired(collection.Id));
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int collectionId)
        {
            var themes = await _collectionThemeService.SelectAsync();
            var collections = await _collectionService.SelectAsync();
            if (!themes.Successfully || !collections.Successfully)
            {
                return BadRequest();
            }

            var collection = collections.Value.FirstOrDefault(c => c.Id == collectionId);
            if (collection is null)
                return BadRequest();

            return View(new EditCollectionViewModel(collection, themes.Value));
        }

        [HttpPost]
        public async Task<IActionResult> Edit([Bind] EditCollectionViewModel viewModel)
        {
            Collection collection = new Collection
            {
                Id = viewModel.Id,
                UserId = viewModel.UserId,
                CollectionThemeId = viewModel.Theme,
                Description = viewModel.Decription,
                Title = viewModel.Title,
                Image = _imageConvert.Convert(viewModel.ImageFile),
            };

            var collections = await _collectionService.SelectAsync();
            if (!collections.Successfully)
            {
                return BadRequest();
            }

            var bdCollection = collections.Value.FirstOrDefault(c => c.Id == collection.Id);
            if (bdCollection is null)
            {
                return BadRequest();
            }
            bdCollection.Update(collection);
            var res = await _collectionService.UpdateAsync(bdCollection);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int collectionId)
        {
            var collections = await _collectionService.SelectAsync();
            if (!collections.Successfully)
                return BadRequest();

            var collection = collections.Value.FirstOrDefault(c => c.Id == collectionId);
            if (collection == default)
                return BadRequest();

            var res = await _collectionService.DeleteAsync(collection);
            return RedirectToAction(nameof(Index));
        }
    }
}
