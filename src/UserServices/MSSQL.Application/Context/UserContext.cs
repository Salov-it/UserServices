using Microsoft.EntityFrameworkCore;
using UserService.Domain;

namespace MSSQL.Application.Context
{
    public class UserContext : DbContext
    {
      
        /// <summary>
        /// Таблица пользователей.
        /// </summary>
        public DbSet<User> Users { get; set; }

        public UserContext(DbContextOptions<UserContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
