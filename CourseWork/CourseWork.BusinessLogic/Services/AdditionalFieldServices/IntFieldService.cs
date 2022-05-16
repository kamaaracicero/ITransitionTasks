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
    internal class IntFieldService : IService<IntField>
    {
        public const string CountExceptionMessage = "The element already has 3 int fields assigned";

        private readonly MainDbContext _dbContext;
        private readonly CountValidation _validation;

        public IntFieldService(MainDbContext dbContext, CountValidation validation)
        {
            _dbContext = dbContext;
            _validation = validation;
        }

        public async Task<ServiceResult> DeleteAsync(IntField entity,
            CancellationToken cancellationToken = default)
        {
            ServiceResult res = new ServiceResult();
            try
            {
                _dbContext.IntFields.Remove(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                res.Successfully = false;
                res.Errors.Add(new ServiceError(ex.Message));
            }

            return res;
        }

        public async Task<ServiceResult> InsertAsync(IntField entity,
            CancellationToken cancellationToken = default)
        {
            ServiceResult res = new ServiceResult();
            if (!_validation.CheckCount(entity, _dbContext.IntFields, 0, 3))
            {
                res.Successfully = false;
                res.Errors.Add(new ServiceError(CountExceptionMessage));
                return res;
            }
            try
            {
                await _dbContext.IntFields.AddAsync(entity, cancellationToken);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                res.Successfully = false;
                res.Errors.Add(new ServiceError(ex.Message));
            }

            return res;
        }

        public async Task<ServiceResult<IEnumerable<IntField>>> SelectAsync(
            CancellationToken cancellationToken = default)
        {
            ServiceResult<IEnumerable<IntField>> res = new ServiceResult<IEnumerable<IntField>>();
            try
            {
                res.Value = await _dbContext.IntFields.Select(a => a).ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                res.Successfully = false;
                res.Errors.Add(new ServiceError(ex.Message));
            }

            return res;
        }

        public async Task<ServiceResult> UpdateAsync(IntField entity,
            CancellationToken cancellationToken = default)
        {
            ServiceResult res = new ServiceResult();
            try
            {
                IntField intField = await _dbContext.IntFields.FirstOrDefaultAsync(item
                    => item.Id == entity.Id, cancellationToken);
                if (intField == null)
                {
                    throw new NotFoundException(nameof(IntField), entity.Id);
                }

                intField.Update(entity);
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
