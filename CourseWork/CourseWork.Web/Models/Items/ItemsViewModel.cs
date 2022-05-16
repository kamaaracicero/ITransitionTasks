using System.Collections.Generic;

namespace CourseWork.Web.Models.Items
{
    public class ItemsViewModel
    {
        public ItemsViewModel()
        {
            CollectionId = 0;
            Items = new List<ItemViewModel>();
            Fields = new List<string>();
        }

        public int CollectionId { get; set; }

        public List<ItemViewModel> Items { get; set; }

        public List<string> Fields { get; set; }
    }
}
