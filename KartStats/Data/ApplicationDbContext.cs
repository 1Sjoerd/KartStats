using KartStats.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KartStats.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        private readonly IConfiguration _config;

        public ApplicationDbContext(DbContextOptions options, IConfiguration config) : base(options)
        {
            _config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("ApplicationDbContext"));
        }

        public DbSet<UserAdminClass> UserAdmin { get; set; }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }
    }
}
