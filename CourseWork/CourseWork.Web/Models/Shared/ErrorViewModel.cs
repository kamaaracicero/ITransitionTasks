namespace CourseWork.Web.Models.Shared
{
    public class ErrorViewModel
    {
        public ErrorViewModel()
        {
            RequestId = string.Empty;
        }

        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
