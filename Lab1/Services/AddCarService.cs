using Lab1.Entity;
using Lab1.Interfaces;

namespace Lab1.Services
{
    public class AddCarService : IAddCarService
    {
        public void AddCar(HttpContext context, DBContext dBContext, Car car)
        {
            car.Model.Brand = car.Brand;
            car.Equipment.Model = car.Model;

            dBContext.Add(car.Brand);
            dBContext.Add(car.Model);
            dBContext.Add(car.Equipment);
            dBContext.SaveChanges();
        }
    }
}
