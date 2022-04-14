using System.ComponentModel.DataAnnotations;

namespace WebTask.Api.Models.Account
{
    public class RegisterViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Password and confirm password did not match.")]
        public string ConfirmPassword { get; set; }
    }
}
