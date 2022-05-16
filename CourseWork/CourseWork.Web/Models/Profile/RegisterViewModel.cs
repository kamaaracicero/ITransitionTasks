using System.ComponentModel.DataAnnotations;

namespace CourseWork.Web.Models.Profile
{
    public class RegisterViewModel
    {
        public RegisterViewModel()
        {
            FirstName = string.Empty;
            SecondName = string.Empty;
            UserName = string.Empty;
            Password = string.Empty;
            ConfirmPassword = string.Empty;
        }

        [Required]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string SecondName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Password and confirm password did not match.")]
        public string ConfirmPassword { get; set; }
    }
}
