using Microsoft.AspNetCore.Identity;

namespace CourseWork.Core.Identity
{
    public sealed class WebUser : IdentityUser
    {
        public WebUser()
            : base()
        {
            FirstName = null;
            SecondName = null;
        }

        public string FirstName { get; set; }

        public string SecondName { get; set; }
    }
}
