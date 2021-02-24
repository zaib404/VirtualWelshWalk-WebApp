using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VirtualWelshWalk.DataAccess.Models;

namespace VirtualWelshWalk.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {

        public DbSet<People> PeoplesTBL { get; set; }

        public DbSet<VirtualWalk> VirtualWalksTBL { get; set; }

        public DbSet<VirtualMilestone> VirtualMilestonesTBL { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Ignore these columns
            builder.Entity<User>().
                Ignore(u => u.PhoneNumber)
                .Ignore(u => u.PhoneNumberConfirmed);
        }
    }
}
