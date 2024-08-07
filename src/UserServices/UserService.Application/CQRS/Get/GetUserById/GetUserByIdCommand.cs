using MediatR;
using UserService.Application.Dto;

namespace UserService.Application.CQRS.Get.GetUserById
{
    public class GetUserByIdCommand : IRequest<ResponseDto<Domain.User>>
    {
        public int UserId { get; set; }
    }
}
