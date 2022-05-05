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
    internal class UserLikeService : IService<UserLike>
    {
        private readonly MainDbContext _dbContext;

        public UserLikeService(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task DeleteAsync(UserLike entity, CancellationToken cancellationToken = default)
        {
            _dbContext.UserLikes.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task InsertAsync(UserLike entity, CancellationToken cancellationToken = default)
        {
            await _dbContext.UserLikes.AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<UserLike>> SelectAsync(CancellationToken cancellationToken = default)
            => await _dbContext.UserLikes.Select(a => a).ToListAsync(cancellationToken);

        public async Task UpdateAsync(UserLike entity, CancellationToken cancellationToken = default)
        {
            UserLike res = await _dbContext.UserLikes.FirstOrDefaultAsync(item => item.Id == entity.Id,
                cancellationToken);
            if (res == null)
            {
                throw new NotFoundException(nameof(UserLike), entity.Id);
            }

            res.Update(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
