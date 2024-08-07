using MSSQL.Application.Context;
using UserService.Application.Dto;
using UserService.Application.Interface;
using UserService.Domain;

namespace UserService.Application.CQRS.Get.GetUserById
{
    public class GetUserById : IGetUserByIdService
    {
        private readonly UserContext _userContext;

        public GetUserById(UserContext userContext)
        {
            _userContext = userContext;
        }

        public async Task<ResponseDto<Domain.User>> GetUserByIdAsync(int UserId)
        {
            try
            {
                User user = await _userContext.Users.FindAsync(UserId);
                
                return new ResponseDto<User>
                {
                    Data = user
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto<User>
                {
                    ErrorMessage = ex.Message,
                };
            }
        }
    }
}
