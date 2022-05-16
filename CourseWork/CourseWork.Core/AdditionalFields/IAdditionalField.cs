namespace CourseWork.Core.AdditionalFields
{
    public interface IAdditionalField
    {
        string GetFieldName();

        object GetFieldValue();
    }
}
