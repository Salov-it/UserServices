using MediatR;
using UserService.Application.Dto;

namespace UserService.Application.CQRS.Command.Create
{
    public class CreateUserCommand : IRequest<ServiceResult>
    {
        public CreateUserDto createUser { get; set; }
    }
}
