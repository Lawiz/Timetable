using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Timetable.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }


        public int IdRole { get; set; }
        [ForeignKey("IdRole")]
        public Role Role { get; set; }
    }
}
