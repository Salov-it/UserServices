using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
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
            services.AddScoped<CreateUserValidatorFactory>();
            services.AddScoped<CreateUserValidator>();
            services.AddScoped<ICreateUserService, CreateUser>();
            services.AddScoped<CreateUserCommand>();
            services.AddScoped<CreateUserHandler>();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateUserHandler).Assembly));

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
