namespace CourseWork.Core.AdditionalFields
{
    public sealed class TextField : object, IDataEntity
    {
        public TextField(int id, int collectionItemId, string name, string value)
        {
            Id = id;
            CollectionItemId = collectionItemId;
            Name = name;
            Value = value;
        }

        public TextField()
            : this(0, 0, string.Empty, string.Empty)
        {
        }

        public int Id { get; set; }

        public int CollectionItemId { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }

        public void Update(object update)
        {
            if (update == null || !(update is TextField))
            {
                return;
            }

            TextField temp = update as TextField;
            CollectionItemId = temp.CollectionItemId;
            Name = temp.Name;
            Value = temp.Value;
        }

        public override int GetHashCode() => Id
            ^ CollectionItemId
            ^ Name.GetHashCode()
            ^ Value.GetHashCode();

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is TextField))
            {
                return false;
            }

            return obj.GetHashCode() == GetHashCode();
        }

        public override string ToString() => Name + ": " + Value.ToString();
    }
}
