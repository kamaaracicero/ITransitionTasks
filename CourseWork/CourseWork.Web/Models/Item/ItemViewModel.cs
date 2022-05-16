using CourseWork.Core;
using CourseWork.Core.AdditionalFields;
using CourseWork.Core.UsersActivity;
using System.Collections.Generic;

namespace CourseWork.Web.Models.Item
{
    public class ItemViewModel
    {
        public ItemViewModel()
        {
            Id = 0;
            Name = string.Empty;
            Fields = new List<IAdditionalField>();
            Tags = new List<Tag>();
            Likes = 0;
            Comments = new List<UserCommentViewModel>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public List<IAdditionalField> Fields { get; set; }

        public List<Tag> Tags { get; set; }

        public int Likes { get; set; }

        public List<UserCommentViewModel> Comments { get; set; }
    }
}
