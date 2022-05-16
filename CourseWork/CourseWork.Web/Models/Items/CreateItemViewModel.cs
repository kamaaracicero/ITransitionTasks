using CourseWork.Core;
using CourseWork.Core.AdditionalFields;
using System;
using System.Collections.Generic;

namespace CourseWork.Web.Models.Items
{
    public class CreateItemViewModel
    {
        public CreateItemViewModel()
        {
            CollectionId = 0;
            Name = string.Empty;
        }

        public CreateItemViewModel(int collectionId)
        {
            CollectionId = collectionId;
            Name = string.Empty;
        }

        public CreateItemViewModel(int collectionId, CollectionRequiredFields requiredFields)
            : this(collectionId)
        {
            SetRequiredFields(requiredFields);
        }

        public int CollectionId { get; set; }

        public string Name { get; set; }

        public bool Boolean1FieldRequired { get; set; }
        public string Boolean1FieldName { get; set; }
        public bool Boolean1FieldValue { get; set; }

        public bool Boolean2FieldRequired { get; set; }
        public string Boolean2FieldName { get; set; }
        public bool Boolean2FieldValue { get; set; }

        public bool Boolean3FieldRequired { get; set; }
        public string Boolean3FieldName { get; set; }
        public bool Boolean3FieldValue { get; set; }

        public bool Date1FieldRequired { get; set; }
        public string Date1FieldName { get; set; }
        public DateTime Date1FieldValue { get; set; }

        public bool Date2FieldRequired { get; set; }
        public string Date2FieldName { get; set; }
        public DateTime Date2FieldValue { get; set; }

        public bool Date3FieldRequired { get; set; }
        public string Date3FieldName { get; set; }
        public DateTime Date3FieldValue { get; set; }

        public bool Int1FieldRequired { get; set; }
        public string Int1FieldName { get; set; }
        public int Int1FieldValue { get; set; }

        public bool Int2FieldRequired { get; set; }
        public string Int2FieldName { get; set; }
        public int Int2FieldValue { get; set; }

        public bool Int3FieldRequired { get; set; }
        public string Int3FieldName { get; set; }
        public int Int3FieldValue { get; set; }

        public bool String1FieldRequired { get; set; }
        public string String1FieldName { get; set; }
        public string String1FieldValue { get; set; }

        public bool String2FieldRequired { get; set; }
        public string String2FieldName { get; set; }
        public string String2FieldValue { get; set; }

        public bool String3FieldRequired { get; set; }
        public string String3FieldName { get; set; }
        public string String3FieldValue { get; set; }

        public bool Text1FieldRequired { get; set; }
        public string Text1FieldName { get; set; }
        public string Text1FieldValue { get; set; }

        public bool Text2FieldRequired { get; set; }
        public string Text2FieldName { get; set; }
        public string Text2FieldValue { get; set; }

        public bool Text3FieldRequired { get; set; }
        public string Text3FieldName { get; set; }
        public string Text3FieldValue { get; set; }

        public IEnumerable<IAdditionalField> GetFields(int itemId)
        {
            List<IAdditionalField> fields = new List<IAdditionalField>();

            if (Boolean1FieldRequired)
                fields.Add(new BooleanField(0, itemId, Boolean1FieldName, Boolean1FieldValue));
            if (Boolean2FieldRequired)
                fields.Add(new BooleanField(0, itemId, Boolean2FieldName, Boolean2FieldValue));
            if (Boolean3FieldRequired)
                fields.Add(new BooleanField(0, itemId, Boolean3FieldName, Boolean3FieldValue));

            if (Date1FieldRequired)
                fields.Add(new DateField(0, itemId, Date1FieldName, Date1FieldValue));
            if (Date2FieldRequired)
                fields.Add(new DateField(0, itemId, Date2FieldName, Date2FieldValue));
            if (Date3FieldRequired)
                fields.Add(new DateField(0, itemId, Date3FieldName, Date3FieldValue));

            if (Int1FieldRequired)
                fields.Add(new IntField(0, itemId, Int1FieldName, Int1FieldValue));
            if (Int2FieldRequired)
                fields.Add(new IntField(0, itemId, Int2FieldName, Int2FieldValue));
            if (Int3FieldRequired)
                fields.Add(new IntField(0, itemId, Int3FieldName, Int3FieldValue));

            if (String1FieldRequired)
                fields.Add(new StringField(0, itemId, String1FieldName, String1FieldValue));
            if (String2FieldRequired)
                fields.Add(new StringField(0, itemId, String2FieldName, String2FieldValue));
            if (String3FieldRequired)
                fields.Add(new StringField(0, itemId, String3FieldName, String3FieldValue));

            if (Text1FieldRequired)
                fields.Add(new TextField(0, itemId, Text1FieldName, Text1FieldValue));
            if (Text2FieldRequired)
                fields.Add(new TextField(0, itemId, Text2FieldName, Text2FieldValue));
            if (Text3FieldRequired)
                fields.Add(new TextField(0, itemId, Text3FieldName, Text3FieldValue));

            return fields;
        }

        public void SetRequiredFields(CollectionRequiredFields requiredFields)
        {
            if (requiredFields.Boolean1FieldRequired)
            {
                Boolean1FieldRequired = requiredFields.Boolean1FieldRequired;
                Boolean1FieldName = requiredFields.Boolean1FieldName;
                Boolean1FieldValue = false;
            }
            if (requiredFields.Boolean2FieldRequired)
            {
                Boolean2FieldRequired = requiredFields.Boolean2FieldRequired;
                Boolean2FieldName = requiredFields.Boolean2FieldName;
                Boolean2FieldValue = false;
            }
            if (requiredFields.Boolean3FieldRequired)
            {
                Boolean3FieldRequired = requiredFields.Boolean3FieldRequired;
                Boolean3FieldName = requiredFields.Boolean3FieldName;
                Boolean3FieldValue = false;
            }

            if (requiredFields.Date1FieldRequired)
            {
                Date1FieldRequired = requiredFields.Date1FieldRequired;
                Date1FieldName = requiredFields.Date1FieldName;
                Date1FieldValue = new DateTime(1980, 1, 1);
            }
            if (requiredFields.Date2FieldRequired)
            {
                Date2FieldRequired = requiredFields.Date2FieldRequired;
                Date2FieldName = requiredFields.Date2FieldName;
                Date2FieldValue = new DateTime(1980, 1, 1);
            }
            if (requiredFields.Date3FieldRequired)
            {
                Date3FieldRequired = requiredFields.Date3FieldRequired;
                Date3FieldName = requiredFields.Date3FieldName;
                Date3FieldValue = new DateTime(1980, 1, 1);
            }

            if (requiredFields.Int1FieldRequired)
            {
                Int1FieldRequired = requiredFields.Int1FieldRequired;
                Int1FieldName = requiredFields.Int1FieldName;
                Int1FieldValue = 0;
            }
            if (requiredFields.Int2FieldRequired)
            {
                Int2FieldRequired = requiredFields.Int2FieldRequired;
                Int2FieldName = requiredFields.Int2FieldName;
                Int2FieldValue = 0;
            }
            if (requiredFields.Int3FieldRequired)
            {
                Int3FieldRequired = requiredFields.Int3FieldRequired;
                Int3FieldName = requiredFields.Int3FieldName;
                Int3FieldValue = 0;
            }

            if (requiredFields.String1FieldRequired)
            {
                String1FieldRequired = requiredFields.String1FieldRequired;
                String1FieldName = requiredFields.String1FieldName;
                String1FieldValue = string.Empty;
            }
            if (requiredFields.String2FieldRequired)
            {
                String2FieldRequired = requiredFields.String2FieldRequired;
                String2FieldName = requiredFields.String2FieldName;
                String2FieldValue = string.Empty;
            }
            if (requiredFields.String3FieldRequired)
            {
                String3FieldRequired = requiredFields.String3FieldRequired;
                String3FieldName = requiredFields.String3FieldName;
                String3FieldValue = string.Empty;
            }

            if (requiredFields.Text1FieldRequired)
            {
                Text1FieldRequired = requiredFields.Text1FieldRequired;
                Text1FieldName = requiredFields.Text1FieldName;
                Text1FieldValue = string.Empty;
            }
            if (requiredFields.Text2FieldRequired)
            {
                Text2FieldRequired = requiredFields.Text2FieldRequired;
                Text2FieldName = requiredFields.Text2FieldName;
                Text2FieldValue = string.Empty;
            }
            if (requiredFields.Text3FieldRequired)
            {
                Text3FieldRequired = requiredFields.Text3FieldRequired;
                Text3FieldName = requiredFields.Text3FieldName;
                Text3FieldValue = string.Empty;
            }
        }
    }
}
