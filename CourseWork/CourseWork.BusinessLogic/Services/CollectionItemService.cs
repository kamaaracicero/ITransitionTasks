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
    internal class CollectionItemService : IService<CollectionItem>
    {
        private readonly MainDbContext _dbContext;

        public CollectionItemService(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task DeleteAsync(CollectionItem entity, CancellationToken cancellationToken = default)
        {
            _dbContext.CollectionItems.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task InsertAsync(CollectionItem entity, CancellationToken cancellationToken = default)
        {
            await _dbContext.CollectionItems.AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<CollectionItem>> SelectAsync(CancellationToken cancellationToken = default)
            => await _dbContext.CollectionItems.Select(a => a).ToListAsync(cancellationToken);

        public async Task UpdateAsync(CollectionItem entity, CancellationToken cancellationToken = default)
        {
            CollectionItem res = await _dbContext.CollectionItems.FirstOrDefaultAsync(item
                => item.Id == entity.Id, cancellationToken);
            if (res == null)
            {
                throw new NotFoundException(nameof(CollectionItem), entity.Id);
            }

            res.Update(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
