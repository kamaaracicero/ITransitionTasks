using CourseWork.BusinessLogic.Exceptions;
using CourseWork.BusinessLogic.ServiceResults;
using CourseWork.BusinessLogic.Validation;
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
        public const string CountExceptionMessage = "The element already has 3 boolean fields assigned";

        private readonly MainDbContext _dbContext;
        private readonly CountValidation _validation;

        public BooleanFieldService(MainDbContext dbContext, CountValidation validation)
        {
            _dbContext = dbContext;
            _validation = validation;
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
            if (!_validation.CheckCount(entity, _dbContext.BooleanFields, 0, 3))
            {
                res.Successfully = false;
                res.Errors.Add(new ServiceError(CountExceptionMessage));
                return res;
            }
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
