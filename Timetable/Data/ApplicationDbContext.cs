using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Timetable.Models;

namespace Timetable.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string adminRoleName = "admin";
            string studentRoleName = "student";
            string professorRoleName = "professor";

            string adminLogin = "admin";
            string adminPassword = "123456";

            // добавляем роли
            Role adminRole = new Role { Id = 1, Type = adminRoleName };
            Role studentRole = new Role { Id = 2, Type = studentRoleName };
            Role professorRole = new Role { Id = 3, Type = professorRoleName };

            //добавляем администратора
            User adminUser = new User { Id = 1, Login = adminLogin, Password = adminPassword, IdRole = adminRole.Id };

            modelBuilder.Entity<Role>().HasData(new Role[] { adminRole, studentRole, professorRole });
            modelBuilder.Entity<User>().HasData(new User[] { adminUser });
            base.OnModelCreating(modelBuilder);
        }
    }
}