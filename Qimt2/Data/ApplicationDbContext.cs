using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Qimt2.Data;

namespace Qimt2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Contactus> Contacts { get; set; }
        public virtual DbSet<Report> Reports { get; set; }
        public DbSet<Qimt2.Data.Employee> Employee { get; set; } = default!;
        public DbSet<Qimt2.Data.Jobs> Jobs { get; set; } = default!;
        public DbSet<Qimt2.Data.Service> Service { get; set; } = default!;

    }
}