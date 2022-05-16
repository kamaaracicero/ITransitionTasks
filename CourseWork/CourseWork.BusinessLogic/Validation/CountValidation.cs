using System.Collections.Generic;

namespace CourseWork.BusinessLogic.Validation
{
    internal class CountValidation : IValidation
    {
        public bool CheckCount<TEntity>(TEntity entity, IEnumerable<TEntity> entities, int min, int max)
        {
            int count = 0;
            foreach (var item in entities)
            {
                if (item.Equals(entity))
                {
                    count++;
                }
            }

            return count >= min && count <= max;
        }
    }
}
