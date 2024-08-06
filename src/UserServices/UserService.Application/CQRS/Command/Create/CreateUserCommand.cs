using MediatR;
using UserService.Application.Dto;
using UserService.Domain;

namespace UserService.Application.CQRS.Command.Create
{
    public class CreateUserCommand : IRequest<ServiceResult>
    {
        public CreateUserDto createUser { get; set; }
    }
}
