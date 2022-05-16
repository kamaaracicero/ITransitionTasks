namespace CourseWork.Core
{
    public sealed class CollectionRequiredFields : object, IDataEntity
    {
        public CollectionRequiredFields(int id, int collectionId)
        {
            Id = id;
            CollectionId = collectionId;

            Boolean1FieldRequired = false;
            Boolean1FieldName = string.Empty;
            Boolean2FieldRequired = false;
            Boolean2FieldName = string.Empty;
            Boolean3FieldRequired = false;
            Boolean3FieldName = string.Empty;

            Date1FieldRequired = false;
            Date1FieldName = string.Empty;
            Date2FieldRequired = false;
            Date2FieldName = string.Empty;
            Date3FieldRequired = false;
            Date3FieldName = string.Empty;

            Int1FieldRequired = false;
            Int1FieldName = string.Empty;
            Int2FieldRequired = false;
            Int2FieldName = string.Empty;
            Int3FieldRequired = false;
            Int3FieldName = string.Empty;

            String1FieldRequired = false;
            String1FieldName = string.Empty;
            String2FieldRequired = false;
            String2FieldName = string.Empty;
            String3FieldRequired = false;
            String3FieldName = string.Empty;

            Text1FieldRequired = false;
            Text1FieldName = string.Empty;
            Text2FieldRequired = false;
            Text2FieldName = string.Empty;
            Text3FieldRequired = false;
            Text3FieldName = string.Empty;
        }

        public CollectionRequiredFields()
            : this(0, 0)
        {
        }

        public int Id { get; set; }

        public int CollectionId { get; set; }

        public bool Boolean1FieldRequired { get; set; }

        public string Boolean1FieldName { get; set; }

        public bool Boolean2FieldRequired { get; set; }

        public string Boolean2FieldName { get; set; }

        public bool Boolean3FieldRequired { get; set; }

        public string Boolean3FieldName { get; set; }

        public bool Date1FieldRequired { get; set; }

        public string Date1FieldName { get; set; }

        public bool Date2FieldRequired { get; set; }

        public string Date2FieldName { get; set; }

        public bool Date3FieldRequired { get; set; }

        public string Date3FieldName { get; set; }

        public bool Int1FieldRequired { get; set; }

        public string Int1FieldName { get; set; }

        public bool Int2FieldRequired { get; set; }

        public string Int2FieldName { get; set; }

        public bool Int3FieldRequired { get; set; }

        public string Int3FieldName { get; set; }

        public bool String1FieldRequired { get; set; }

        public string String1FieldName { get; set; }

        public bool String2FieldRequired { get; set; }

        public string String2FieldName { get; set; }

        public bool String3FieldRequired { get; set; }

        public string String3FieldName { get; set; }

        public bool Text1FieldRequired { get; set; }

        public string Text1FieldName { get; set; }

        public bool Text2FieldRequired { get; set; }

        public string Text2FieldName { get; set; }

        public bool Text3FieldRequired { get; set; }

        public string Text3FieldName { get; set; }

        public System.Collections.Generic.List<string> GetSpecifiedFields()
        {
            System.Collections.Generic.List<string> fields = new System.Collections.Generic.List<string>();
            if (Boolean1FieldRequired)
                fields.Add(Boolean1FieldName);
            if (Boolean2FieldRequired)
                fields.Add(Boolean2FieldName);
            if (Boolean3FieldRequired)
                fields.Add(Boolean3FieldName);

            if (Date1FieldRequired)
                fields.Add(Date1FieldName);
            if (Date2FieldRequired)
                fields.Add(Date2FieldName);
            if (Date3FieldRequired)
                fields.Add(Date3FieldName);

            if (Int1FieldRequired)
                fields.Add(Int1FieldName);
            if (Int2FieldRequired)
                fields.Add(Int2FieldName);
            if (Int3FieldRequired)
                fields.Add(Int3FieldName);

            if (String1FieldRequired)
                fields.Add(String1FieldName);
            if (String2FieldRequired)
                fields.Add(String2FieldName);
            if (String3FieldRequired)
                fields.Add(String3FieldName);

            if (Text1FieldRequired)
                fields.Add(Text1FieldName);
            if (Text2FieldRequired)
                fields.Add(Text2FieldName);
            if (Text3FieldRequired)
                fields.Add(Text3FieldName);


            return fields;
        }

        public void Update(object update)
        {
            if (update == null || !(update is CollectionRequiredFields))
            {
                return;
            }

            CollectionRequiredFields temp = update as CollectionRequiredFields;
            CollectionId = temp.CollectionId;

            Boolean1FieldRequired = temp.Boolean1FieldRequired;
            Boolean1FieldName = temp.Boolean1FieldName;
            Boolean2FieldRequired = temp.Boolean2FieldRequired;
            Boolean2FieldName = temp.Boolean2FieldName;
            Boolean3FieldRequired = temp.Boolean3FieldRequired;
            Boolean3FieldName = temp.Boolean3FieldName;

            Date1FieldRequired = temp.Date1FieldRequired;
            Date1FieldName = temp.Date1FieldName;
            Date2FieldRequired = temp.Date2FieldRequired;
            Date2FieldName = temp.Date2FieldName;
            Date3FieldRequired = temp.Date3FieldRequired;
            Date3FieldName = temp.Date3FieldName;

            Int1FieldRequired = temp.Int1FieldRequired;
            Int1FieldName = temp.Int1FieldName;
            Int2FieldRequired = temp.Int2FieldRequired;
            Int2FieldName = temp.Int2FieldName;
            Int3FieldRequired = temp.Int3FieldRequired;
            Int3FieldName = temp.Int3FieldName;

            String1FieldRequired = temp.String1FieldRequired;
            String1FieldName = temp.String1FieldName;
            String2FieldRequired = temp.String2FieldRequired;
            String2FieldName = temp.String2FieldName;
            String3FieldRequired = temp.String3FieldRequired;
            String3FieldName = temp.String3FieldName;

            Text1FieldRequired = temp.Text1FieldRequired;
            Text1FieldName = temp.Text1FieldName;
            Text2FieldRequired = temp.Text2FieldRequired;
            Text2FieldName = temp.Text2FieldName;
            Text3FieldRequired = temp.Text3FieldRequired;
            Text3FieldName = temp.Text3FieldName;
        }

        public override int GetHashCode() => Id
            ^ CollectionId
            ^ Boolean1FieldRequired.GetHashCode()
            ^ Boolean1FieldName.GetHashCode()
            ^ Boolean2FieldRequired.GetHashCode()
            ^ Boolean2FieldName.GetHashCode()
            ^ Boolean3FieldRequired.GetHashCode()
            ^ Boolean3FieldName.GetHashCode()
            ^ Date1FieldRequired.GetHashCode()
            ^ Date1FieldName.GetHashCode()
            ^ Date2FieldRequired.GetHashCode()
            ^ Date2FieldName.GetHashCode()
            ^ Date3FieldRequired.GetHashCode()
            ^ Date3FieldName.GetHashCode()
            ^ Int1FieldRequired.GetHashCode()
            ^ Int1FieldName.GetHashCode()
            ^ Int2FieldRequired.GetHashCode()
            ^ Int2FieldName.GetHashCode()
            ^ Int3FieldRequired.GetHashCode()
            ^ Int3FieldName.GetHashCode()
            ^ String1FieldRequired.GetHashCode()
            ^ String1FieldName.GetHashCode()
            ^ String2FieldRequired.GetHashCode()
            ^ String2FieldName.GetHashCode()
            ^ String3FieldRequired.GetHashCode()
            ^ String3FieldName.GetHashCode()
            ^ Text1FieldRequired.GetHashCode()
            ^ Text1FieldName.GetHashCode()
            ^ Text2FieldRequired.GetHashCode()
            ^ Text2FieldName.GetHashCode()
            ^ Text3FieldRequired.GetHashCode()
            ^ Text3FieldName.GetHashCode();

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is CollectionRequiredFields))
            {
                return false;
            }

            return obj.GetHashCode() == GetHashCode();
        }

        public override string ToString() => CollectionId.ToString();
    }
}
