namespace CourseWork.Core
{
    public sealed class CollectionItemTag : object, IDataEntity
    {
        public CollectionItemTag(int id, int collectionItemId, string name)
        {
            Id = id;
            CollectionItemId = collectionItemId;
            Name = name;
        }

        public CollectionItemTag()
            : this(0, 0, null)
        {
        }

        public int Id { get; set; }

        public int CollectionItemId { get; set; }

        public string Name { get; set; }

        public void Update(object update)
        {
            if (update == null || !(update is CollectionItemTag))
            {
                return;
            }

            CollectionItemTag temp = update as CollectionItemTag;
            CollectionItemId = temp.CollectionItemId;
            Name = temp.Name;
        }

        public override int GetHashCode() => Id ^ CollectionItemId ^ Name.GetHashCode();

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is CollectionItemTag))
            {
                return false;
            }

            if (obj.GetHashCode() == this.GetHashCode())
            {
                return true;
            }

            return false;
        }

        public override string ToString() => Name;
    }
}
