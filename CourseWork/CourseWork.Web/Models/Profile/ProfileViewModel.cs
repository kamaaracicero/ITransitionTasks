using CourseWork.Core.Identity;

namespace CourseWork.Web.Models.Profile
{
    public class ProfileViewModel
    {
        public ProfileViewModel(WebUser user)
        {
            Id = user.Id;
            UserName = user.UserName;
            FirstName = user.FirstName;
            SecondName = user.SecondName;
        }

        public ProfileViewModel()
        {
        }

        public string Id { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public override string ToString() => FirstName + " " + SecondName;
    }
}
