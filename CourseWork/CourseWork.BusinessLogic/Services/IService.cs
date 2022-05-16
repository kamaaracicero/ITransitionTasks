using CourseWork.BusinessLogic.ServiceResults;
using CourseWork.Core;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CourseWork.BusinessLogic.Services
{
    public interface IService<TEntity>
        where TEntity : IDataEntity
    {
        Task<ServiceResult> InsertAsync(TEntity entity, CancellationToken cancellationToken = default);

        Task<ServiceResult> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);

        Task<ServiceResult> DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);

        Task<ServiceResult<IEnumerable<TEntity>>> SelectAsync(CancellationToken cancellationToken = default);
    }
}
