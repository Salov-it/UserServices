using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MSSQL.Application.Context;

namespace MSSQL.Application.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddMSSQLApplication(this IServiceCollection services, IConfiguration configuration)
        {
            string? Connections = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<UserContext>(options =>
                    options.UseSqlServer(Connections));

            return services;
        }
    }
}
