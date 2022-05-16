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
    internal class StringFieldService : IService<StringField>
    {
        public const string CountExceptionMessage = "The element already has 3 string fields assigned";

        private readonly MainDbContext _dbContext;
        private readonly CountValidation _validation;

        public StringFieldService(MainDbContext dbContext, CountValidation validation)
        {
            _dbContext = dbContext;
            _validation = validation;
        }

        public async Task<ServiceResult> DeleteAsync(StringField entity,
            CancellationToken cancellationToken = default)
        {
            ServiceResult res = new ServiceResult();
            try
            {
                _dbContext.StringFields.Remove(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                res.Successfully = false;
                res.Errors.Add(new ServiceError(ex.Message));
            }

            return res;
        }

        public async Task<ServiceResult> InsertAsync(StringField entity,
            CancellationToken cancellationToken = default)
        {
            ServiceResult res = new ServiceResult();
            if (!_validation.CheckCount(entity, _dbContext.StringFields, 0, 3))
            {
                res.Successfully = false;
                res.Errors.Add(new ServiceError(CountExceptionMessage));
                return res;
            }
            try
            {
                await _dbContext.StringFields.AddAsync(entity, cancellationToken);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                res.Successfully = false;
                res.Errors.Add(new ServiceError(ex.Message));
            }

            return res;
        }

        public async Task<ServiceResult<IEnumerable<StringField>>> SelectAsync(
            CancellationToken cancellationToken = default)
        {
            ServiceResult<IEnumerable<StringField>> res = new ServiceResult<IEnumerable<StringField>>();
            try
            {
                res.Value = await _dbContext.StringFields.Select(a => a).ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                res.Successfully = false;
                res.Errors.Add(new ServiceError(ex.Message));
            }

            return res;
        }

        public async Task<ServiceResult> UpdateAsync(StringField entity,
            CancellationToken cancellationToken = default)
        {
            ServiceResult res = new ServiceResult();
            try
            {
                StringField stringField = await _dbContext.StringFields.FirstOrDefaultAsync(item
                    => item.Id == entity.Id, cancellationToken);
                if (stringField == null)
                {
                    throw new NotFoundException(nameof(StringField), entity.Id);
                }

                stringField.Update(entity);
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
