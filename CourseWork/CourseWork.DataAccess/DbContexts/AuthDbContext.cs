using CourseWork.Core.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CourseWork.DataAccess.DbContexts
{
    internal class AuthDbContext : IdentityDbContext<WebUser, WebRole, string>
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options)
            : base(options)
        {
        }
    }
}
