using UserService.Application.Dto;
using UserService.Domain;

namespace UserService.Application.Interface
{
    public interface IGetUserByIdService
    {
        /// <summary>
        /// Асинхронно получает пользователя по идентификатору.
        /// </summary>
        /// <param name="UserId">Идентификатор пользователя.</param>
        /// <returns>Задача, представляющая собой асинхронную операцию, с результатом в виде пользователя.</returns>
        Task<ResponseDto<Domain.User>> GetUserByIdAsync(int UserId);
    }
}
