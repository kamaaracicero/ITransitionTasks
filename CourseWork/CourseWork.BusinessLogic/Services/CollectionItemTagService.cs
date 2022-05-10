using CourseWork.BusinessLogic.Exceptions;
using CourseWork.BusinessLogic.Services.Results;
using CourseWork.Core;
using CourseWork.DataAccess.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CourseWork.BusinessLogic.Services
{
    internal class CollectionItemTagService : IService<CollectionItemTag>
    {
        private readonly MainDbContext _dbContext;

        public CollectionItemTagService(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ServiceResult> DeleteAsync(CollectionItemTag entity,
            CancellationToken cancellationToken = default)
        {
            ServiceResult res = new ServiceResult();
            try
            {
                _dbContext.CollectionItemTags.Remove(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                res.Successfully = false;
                res.Errors.Add(new ServiceError(ex.Message));
            }

            return res;
        }

        public async Task<ServiceResult> InsertAsync(CollectionItemTag entity,
            CancellationToken cancellationToken = default)
        {
            ServiceResult res = new ServiceResult();
            try
            {
                await _dbContext.CollectionItemTags.AddAsync(entity, cancellationToken);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                res.Successfully = false;
                res.Errors.Add(new ServiceError(ex.Message));
            }

            return res;
        }

        public async Task<ServiceResult<IEnumerable<CollectionItemTag>>> SelectAsync(
            CancellationToken cancellationToken = default)
        {
            ServiceResult<IEnumerable<CollectionItemTag>> res
                = new ServiceResult<IEnumerable<CollectionItemTag>>();
            try
            {
                res.Value = await _dbContext.CollectionItemTags.Select(a => a).ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                res.Successfully = false;
                res.Errors.Add(new ServiceError(ex.Message));
            }

            return res;
        }

        public async Task<ServiceResult> UpdateAsync(CollectionItemTag entity,
            CancellationToken cancellationToken = default)
        {
            ServiceResult res = new ServiceResult();
            try
            {
                CollectionItemTag collectionItemTag = await _dbContext.CollectionItemTags.FirstOrDefaultAsync(item
                    => item.Id == entity.Id, cancellationToken);
                if (collectionItemTag == null)
                {
                    throw new NotFoundException(nameof(CollectionItemTag), entity.Id);
                }

                collectionItemTag.Update(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                res.Successfully = false;
                res.Errors.Add(new ServiceError(ex.Message));
            }

            return res;
        }
    }
}
