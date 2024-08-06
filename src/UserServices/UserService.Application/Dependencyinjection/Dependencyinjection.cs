using Microsoft.Extensions.DependencyInjection;
using MSSQL.Application.DependencyInjection;
using UserService.Application.CQRS.Command.Create;
using UserService.Application.Interface;

namespace UserService.Application.Dependencyinjection
{
    public static class Dependencyinjection
    {
        public static IServiceCollection AddUserServiceApplication(this IServiceCollection services)
        {
            // Add MediatR
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));

            services.AddScoped<CreateUserValidator>();
            services.AddScoped<ICreateUserService, CreateUser>();
            services.AddScoped<CreateUserCommand>();
            services.AddScoped<CreateUserHandler>();

            return services;
        }
    }
}
