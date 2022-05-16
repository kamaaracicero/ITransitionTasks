using CourseWork.Core.Identity;
using CourseWork.Core.UsersActivity;
using System;

namespace CourseWork.Web.Models.Item
{
    public class UserCommentViewModel
    {
        public UserCommentViewModel()
        {
            Username = string.Empty;
            Date = new DateTime(1980, 1, 1);
            Text = string.Empty;
        }

        public UserCommentViewModel(WebUser user, UserComment comment)
        {
            Username = user.UserName;
            Date = comment.Date;
            Text = comment.Text;
        }

        public string Username { get; set; }

        public DateTime Date { get; set; }

        public string Text { get; set; }
    }
}
