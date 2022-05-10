namespace CourseWork.Core
{
    public sealed class CollectionItemTag : object, IDataEntity
    {
        public CollectionItemTag(int id, int collectionItemId, int tagId)
        {
            Id = id;
            CollectionItemId = collectionItemId;
            TagId = tagId;
        }

        public CollectionItemTag()
            : this(0, 0, 0)
        {
        }

        public int Id { get; set; }

        public int CollectionItemId { get; set; }

        public int TagId { get; set; }

        public void Update(object update)
        {
            if (update == null || !(update is CollectionItemTag))
            {
                return;
            }

            CollectionItemTag temp = update as CollectionItemTag;
            CollectionItemId = temp.CollectionItemId;
            TagId = temp.TagId;
        }

        public override int GetHashCode() => Id
            ^ CollectionItemId
            ^ TagId;

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is CollectionItemTag))
            {
                return false;
            }

            return obj.GetHashCode() == GetHashCode();
        }

        public override string ToString() => Id.ToString();
    }
}
