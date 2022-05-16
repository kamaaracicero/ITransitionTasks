using CourseWork.Core.Identity;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace CourseWork.Web.Models.Roles
{
    public class ChangeRoleViewModel
    {
        public ChangeRoleViewModel()
        {
            AllRoles = new List<WebRole>();
            UserRoles = new List<string>();
        }

        public string UserId { get; set; }

        public string UserName { get; set; }

        public List<WebRole> AllRoles { get; set; }

        public IList<string> UserRoles { get; set; }
    }
}
