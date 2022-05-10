namespace CourseWork.Core
{
    public sealed class Tag : object, IDataEntity
    {
        public Tag(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public Tag()
            : this(0, string.Empty)
        {
        }

        public int Id { get; set; }

        public string Name { get; set; }

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
            ^ Name.GetHashCode();

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
