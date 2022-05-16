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
    internal class TextFieldService : IService<TextField>
    {
        public const string CountExceptionMessage = "The element already has 3 text fields assigned";

        private readonly MainDbContext _dbContext;
        private readonly CountValidation _validation;

        public TextFieldService(MainDbContext dbContext, CountValidation validation)
        {
            _dbContext = dbContext;
            _validation = validation;
        }

        public async Task<ServiceResult> DeleteAsync(TextField entity,
            CancellationToken cancellationToken = default)
        {
            ServiceResult res = new ServiceResult();
            try
            {
                _dbContext.TextFields.Remove(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                res.Successfully = false;
                res.Errors.Add(new ServiceError(ex.Message));
            }

            return res;
        }

        public async Task<ServiceResult> InsertAsync(TextField entity,
            CancellationToken cancellationToken = default)
        {
            ServiceResult res = new ServiceResult();
            if (!_validation.CheckCount(entity, _dbContext.TextFields, 0, 3))
            {
                res.Successfully = false;
                res.Errors.Add(new ServiceError(CountExceptionMessage));
                return res;
            }
            try
            {
                await _dbContext.TextFields.AddAsync(entity, cancellationToken);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                res.Successfully = false;
                res.Errors.Add(new ServiceError(ex.Message));
            }

            return res;
        }

        public async Task<ServiceResult<IEnumerable<TextField>>> SelectAsync(
            CancellationToken cancellationToken = default)
        {
            ServiceResult<IEnumerable<TextField>> res = new ServiceResult<IEnumerable<TextField>>();
            try
            {
                res.Value = await _dbContext.TextFields.Select(a => a).ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                res.Successfully = false;
                res.Errors.Add(new ServiceError(ex.Message));
            }

            return res;
        }

        public async Task<ServiceResult> UpdateAsync(TextField entity,
            CancellationToken cancellationToken = default)
        {
            ServiceResult res = new ServiceResult();
            try
            {
                TextField textField = await _dbContext.TextFields.FirstOrDefaultAsync(item
                    => item.Id == entity.Id, cancellationToken);
                if (textField == null)
                {
                    throw new NotFoundException(nameof(TextField), entity.Id);
                }

                textField.Update(entity);
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
