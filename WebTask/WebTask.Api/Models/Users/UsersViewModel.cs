using System.Collections.Generic;
using WebTask.Api.Core;

namespace WebTask.Api.Models.Users
{
    public class UsersViewModel
    {
        public IEnumerable<WebUser> Users { get; set; }
    }
}
