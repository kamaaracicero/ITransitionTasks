using System.Collections.Generic;

namespace CourseWork.BusinessLogic.Services.Results
{
    public class ServiceResult
    {
        public ServiceResult(bool successfully = true)
        {
            Successfully = successfully;
            Errors = new List<ServiceError>();
        }

        public bool Successfully { get; set; }

        public List<ServiceError> Errors { get; set; }
    }

    public class ServiceResult<TValue>
        : ServiceResult
    {
        public ServiceResult(TValue value = default, bool successfully = true)
            : base(successfully)
        {
            Value = value;
        }

        public TValue Value { get; set; }
    }
}
