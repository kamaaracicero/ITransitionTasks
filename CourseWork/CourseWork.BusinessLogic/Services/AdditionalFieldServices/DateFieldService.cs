using CourseWork.BusinessLogic.Exceptions;
using CourseWork.Core.AdditionalFields;
using CourseWork.DataAccess.DbContexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CourseWork.BusinessLogic.Services.AdditionalFieldServices
{
    internal class DateFieldService : IService<DateField>
    {
        private readonly MainDbContext _dbContext;

        public DateFieldService(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task DeleteAsync(DateField entity, CancellationToken cancellationToken = default)
        {
            _dbContext.DateFields.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task InsertAsync(DateField entity, CancellationToken cancellationToken = default)
        {
            await _dbContext.DateFields.AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<DateField>> SelectAsync(CancellationToken cancellationToken = default)
            => await _dbContext.DateFields.Select(a => a).ToListAsync(cancellationToken);

        public async Task UpdateAsync(DateField entity, CancellationToken cancellationToken = default)
        {
            DateField res = await _dbContext.DateFields.FirstOrDefaultAsync(item => item.Id == entity.Id,
                cancellationToken);
            if (res == null)
            {
                throw new NotFoundException(nameof(DateField), entity.Id);
            }

            res.Update(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
