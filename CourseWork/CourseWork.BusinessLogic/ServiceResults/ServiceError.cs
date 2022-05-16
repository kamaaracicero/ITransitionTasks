namespace CourseWork.BusinessLogic.ServiceResults
{
    public class ServiceError
    {
        public ServiceError(string message, string description = null)
        {
            Message = message;
            Description = description;
        }

        public string Message { get; set; }

        public string Description { get; set; }
    }
}
