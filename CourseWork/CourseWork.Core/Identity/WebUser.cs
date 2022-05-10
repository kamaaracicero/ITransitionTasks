using Microsoft.AspNetCore.Identity;

namespace CourseWork.Core.Identity
{
    public sealed class WebUser : IdentityUser
    {
        public WebUser()
            : base()
        {
            FirstName = string.Empty;
            SecondName = string.Empty;
        }

        public string FirstName { get; set; }

        public string SecondName { get; set; }
    }
}
