using AplicatieClinicaAnalize.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AplicatieClinicaAnalize.Data
{
    public class AppDbContext:IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor_Analiza>().HasKey(da => new
            {
                da.DoctorId,
                da.AnalizaId
            });

            modelBuilder.Entity<Doctor_Analiza>().HasOne(a => a.Analiza).WithMany(da => da.Doctori_Analize).HasForeignKey(a => a.AnalizaId);
            modelBuilder.Entity<Doctor_Analiza>().HasOne(a => a.Doctor).WithMany(da => da.Doctori_Analize).HasForeignKey(a => a.DoctorId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Doctor> Doctori { get; set; }
        public DbSet<Analiza> Analize { get; set; }
        public DbSet<Doctor_Analiza> Doctori_Analize { get; set; }
        public DbSet<Clinica> Clinici { get; set; }

        //Orders related tables
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

    }
}
