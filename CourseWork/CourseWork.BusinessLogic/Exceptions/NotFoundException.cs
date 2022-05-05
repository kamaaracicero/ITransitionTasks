using System;
using System.Runtime.Serialization;

namespace CourseWork.BusinessLogic.Exceptions
{
    [Serializable]
    public class NotFoundException : Exception
    {
        public NotFoundException(string searchType, int searchIndex)
        {
            SearchType = searchType;
            SearchIndex = searchIndex;
        }

        protected NotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public string SearchType { get; set; }

        public int SearchIndex { get; set; }
    }
}
