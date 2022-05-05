namespace CourseWork.Core
{
    public interface IDataEntity
    {
        int Id { get; set; }

        void Update(object update);
    }
}
