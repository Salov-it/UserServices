using UserService.Application.Interface;
using UserService.Domain;
using MSSQL.Application.Context;
using UserService.Application.Dto;

namespace UserService.Application.CQRS.Command.Create
{
    public class CreateUser : ICreateUserService
    {
        private readonly UserContext _userContext;

        public CreateUser(UserContext userContext)
        {
            _userContext = userContext;
        }

        public async Task<ServiceResult> CreateUserAsync(CreateUserDto user)
        {
            try
            {
                User AddUser = new User
                {
                    LastName = user.LastName,
                    FirstName = user.FirstName,
                    MiddleName = user.MiddleName,
                    DateOfBirth = user.DateOfBirth,
                    PassportNumber = user.PassportNumber,
                    PlaceOfBirth = user.PlaceOfBirth,
                    Phone = user.Phone,
                    Email = user.Email,
                    RegistrationAddress = user.RegistrationAddress,
                    ResidentialAddress = user.ResidentialAddress,
                    Date = DateTime.UtcNow
                };
                _userContext.Users.Add(AddUser);
                await _userContext.SaveChangesAsync();

                return new ServiceResult() { IsSuccesful = true };
            }
            catch (Exception ex)
            {
                return new ServiceResult()
                {
                    IsSuccesful = false,
                    ErrorMsg = ex.Message
                };
            }
        }
    }
}
