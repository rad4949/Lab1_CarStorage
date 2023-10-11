using Lab1.Entity;

namespace Lab1.Interfaces
{
    public interface IGetCarsService
    {
        IEnumerable<Car> GetCars(HttpContext context, DBContext dBContext);
    }
}
