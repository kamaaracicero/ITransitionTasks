using CourseWork.Core;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace CourseWork.Web.Models.Collections
{
    public class EditCollectionViewModel
    {
        public EditCollectionViewModel()
        {
            Id = 0;
            Title = string.Empty;
            Decription = string.Empty;
            Theme = 0;
            PossibleThemes = new List<CollectionTheme>();
            Image = string.Empty;
            ImageFile = null;
        }

        public EditCollectionViewModel(Collection collection, IEnumerable<CollectionTheme> possibleThemes)
        {
            Id = collection.Id;
            UserId = collection.UserId;
            Title = collection.Title;
            Decription = collection.Description;
            Theme = collection.CollectionThemeId;
            PossibleThemes = possibleThemes;
            Image = collection.Image;
        }

        public int Id { get; set; }

        public string UserId { get; set; }

        public string Title { get; set; }

        public string Decription { get; set; }

        public int Theme { get; set; }

        public IEnumerable<CollectionTheme> PossibleThemes { get; set; }

        public string Image { get; set; }

        public IFormFile ImageFile { get; set; }
    }
}
