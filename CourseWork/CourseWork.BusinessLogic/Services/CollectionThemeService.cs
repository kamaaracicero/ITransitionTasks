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
    internal class CollectionThemeService : IService<CollectionTheme>
    {
        private readonly MainDbContext _dbContext;

        public CollectionThemeService(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task DeleteAsync(CollectionTheme entity, CancellationToken cancellationToken = default)
        {
            _dbContext.CollectionThemes.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task InsertAsync(CollectionTheme entity, CancellationToken cancellationToken = default)
        {
            await _dbContext.CollectionThemes.AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<CollectionTheme>> SelectAsync(CancellationToken cancellationToken = default)
            => await _dbContext.CollectionThemes.Select(a => a).ToListAsync(cancellationToken);

        public async Task UpdateAsync(CollectionTheme entity, CancellationToken cancellationToken = default)
        {
            CollectionTheme res = await _dbContext.CollectionThemes.FirstOrDefaultAsync(item
                => item.Id == entity.Id, cancellationToken);
            if (res == null)
            {
                throw new NotFoundException(nameof(CollectionTheme), entity.Id);
            }

            res.Update(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
