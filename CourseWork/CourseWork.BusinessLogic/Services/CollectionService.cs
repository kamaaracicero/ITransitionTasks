using CourseWork.BusinessLogic.Exceptions;
using CourseWork.Core;
using CourseWork.DataAccess.DbContexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CourseWork.BusinessLogic.Services
{
    internal class CollectionService : IService<Collection>
    {
        private readonly MainDbContext _dbContext;

        public CollectionService(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task DeleteAsync(Collection entity, CancellationToken cancellationToken = default)
        {
            _dbContext.Collections.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task InsertAsync(Collection entity, CancellationToken cancellationToken = default)
        {
            await _dbContext.Collections.AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<Collection>> SelectAsync(CancellationToken cancellationToken = default)
            => await _dbContext.Collections.Select(a => a).ToListAsync(cancellationToken);

        public async Task UpdateAsync(Collection entity, CancellationToken cancellationToken = default)
        {
            Collection res = await _dbContext.Collections.FirstOrDefaultAsync(item => item.Id == entity.Id,
                cancellationToken);
            if (res == null)
            {
                throw new NotFoundException(nameof(Collection), entity.Id);
            }

            res.Update(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
