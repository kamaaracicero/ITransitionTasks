using CourseWork.DataAccess.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CourseWork.DataAccess.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection
            services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultDatabase");

            services.AddDbContext<MainDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            services.AddScoped(provider => provider.GetService<MainDbContext>());

            services.AddDbContext<AuthDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            return services;
        }
    }
}
