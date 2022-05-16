using CourseWork.Core;
using System.Collections.Generic;

namespace CourseWork.Web.Models.Collections
{
    public class CollectionsViewModel
    {
        public CollectionsViewModel()
        {
            Collections = new List<CollectionViewModel>();
        }

        public IEnumerable<CollectionViewModel> Collections { get; set; }
    }
}
