namespace CourseWork.Core
{
    public sealed class CollectionTheme : object, IDataEntity
    {
        public CollectionTheme(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public CollectionTheme()
            : this(0, null)
        {
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public void Update(object update)
        {
            if (update == null || !(update is CollectionTheme))
            {
                return;
            }

            CollectionTheme temp = update as CollectionTheme;
            Name = temp.Name;
        }

        public override int GetHashCode() => Id ^ Name.GetHashCode();

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is CollectionTheme))
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
