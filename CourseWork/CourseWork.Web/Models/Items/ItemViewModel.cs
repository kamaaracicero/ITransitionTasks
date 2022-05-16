using CourseWork.Core.AdditionalFields;
using System.Collections.Generic;

namespace CourseWork.Web.Models.Items
{
    public class ItemViewModel
    {
        public ItemViewModel()
        {
            Id = 0;
            Name = string.Empty;
            Likes = 0;
            Comments = 0;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int Likes { get; set; }

        public int Comments { get; set; }
    }
}
