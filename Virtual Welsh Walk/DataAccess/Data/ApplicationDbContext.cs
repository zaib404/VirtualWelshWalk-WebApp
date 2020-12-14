using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Virtual_Welsh_Walk.DataAccess.Models;

namespace Virtual_Welsh_Walk.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {

        public DbSet<People> PeoplesTBL { get; set; }

        public DbSet<VirtualWalk> VirtualWalksTBL { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>().
                Ignore(u => u.PhoneNumber)
                .Ignore(u => u.PhoneNumberConfirmed);
        }
    }
}
