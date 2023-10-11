using Lab1.Entity;

namespace Lab1.Interfaces
{
    public interface IAddCarService
    {
        void AddCar(HttpContext context, DBContext dBContext, Car car);
    }
}
