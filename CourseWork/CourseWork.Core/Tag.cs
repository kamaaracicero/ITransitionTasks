namespace CourseWork.Core
{
    public sealed class Tag : object, IDataEntity
    {
        public Tag(int id, string name, int collectionItemId)
        {
            Id = id;
            Name = name;
            CollectionItemId = collectionItemId;
        }

        public Tag()
            : this(0, string.Empty, 0)
        {
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int CollectionItemId { get; set; }

        public void Update(object update)
        {
            if (update == null || !(update is Tag))
            {
                return;
            }

            Tag temp = update as Tag;
            Name = temp.Name;
        }

        public override int GetHashCode() => Id
            ^ Name.GetHashCode()
            ^ CollectionItemId;

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Tag))
            {
                return false;
            }

            return obj.GetHashCode() == GetHashCode();
        }

        public override string ToString() => Name;
    }
}
