using AppointmentBooking.Common.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentBooking.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Appointment> Appointment { get; set; }
        public DbSet<AgencyConfiguration> Configuration { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>()
               .HasKey(a => a.Id);

            modelBuilder.Entity<AgencyConfiguration>()
                .HasKey(a => a.Id);
        }
    }
}
