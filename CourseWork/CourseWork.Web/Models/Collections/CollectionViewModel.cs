namespace CourseWork.Web.Models.Collections
{
    public class CollectionViewModel
    {
        public CollectionViewModel()
        {
            Id = 0;
            Author = string.Empty;
            Title = string.Empty;
            Description = string.Empty;
            Theme = string.Empty;
            Image = string.Empty;
            ImageHeight = 0;
            ImageWidth = 0;
        }

        public int Id { get; set; }

        public string Author { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Theme { get; set; }

        public string Image { get; set; }

        public int ImageHeight { get; set; }

        public int ImageWidth { get; set; }
    }
}
