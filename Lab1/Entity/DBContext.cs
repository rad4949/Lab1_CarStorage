using Lab1.Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab1.Entity
{
    public class DBContext : DbContext
    {
        public DbSet<Brand> Brands { get; set; } = null!;
        public DbSet<Model> Models { get; set; } = null!;
        public DbSet<Equipment> Equipments { get; set; } = null!;
        public DBContext(DbContextOptions<DBContext> options)
        : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new DbInitializer(modelBuilder).Seed();


            modelBuilder
               .Entity<Equipment>()
               .HasOne(x => x.Model)
               .WithMany(x => x.Equipments)
               .HasForeignKey("ModelId")
               .IsRequired();

            modelBuilder
              .Entity<Model>()
              .HasOne(x => x.Brand)
              .WithMany(x => x.Models)
              .HasForeignKey("BrandId")
              .IsRequired();

            modelBuilder
              .Entity<Brand>()
              .ToTable("BrandCars");
        }
    }

}
