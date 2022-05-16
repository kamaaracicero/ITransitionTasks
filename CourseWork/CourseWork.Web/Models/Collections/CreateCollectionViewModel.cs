using CourseWork.Core;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace CourseWork.Web.Models.Collections
{
    public class CreateCollectionViewModel
    {
        public string Title { get; set; }

        public string Decription { get; set; }

        public int Theme { get; set; }

        public IEnumerable<CollectionTheme> PossibleThemes { get; set; }

        public string Image { get; set; }

        public IFormFile ImageFile { get; set; }

        public string Int1FieldName { get; set; }

        public string Int2FieldName { get; set; }

        public string Int3FieldName { get; set; }

        public string Date1FieldName { get; set; }

        public string Date2FieldName { get; set; }

        public string Date3FieldName { get; set; }

        public string Boolean1FieldName { get; set; }

        public string Boolean2FieldName { get; set; }

        public string Boolean3FieldName { get; set; }

        public string String1FieldName { get; set; }

        public string String2FieldName { get; set; }

        public string String3FieldName { get; set; }

        public string Text1FieldName { get; set; }

        public string Text2FieldName { get; set; }

        public string Text3FieldName { get; set; }

        public CollectionRequiredFields ConvertToRequired(int collectionId)
        {
            CollectionRequiredFields requiredFields = new CollectionRequiredFields();
            requiredFields.CollectionId = collectionId;

            if (!string.IsNullOrEmpty(Boolean1FieldName))
            {
                requiredFields.Boolean1FieldRequired = true;
                requiredFields.Boolean1FieldName = Boolean1FieldName;
            }
            if (!string.IsNullOrEmpty(Boolean2FieldName))
            {
                requiredFields.Boolean2FieldRequired = true;
                requiredFields.Boolean2FieldName = Boolean2FieldName;
            }
            if (!string.IsNullOrEmpty(Boolean3FieldName))
            {
                requiredFields.Boolean3FieldRequired = true;
                requiredFields.Boolean3FieldName = Boolean3FieldName;
            }

            if (!string.IsNullOrEmpty(Date1FieldName))
            {
                requiredFields.Date1FieldRequired = true;
                requiredFields.Date1FieldName = Date1FieldName;
            }
            if (!string.IsNullOrEmpty(Date2FieldName))
            {
                requiredFields.Date2FieldRequired = true;
                requiredFields.Date2FieldName = Date2FieldName;
            }
            if (!string.IsNullOrEmpty(Date3FieldName))
            {
                requiredFields.Date3FieldRequired = true;
                requiredFields.Date3FieldName = Date3FieldName;
            }

            if (!string.IsNullOrEmpty(Int1FieldName))
            {
                requiredFields.Int1FieldRequired = true;
                requiredFields.Int1FieldName = Int1FieldName;
            }
            if (!string.IsNullOrEmpty(Int2FieldName))
            {
                requiredFields.Int2FieldRequired = true;
                requiredFields.Int2FieldName = Int2FieldName;
            }
            if (!string.IsNullOrEmpty(Int3FieldName))
            {
                requiredFields.Int3FieldRequired = true;
                requiredFields.Int3FieldName = Int3FieldName;
            }

            if (!string.IsNullOrEmpty(String1FieldName))
            {
                requiredFields.String1FieldRequired = true;
                requiredFields.String1FieldName = String1FieldName;
            }
            if (!string.IsNullOrEmpty(String2FieldName))
            {
                requiredFields.String2FieldRequired = true;
                requiredFields.String2FieldName = String2FieldName;
            }
            if (!string.IsNullOrEmpty(String3FieldName))
            {
                requiredFields.String3FieldRequired = true;
                requiredFields.String3FieldName = String3FieldName;
            }

            if (!string.IsNullOrEmpty(Text1FieldName))
            {
                requiredFields.Text1FieldRequired = true;
                requiredFields.Text1FieldName = Text1FieldName;
            }
            if (!string.IsNullOrEmpty(Text2FieldName))
            {
                requiredFields.Text2FieldRequired = true;
                requiredFields.Text2FieldName = Text2FieldName;
            }
            if (!string.IsNullOrEmpty(Text3FieldName))
            {
                requiredFields.Text3FieldRequired = true;
                requiredFields.Text3FieldName = Text3FieldName;
            }

            return requiredFields;
        }
    }
}
