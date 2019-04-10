using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Timetable2.Context;
using Timetable2.Models;

namespace Timetable2.Controllers
{
    public class HomeController : Controller
    {
        readonly ApplicationDbContext db;

        public HomeController(ApplicationDbContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            return View("Index");
        }

        [Authorize(Roles = "admin")]
        public IActionResult IndexAdmin()
        {
            return View("IndexAdmin");
        }

        [Authorize(Roles = "student")]
        public IActionResult IndexStudent()
        {
            return View("IndexStudent");
        }

        [Authorize(Roles = "professor")]
        public IActionResult IndexProfessor()
        {
            return View("IndexProfessor");
        }
    }
}
