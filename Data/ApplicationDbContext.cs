using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SIMS.Models;

namespace SIMS.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<SIMS.Models.Semesters> Semesters { get; set; } = default!;
        public DbSet<SIMS.Models.Departments> Departments { get; set; } = default!;
        public DbSet<SIMS.Models.Roles> Roles { get; set; } = default!;
        public DbSet<SIMS.Models.Majors> Majors { get; set; } = default!;
        public DbSet<SIMS.Models.Subjects> Subjects { get; set; } = default!;
    }
}
