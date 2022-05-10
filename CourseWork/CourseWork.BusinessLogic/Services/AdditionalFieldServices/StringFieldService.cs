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
    internal class StringFieldService : IService<StringField>
    {
        private readonly MainDbContext _dbContext;

        public StringFieldService(MainDbContext dbContext)
        {
            _dbContext = dbContext;
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
