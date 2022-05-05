namespace CourseWork.Core.AdditionalFields
{
    public sealed class DateField : object, IDataEntity
    {
        public DateField(int id, int collectionItemId, string name, System.DateTime value)
        {
            Id = id;
            CollectionItemId = collectionItemId;
            Name = name;
            Value = value;
        }

        public DateField()
            : this(0, 0, null, System.DateTime.Now)
        {
        }

        public int Id { get; set; }

        public int CollectionItemId { get; set; }

        public string Name { get; set; }

        public System.DateTime Value { get; set; }

        public void Update(object update)
        {
            if (update == null || !(update is DateField))
            {
                return;
            }

            DateField temp = update as DateField;
            CollectionItemId = temp.CollectionItemId;
            Name = temp.Name;
            Value = temp.Value;
        }

        public override int GetHashCode() => Id ^ CollectionItemId ^ Name.GetHashCode() ^ Value.GetHashCode();

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is DateField))
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
