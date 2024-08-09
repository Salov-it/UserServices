using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserService.Domain
{
    /// <summary>
    /// Представляет пользователя с личной информацией.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Уникальный идентификатор пользователя.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Фамилия пользователя.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Имя пользователя.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Отчество пользователя.
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Дата рождения пользователя.
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Номер паспорта пользователя в формате ХХХХ ХХХХХХ.
        /// </summary>
        public string PassportNumber { get; set; }

        /// <summary>
        /// Место рождения пользователя.
        /// </summary>
        public string PlaceOfBirth { get; set; }

        /// <summary>
        /// Телефонный номер пользователя в формате 7ХХХХХХХХХХ.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Адрес электронной почты пользователя.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Адрес регистрации пользователя.
        /// </summary>
        public string RegistrationAddress { get; set; }

        /// <summary>
        /// Адрес проживания пользователя.
        /// </summary>
        public string ResidentialAddress { get; set; }

        public DateTime Date {  get; set; }
    }

}
