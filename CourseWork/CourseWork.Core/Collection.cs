﻿namespace CourseWork.Core
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
            : this(0, string.Empty, string.Empty, 0, string.Empty)
        {
        }

        public int Id { get; set; }

        public string UserId { get; set; }

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
            UserId = temp.UserId;
            Title = temp.Title;
            Description = temp.Description;
            CollectionThemeId = temp.CollectionThemeId;
            Image = temp.Image;
        }

        public override int GetHashCode() => Id
            ^ UserId.GetHashCode()
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

            return obj.GetHashCode() == GetHashCode();
        }

        public override string ToString() => Title;
    }
}
