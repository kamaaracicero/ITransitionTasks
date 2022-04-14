using Microsoft.AspNetCore.Identity;
using System;

namespace WebTask.Api.Core
{
    public class WebUser : IdentityUser
    {
        public WebUser()
            : base()
        {
        }

        public DateTime RegistrationDate { get; set; }

        public DateTime LastLoginDate { get; set; }

        public int Status { get; set; }

        public string StatusString { get => Status == 1 ? "blocked" : "active"; }
    }
}
