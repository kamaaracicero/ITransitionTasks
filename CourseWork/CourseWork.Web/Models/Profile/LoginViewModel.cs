using System.ComponentModel.DataAnnotations;

namespace CourseWork.Web.Models.Profile
{
    public class LoginViewModel
    {
        public LoginViewModel()
        {
            UserName = string.Empty;
            Password = string.Empty;
            RememberMe = false;
        }

        [Required]
        [DataType(DataType.Text)]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
