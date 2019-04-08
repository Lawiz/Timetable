using System.Linq;
using Timetable2.Context;
using Timetable2.Models;

namespace Timetable2.Controllers
{
    public static class AddAdmin
    {
        public static void Initialize(ApplicationDbContext context)
        {
            if (!context.Roles.Any())
            {
                Role admin = new Role { Type = "admin" };
                Role student = new Role { Type = "student" };
                Role professor = new Role { Type = "professor" };
                context.Roles.AddRange(admin);
                context.Roles.AddRange(student);
                context.Roles.AddRange(professor);
                context.SaveChanges();
            }

            if (!context.Users.Any())
            {
                User userAdmin = new User
                {
                    Login = "admin",
                    Password = "admin",
                    IdRole=1
                };
                context.Users.AddRange(userAdmin);
                context.SaveChanges();
            }

        }
    }
}
