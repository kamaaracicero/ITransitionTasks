namespace CourseWork.Core
{
    public sealed class CollectionTheme : object, IDataEntity
    {
        public CollectionTheme(int id, string theme)
        {
            Id = id;
            Theme = theme;
        }

        public CollectionTheme()
            : this(0, string.Empty)
        {
        }

        public int Id { get; set; }

        public string Theme { get; set; }

        public void Update(object update)
        {
            if (update == null || !(update is CollectionTheme))
            {
                return;
            }

            CollectionTheme temp = update as CollectionTheme;
            Theme = temp.Theme;
        }

        public override int GetHashCode() => Id
            ^ Theme.GetHashCode();

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is CollectionTheme))
            {
                return false;
            }

            return obj.GetHashCode() == GetHashCode();
        }

        public override string ToString() => Theme;
    }
}
