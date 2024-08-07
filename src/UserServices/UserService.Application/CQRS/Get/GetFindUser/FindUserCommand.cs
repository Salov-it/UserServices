using MediatR;
using UserService.Application.Dto;


namespace UserService.Application.CQRS.Get.GetFindUser
{
    public class FindUserCommand : IRequest<ResponseDto<IEnumerable<Domain.User>>>
    {
        public FindUserDto findUser {  get; set; }
    }
}
