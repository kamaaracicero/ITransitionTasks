using CourseWork.Core;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CourseWork.BusinessLogic.Services
{
    public interface IService<TEntity>
        where TEntity : IDataEntity
    {
        Task InsertAsync(TEntity entity, CancellationToken cancellationToken);

        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken);

        Task DeleteAsync(TEntity entity, CancellationToken cancellationToken);

        Task<IEnumerable<TEntity>> SelectAsync(CancellationToken cancellationToken);
    }
}
