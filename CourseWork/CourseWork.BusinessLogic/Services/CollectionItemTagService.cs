using CourseWork.BusinessLogic.Exceptions;
using CourseWork.Core;
using CourseWork.DataAccess.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CourseWork.BusinessLogic.Services
{
    internal class CollectionItemTagService : IService<CollectionItemTag>
    {
        private readonly MainDbContext _dbContext;

        public CollectionItemTagService(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task DeleteAsync(CollectionItemTag entity, CancellationToken cancellationToken = default)
        {
            _dbContext.CollectionItemTags.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task InsertAsync(CollectionItemTag entity, CancellationToken cancellationToken = default)
        {
            await _dbContext.CollectionItemTags.AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<CollectionItemTag>> SelectAsync(
            CancellationToken cancellationToken = default)
            => await _dbContext.CollectionItemTags.Select(a => a).ToListAsync(cancellationToken);

        public async Task UpdateAsync(CollectionItemTag entity, CancellationToken cancellationToken = default)
        {
            CollectionItemTag res = await _dbContext.CollectionItemTags.FirstOrDefaultAsync(item
                => item.Id == entity.Id, cancellationToken);
            if (res == null)
            {
                throw new NotFoundException(nameof(CollectionItemTag), entity.Id);
            }

            res.Update(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
