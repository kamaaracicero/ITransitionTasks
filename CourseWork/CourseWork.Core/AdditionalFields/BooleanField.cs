namespace CourseWork.Core.AdditionalFields
{
    public sealed class BooleanField : object, IDataEntity, IAdditionalField
    {
        public BooleanField(int id, int collectionItemId, string name, bool value)
        {
            Id = id;
            CollectionItemId = collectionItemId;
            Name = name;
            Value = value;
        }

        public BooleanField()
            : this(0, 0, string.Empty, false)
        {
        }

        public int Id { get; set; }

        public int CollectionItemId { get; set; }

        public string Name { get; set; }

        public bool Value { get; set; }

        public void Update(object update)
        {
            if (update == null || !(update is BooleanField))
            {
                return;
            }

            BooleanField temp = update as BooleanField;
            CollectionItemId = temp.CollectionItemId;
            Name = temp.Name;
            Value = temp.Value;
        }

        public string GetFieldName() => Name;

        public object GetFieldValue() => Value;

        public override int GetHashCode() => Id
            ^ CollectionItemId
            ^ Name.GetHashCode()
            ^ Value.GetHashCode();

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is BooleanField))
            {
                return false;
            }

            return obj.GetHashCode() == GetHashCode();
        }

        public override string ToString() => Name + ": " + Value.ToString();
    }
}
