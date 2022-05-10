namespace CourseWork.Core
{
    public sealed class CollectionItem : object, IDataEntity
    {
        public CollectionItem(int id, int collectionId, string name)
        {
            Id = id;
            CollectionId = collectionId;
            Name = name;
        }

        public CollectionItem()
            : this(0, 0, string.Empty)
        {
        }

        public int Id { get; set; }

        public int CollectionId { get; set; }

        public string Name { get; set; }

        public void Update(object update)
        {
            if (update == null || !(update is CollectionItem))
            {
                return;
            }

            CollectionItem temp = update as CollectionItem;
            CollectionId = temp.CollectionId;
            Name = temp.Name;
        }

        public override int GetHashCode() => Id
            ^ CollectionId
            ^ Name.GetHashCode();

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is CollectionItem))
            {
                return false;
            }

            return obj.GetHashCode() == GetHashCode();
        }

        public override string ToString() => Name;
    }
}
