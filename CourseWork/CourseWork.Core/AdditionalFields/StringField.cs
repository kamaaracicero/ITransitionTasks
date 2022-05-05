namespace CourseWork.Core.AdditionalFields
{
    public sealed class StringField : object, IDataEntity
    {
        public StringField(int id, int collectionItemId, string name, string value)
        {
            Id = id;
            CollectionItemId = collectionItemId;
            Name = name;
            Value = value;
        }

        public StringField()
            : this(0, 0, null, null)
        {
        }

        public int Id { get; set; }

        public int CollectionItemId { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }

        public void Update(object update)
        {
            if (update == null || !(update is StringField))
            {
                return;
            }

            StringField temp = update as StringField;
            CollectionItemId = temp.CollectionItemId;
            Name = temp.Name;
            Value = temp.Value;
        }

        public override int GetHashCode() => Id ^ CollectionItemId ^ Name.GetHashCode() ^ Value.GetHashCode();

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is StringField))
            {
                return false;
            }

            if (obj.GetHashCode() == this.GetHashCode())
            {
                return true;
            }

            return false;
        }

        public override string ToString() => Name + ": " + Value.ToString();
    }
}
