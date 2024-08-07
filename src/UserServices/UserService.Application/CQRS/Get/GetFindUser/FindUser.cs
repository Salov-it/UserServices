using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MSSQL.Application.Context;
using UserService.Application.Dto;
using UserService.Application.Interface;
using UserService.Domain;

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
                        (string.IsNullOrEmpty(findUser.LastName) || u.LastName.Contains(findUser.LastName)) &&
                        (string.IsNullOrEmpty(findUser.FirstName) || u.FirstName.Contains(findUser.FirstName)) &&
                        (string.IsNullOrEmpty(findUser.MiddleName) || u.MiddleName.Contains(findUser.MiddleName)) &&
                        (string.IsNullOrEmpty(findUser.Phone) || u.Phone.Contains(findUser.Phone)) &&
                        (string.IsNullOrEmpty(findUser.Email) || u.Email.Contains(findUser.Email))
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
