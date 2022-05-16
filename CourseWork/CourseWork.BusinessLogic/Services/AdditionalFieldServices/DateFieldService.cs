﻿using CourseWork.BusinessLogic.Exceptions;
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
    internal class DateFieldService : IService<DateField>
    {
        public const string CountExceptionMessage = "The element already has 3 date fields assigned";

        private readonly MainDbContext _dbContext;
        private readonly CountValidation _validation;

        public DateFieldService(MainDbContext dbContext, CountValidation validation)
        {
            _dbContext = dbContext;
            _validation = validation;
        }

        public async Task<ServiceResult> DeleteAsync(DateField entity,
            CancellationToken cancellationToken = default)
        {
            ServiceResult res = new ServiceResult();
            try
            {
                _dbContext.DateFields.Remove(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                res.Successfully = false;
                res.Errors.Add(new ServiceError(ex.Message));
            }

            return res;
        }

        public async Task<ServiceResult> InsertAsync(DateField entity,
            CancellationToken cancellationToken = default)
        {
            ServiceResult res = new ServiceResult();
            if (!_validation.CheckCount(entity, _dbContext.DateFields, 0, 3))
            {
                res.Successfully = false;
                res.Errors.Add(new ServiceError(CountExceptionMessage));
                return res;
            }
            try
            {
                await _dbContext.DateFields.AddAsync(entity, cancellationToken);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                res.Successfully = false;
                res.Errors.Add(new ServiceError(ex.Message));
            }

            return res;
        }

        public async Task<ServiceResult<IEnumerable<DateField>>> SelectAsync(
            CancellationToken cancellationToken = default)
        {
            ServiceResult<IEnumerable<DateField>> res = new ServiceResult<IEnumerable<DateField>>();
            try
            {
                res.Value = await _dbContext.DateFields.Select(a => a).ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                res.Successfully = false;
                res.Errors.Add(new ServiceError(ex.Message));
            }

            return res;
        }

        public async Task<ServiceResult> UpdateAsync(DateField entity,
            CancellationToken cancellationToken = default)
        {
            ServiceResult res = new ServiceResult();
            try
            {
                DateField dateField = await _dbContext.DateFields.FirstOrDefaultAsync(item
                    => item.Id == entity.Id, cancellationToken);
                if (dateField == null)
                {
                    throw new NotFoundException(nameof(DateField), entity.Id);
                }

                dateField.Update(entity);
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
