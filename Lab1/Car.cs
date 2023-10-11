using Lab1.Entity.Models;

namespace Lab1
{
    public class Car
    {
        public Equipment Equipment { get; set; } = new Equipment();
        public Model Model { get; set; } = new Model();
        public Brand Brand { get; set; } = new Brand();
    }
}
