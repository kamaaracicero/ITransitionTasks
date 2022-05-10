using CourseWork.BusinessLogic.Exceptions;
using CourseWork.BusinessLogic.Services.Results;
using CourseWork.Core.AdditionalFields;
using CourseWork.DataAccess.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CourseWork.BusinessLogic.Services.AdditionalFieldServices
{
    internal class BooleanFieldService : IService<BooleanField>
    {
        private readonly MainDbContext _dbContext;

        public BooleanFieldService(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ServiceResult> DeleteAsync(BooleanField entity,
            CancellationToken cancellationToken = default)
        {
            ServiceResult res = new ServiceResult();
            try
            {
                _dbContext.BooleanFields.Remove(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                res.Successfully = false;
                res.Errors.Add(new ServiceError(ex.Message));
            }

            return res;
        }

        public async Task<ServiceResult> InsertAsync(BooleanField entity,
            CancellationToken cancellationToken = default)
        {
            ServiceResult res = new ServiceResult();
            try
            {
                await _dbContext.BooleanFields.AddAsync(entity, cancellationToken);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                res.Successfully = false;
                res.Errors.Add(new ServiceError(ex.Message));
            }

            return res;
        }

        public async Task<ServiceResult<IEnumerable<BooleanField>>> SelectAsync(
            CancellationToken cancellationToken = default)
        {
            ServiceResult<IEnumerable<BooleanField>> res = new ServiceResult<IEnumerable<BooleanField>>();
            try
            {
                res.Value = await _dbContext.BooleanFields.Select(a => a).ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                res.Successfully = false;
                res.Errors.Add(new ServiceError(ex.Message));
            }

            return res;
        }

        public async Task<ServiceResult> UpdateAsync(BooleanField entity,
            CancellationToken cancellationToken = default)
        {
            ServiceResult res = new ServiceResult();
            try
            {
                BooleanField booleanField = await _dbContext.BooleanFields.FirstOrDefaultAsync(item
                    => item.Id == entity.Id, cancellationToken);
                if (booleanField == null)
                {
                    throw new NotFoundException(nameof(BooleanField), entity.Id);
                }

                booleanField.Update(entity);
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
