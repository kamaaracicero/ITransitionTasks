namespace CourseWork.Core
{
    public sealed class ImageSize : object, IDataEntity
    {
        public ImageSize(int id, int collectionId, int height, int width)
        {
            Id = id;
            CollectionId = collectionId;
            Height = height;
            Width = width;
        }

        public ImageSize()
            : this(0, 0, 0, 0)
        {
        }

        public int Id { get; set; }

        public int CollectionId { get; set; }

        public int Height { get; set; }

        public int Width { get; set; }

        public void Update(object update)
        {
            if (update == null || !(update is ImageSize))
            {
                return;
            }

            ImageSize temp = update as ImageSize;
            CollectionId = temp.CollectionId;
            Height = temp.Height;
            Width = temp.Width;
        }

        public override int GetHashCode() => Id
            ^ CollectionId
            ^ Height
            ^ Width;

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is ImageSize))
            {
                return false;
            }

            return obj.GetHashCode() == GetHashCode();
        }

        public override string ToString() => Height.ToString() + ":" + Width.ToString();
    }
}
