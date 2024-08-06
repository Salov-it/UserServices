using UserService.Application.Dto;

namespace UserService.Application.Interface
{
    public interface ICreateUserService
    {
        /// <summary>
        /// Асинхронно создает нового пользователя.
        /// </summary>
        /// <param name="user">Информация о пользователе.</param>
        /// <returns>Задача, представляющая собой асинхронную операцию.</returns>
        Task<ServiceResult> CreateUserAsync(CreateUserDto user);
    }
}
