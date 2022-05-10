using CourseWork.BusinessLogic.Services.Results;
using CourseWork.Core;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CourseWork.BusinessLogic.Services
{
    public interface IService<TEntity>
        where TEntity : IDataEntity
    {
        Task<ServiceResult> InsertAsync(TEntity entity, CancellationToken cancellationToken);

        Task<ServiceResult> UpdateAsync(TEntity entity, CancellationToken cancellationToken);

        Task<ServiceResult> DeleteAsync(TEntity entity, CancellationToken cancellationToken);

        Task<ServiceResult<IEnumerable<TEntity>>> SelectAsync(CancellationToken cancellationToken);
    }
}
