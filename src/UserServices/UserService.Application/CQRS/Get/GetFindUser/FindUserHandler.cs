using MediatR;
using UserService.Application.Dto;
using UserService.Application.Interface;
using UserService.Domain;

namespace UserService.Application.CQRS.Get.GetFindUser
{
    public class FindUserHandler : IRequestHandler<FindUserCommand, ResponseDto<IEnumerable<Domain.User>>>
    {
        private readonly IFindUsersService _findUsersService;

        public FindUserHandler(IFindUsersService findUsersService)
        {
            _findUsersService = findUsersService;
        }

        public async Task<ResponseDto<IEnumerable<User>>> Handle(FindUserCommand request, CancellationToken cancellationToken)
        {
            var findUser = await _findUsersService.SearchUsersAsync(request.findUser);

            if (findUser != null)
            {
                return new ResponseDto<IEnumerable<User>>
                {
                    Data = findUser.Data,
                };
            }
            else
            {
                return new ResponseDto<IEnumerable<User>>
                {
                    ErrorMessage = findUser.ErrorMessage
                };
            }
        
        }
    }
}
