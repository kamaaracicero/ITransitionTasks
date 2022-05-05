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
    internal class StringFieldService : IService<StringField>
    {
        private readonly MainDbContext _dbContext;

        public StringFieldService(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task DeleteAsync(StringField entity, CancellationToken cancellationToken = default)
        {
            _dbContext.StringFields.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task InsertAsync(StringField entity, CancellationToken cancellationToken = default)
        {
            await _dbContext.StringFields.AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<StringField>> SelectAsync(CancellationToken cancellationToken = default)
            => await _dbContext.StringFields.Select(a => a).ToListAsync(cancellationToken);

        public async Task UpdateAsync(StringField entity, CancellationToken cancellationToken = default)
        {
            StringField res = await _dbContext.StringFields.FirstOrDefaultAsync(item => item.Id == entity.Id,
                cancellationToken);
            if (res == null)
            {
                throw new NotFoundException(nameof(StringField), entity.Id);
            }

            res.Update(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
