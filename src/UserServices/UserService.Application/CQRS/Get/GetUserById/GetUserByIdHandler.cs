using MediatR;
using UserService.Application.Dto;
using UserService.Application.Interface;
using UserService.Domain;

namespace UserService.Application.CQRS.Get.GetUserById
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdCommand, ResponseDto<Domain.User>>
    {
        private readonly IGetUserByIdService _getUserById;

        public GetUserByIdHandler(IGetUserByIdService getUserById)
        {
            _getUserById = getUserById;
        }

        public async Task<ResponseDto<Domain.User>> Handle(GetUserByIdCommand request, CancellationToken cancellationToken)
        {
            ResponseDto<Domain.User> user = await _getUserById.GetUserByIdAsync(request.UserId);

            if (user != null)
            {
                return new ResponseDto<User>
                {
                    Data = user.Data
                };
            }
            else 
            {
                return new ResponseDto<User>
                {
                    ErrorMessage = user.ErrorMessage
                };
            }
        }
    }
}
