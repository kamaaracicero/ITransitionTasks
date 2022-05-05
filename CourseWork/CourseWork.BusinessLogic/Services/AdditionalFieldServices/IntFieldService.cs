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
    internal class IntFieldService : IService<IntField>
    {
        private readonly MainDbContext _dbContext;

        public IntFieldService(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task DeleteAsync(IntField entity, CancellationToken cancellationToken = default)
        {
            _dbContext.IntFields.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task InsertAsync(IntField entity, CancellationToken cancellationToken = default)
        {
            await _dbContext.IntFields.AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<IntField>> SelectAsync(CancellationToken cancellationToken = default)
            => await _dbContext.IntFields.Select(a => a).ToListAsync(cancellationToken);

        public async Task UpdateAsync(IntField entity, CancellationToken cancellationToken = default)
        {
            IntField res = await _dbContext.IntFields.FirstOrDefaultAsync(item => item.Id == entity.Id,
                cancellationToken);
            if (res == null)
            {
                throw new NotFoundException(nameof(IntField), entity.Id);
            }

            res.Update(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
