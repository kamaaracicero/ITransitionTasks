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
    internal class TextFieldService : IService<TextField>
    {
        private readonly MainDbContext _dbContext;

        public TextFieldService(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task DeleteAsync(TextField entity, CancellationToken cancellationToken = default)
        {
            _dbContext.TextFields.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task InsertAsync(TextField entity, CancellationToken cancellationToken = default)
        {
            await _dbContext.TextFields.AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<TextField>> SelectAsync(CancellationToken cancellationToken = default)
            => await _dbContext.TextFields.Select(a => a).ToListAsync(cancellationToken);

        public async Task UpdateAsync(TextField entity, CancellationToken cancellationToken = default)
        {
            TextField res = await _dbContext.TextFields.FirstOrDefaultAsync(item => item.Id == entity.Id,
                cancellationToken);
            if (res == null)
            {
                throw new NotFoundException(nameof(TextField), entity.Id);
            }

            res.Update(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
