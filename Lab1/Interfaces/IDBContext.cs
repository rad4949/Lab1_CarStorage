using Lab1.Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab1.Interfaces
{
    public interface IDBContext
    {
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Model> Models { get; set; } 
        public DbSet<Equipment> Equipments { get; set; }
    }
}
