using CourseWork.BusinessLogic.Exceptions;
using CourseWork.Core.UsersActivity;
using CourseWork.DataAccess.DbContexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CourseWork.BusinessLogic.Services.UserAcitivityServices
{
    internal class UserCommentService : IService<UserComment>
    {
        private readonly MainDbContext _dbContext;

        public UserCommentService(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task DeleteAsync(UserComment entity, CancellationToken cancellationToken = default)
        {
            _dbContext.UserComments.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task InsertAsync(UserComment entity, CancellationToken cancellationToken = default)
        {
            await _dbContext.UserComments.AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<UserComment>> SelectAsync(CancellationToken cancellationToken = default)
            => await _dbContext.UserComments.Select(a => a).ToListAsync(cancellationToken);

        public async Task UpdateAsync(UserComment entity, CancellationToken cancellationToken = default)
        {
            UserComment res = await _dbContext.UserComments.FirstOrDefaultAsync(item => item.Id == entity.Id,
                cancellationToken);
            if (res == null)
            {
                throw new NotFoundException(nameof(UserComment), entity.Id);
            }

            res.Update(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
