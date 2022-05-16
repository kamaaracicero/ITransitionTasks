using System.ComponentModel.DataAnnotations;

namespace CourseWork.Web.Models.Roles
{
    public class CreateRoleViewModel
    {
        [Required]
        public string Name { get; set; }
    }
}
