using Lab1.Entity;
using Lab1.Entity.Models;
using Lab1.Interfaces;
using Microsoft.AspNetCore.Routing.Template;

namespace Lab1.Services
{
    public class GetCarsService : IGetCarsService
    {
        public IEnumerable<Car> GetCars(HttpContext context, DBContext dBContext)
        {

            IEnumerable<Car> cars = from equipment in dBContext.Set<Equipment>()
                       from model in dBContext.Set<Model>().Where(model => model.Id == equipment.ModelId).DefaultIfEmpty()
                       from brand in dBContext.Set<Brand>().Where(brand => brand.Id == model.BrandId).DefaultIfEmpty()
                       select new Car
                       {
                           Equipment = equipment,
                           Model = model,
                           Brand = brand
                       };

            return cars;
        }
    }
}
