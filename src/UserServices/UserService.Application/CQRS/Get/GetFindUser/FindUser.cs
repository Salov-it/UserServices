using Microsoft.EntityFrameworkCore;
using MSSQL.Application.Context;
using UserService.Application.Dto;
using UserService.Application.Interface;

namespace UserService.Application.CQRS.Get.GetFindUser
{
    public class FindUser : IFindUsersService
    {
        private readonly UserContext _userContext;

        public FindUser(UserContext userContext)
        {
            _userContext = userContext;
        }

        public async Task<ResponseDto<IEnumerable<Domain.User>>> SearchUsersAsync(FindUserDto findUser)
        {
            try
            {
                var query = _userContext.Users.AsQueryable();

                query = query.Where(u =>
                        (string.IsNullOrEmpty(findUser.LastName) || u.LastName.ToLower().Contains(findUser.LastName.ToLower())) &&
                        (string.IsNullOrEmpty(findUser.FirstName) || u.FirstName.ToLower().Contains(findUser.FirstName.ToLower())) &&
                        (string.IsNullOrEmpty(findUser.MiddleName) || u.MiddleName.ToLower().Contains(findUser.MiddleName.ToLower())) &&
                        (string.IsNullOrEmpty(findUser.Phone) || u.Phone.ToLower().Contains(findUser.Phone.ToLower())) &&
                        (string.IsNullOrEmpty(findUser.Email) || u.Email.ToLower().Contains(findUser.Email.ToLower()))

                );

                var result = await query.ToListAsync();

                return new ResponseDto<IEnumerable<Domain.User>>
                {
                    Data = result
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto<IEnumerable<Domain.User>>
                {
                    ErrorMessage = ex.Message
                };
            }

        }
    }
}
