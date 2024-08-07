using Microsoft.Extensions.DependencyInjection;
using MSSQL.Application.DependencyInjection;
using UserService.Application.CQRS.Command.Create;
using UserService.Application.CQRS.Get.GetFindUser;
using UserService.Application.CQRS.Get.GetUserById;
using UserService.Application.Interface;

namespace UserService.Application.Dependencyinjection
{
    public static class Dependencyinjection
    {
        public static IServiceCollection AddUserServiceApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));

            services.AddScoped<CreateUserValidator>();
            services.AddScoped<ICreateUserService, CreateUser>();
            services.AddScoped<CreateUserCommand>();
            services.AddScoped<CreateUserHandler>();

            services.AddScoped<IGetUserByIdService, GetUserById>();
            services.AddScoped<GetUserByIdCommand>();
            services.AddScoped<GetUserByIdHandler>();

            services.AddScoped<IFindUsersService,FindUser>();
            services.AddScoped<FindUserCommand>();
            services.AddScoped<FindUserHandler>();

            return services;
        }
    }
}
