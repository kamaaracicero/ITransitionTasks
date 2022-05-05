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
    internal class BooleanFieldService : IService<BooleanField>
    {
        private readonly MainDbContext _dbContext;

        public BooleanFieldService(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task DeleteAsync(BooleanField entity, CancellationToken cancellationToken = default)
        {
            _dbContext.BooleanFields.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task InsertAsync(BooleanField entity, CancellationToken cancellationToken = default)
        {
            await _dbContext.BooleanFields.AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<BooleanField>> SelectAsync(CancellationToken cancellationToken = default)
            => await _dbContext.BooleanFields.Select(a => a).ToListAsync(cancellationToken);

        public async Task UpdateAsync(BooleanField entity, CancellationToken cancellationToken = default)
        {
            BooleanField res = await _dbContext.BooleanFields.FirstOrDefaultAsync(item => item.Id == entity.Id,
                cancellationToken);
            if (res == null)
            {
                throw new NotFoundException(nameof(BooleanField), entity.Id);
            }

            res.Update(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
