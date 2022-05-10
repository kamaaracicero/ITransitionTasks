namespace CourseWork.Core.AdditionalFields
{
    public sealed class IntField : object, IDataEntity
    {
        public IntField(int id, int collectionItemId, string name, int value)
        {
            Id = id;
            CollectionItemId = collectionItemId;
            Name = name;
            Value = value;
        }

        public IntField()
            : this(0, 0, string.Empty, 0)
        {
        }

        public int Id { get; set; }

        public int CollectionItemId { get; set; }

        public string Name { get; set; }

        public int Value { get; set; }

        public void Update(object update)
        {
            if (update == null || !(update is IntField))
            {
                return;
            }

            IntField temp = update as IntField;
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
            if (obj == null || !(obj is IntField))
            {
                return false;
            }

            return obj.GetHashCode() == GetHashCode();
        }

        public override string ToString() => Name + ": " + Value.ToString();
    }
}
