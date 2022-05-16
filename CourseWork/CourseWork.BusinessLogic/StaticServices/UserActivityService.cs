using CourseWork.BusinessLogic.ServiceResults;
using CourseWork.BusinessLogic.Services;
using CourseWork.Core;
using CourseWork.Core.Identity;
using CourseWork.Core.UsersActivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.BusinessLogic.StaticServices
{
    public sealed class UserActivityService : object
    {
        private readonly IService<UserLike> _likeService;
        private readonly IService<UserComment> _commentService;

        public UserActivityService(IService<UserLike> likeService,
            IService<UserComment> commentService)
        {
            _likeService = likeService;
            _commentService = commentService;
        }

        public async Task<ServiceResult> AddLike(WebUser user, int itemId)
            => await _likeService.InsertAsync(new UserLike
            {
                CollectionItemId = itemId,
                UserId = user.Id,
            });

        public async Task<ServiceResult> AddComment(WebUser user, int itemId, string comment)
            => await _commentService.InsertAsync(new UserComment
            {
                CollectionItemId = itemId,
                UserId = user.Id,
                Date = DateTime.Now,
                Text = comment,
            });

        public async Task<ServiceResult> DeleteComment(UserComment comment)
            => await _commentService.DeleteAsync(comment);

        public async Task<ServiceResult> DeleteLike(UserLike like)
            => await _likeService.DeleteAsync(like);

        public async Task<ServiceResult> UpdateComment(UserComment comment)
            => await _commentService.UpdateAsync(comment);

        public async Task<ServiceResult> UpdateLike(UserLike like)
            => await _likeService.UpdateAsync(like);

        public async Task<ServiceResult<IEnumerable<UserLike>>> GetLikes()
            => await _likeService.SelectAsync();

        public async Task<ServiceResult<IEnumerable<UserComment>>> GetComments()
            => await _commentService.SelectAsync();
    }
}
