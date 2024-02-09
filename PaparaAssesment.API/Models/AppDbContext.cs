using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PaparaAssesment.API.Models.Flats;
using PaparaAssesment.API.Models.Payments;
using PaparaAssesment.API.Models.Residents;

namespace PaparaAssesment.API.Models
{
    public class AppDbContext(DbContextOptions<AppDbContext> options)
        : IdentityDbContext<Resident, ResidentUser, int>(options)
    {

        public DbSet<Flat> Flats { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Resident> Residents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

        
    }
