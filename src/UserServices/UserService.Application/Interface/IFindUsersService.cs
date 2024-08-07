using UserService.Application.Dto;

namespace UserService.Application.Interface
{
    public interface IFindUsersService
    {
        /// <summary>
        /// Асинхронно находит пользователей по нескольким полям.
        /// </summary>
        /// <param name="lastName">Фамилия пользователя (необязательно).</param>
        /// <param name="firstName">Имя пользователя (необязательно).</param>
        /// <param name="middleName">Отчество пользователя (необязательно).</param>
        /// <param name="phone">Телефон пользователя (необязательно).</param>
        /// <param name="email">Email пользователя (необязательно).</param>
        /// <returns>Задача, представляющая собой асинхронную операцию, с результатом в виде списка пользователей.</returns>
        Task<ResponseDto<IEnumerable<Domain.User>>> SearchUsersAsync(FindUserDto findUser);
    }
}
