namespace CourseWork.Core
{
    public sealed class Collection : object, IDataEntity
    {
        public Collection(int id, string title, string description, int collectionThemeId, string image)
        {
            Id = id;
            Title = title;
            Description = description;
            CollectionThemeId = collectionThemeId;
            Image = image;
        }

        public Collection()
            : this(0, null, null, 0, null)
        {
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int CollectionThemeId { get; set; }

        public string Image { get; set; }

        public void Update(object update)
        {
            if (update == null || !(update is Collection))
            {
                return;
            }

            Collection temp = update as Collection;
            Title = temp.Title;
            Description = temp.Description;
            CollectionThemeId = temp.CollectionThemeId;
            Image = temp.Image;
        }

        public override int GetHashCode() => Id
            ^ Title.GetHashCode()
            ^ Description.GetHashCode()
            ^ CollectionThemeId
            ^ Image.GetHashCode();

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Collection))
            {
                return false;
            }

            if (obj.GetHashCode() == this.GetHashCode())
            {
                return true;
            }

            return false;
        }

        public override string ToString() => Title;
    }
}
