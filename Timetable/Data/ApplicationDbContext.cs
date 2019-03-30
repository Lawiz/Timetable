using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Timetable.Models;



namespace Timetable.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }
    }
}


//optionsBuilder.UseSqlServer(@"Server=DESKTOP-NIMN87C;Database=TimetableDB;Trusted_Connection=True;");