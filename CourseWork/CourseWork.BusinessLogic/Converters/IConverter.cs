namespace CourseWork.BusinessLogic.Converters
{
    public interface IConverter<TFrom, TTo>
    {
        TTo Convert(TFrom data);

        System.Threading.Tasks.Task<TTo> ConvertAsync(TFrom data);
    }
}
