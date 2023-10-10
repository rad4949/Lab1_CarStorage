using Lab1.Entity;
using Lab1.Entity.Models;
using Lab1.Interfaces;

namespace Lab1.Services
{
    public class ShowCarService : IShowTableService
    {
        public string ShowTable(HttpContext context, DBContext dBContext)
        {
            var cars = from equipment in dBContext.Set<Equipment>()
                      from model in dBContext.Set<Model>().Where(model => model.Id == equipment.ModelId).DefaultIfEmpty()
                      from brand in dBContext.Set<Brand>().Where(brand => brand.Id == model.BrandId).DefaultIfEmpty()
                      select new
                      {
                          Equipment = equipment,
                          Model = model,
                          Brand = brand
                      };

            context.Response.ContentType = "text/html; charset=utf-8";
            var stringBuilder = new System.Text.StringBuilder("<h3>Brands</h3><table>");
            stringBuilder.Append("<tr> <td><h3>Id   </h3></td> <td><h3>Brand name   </h3></td> <td><h3>Model name   </h3></td>" +
                " <td><h3>Country   </h3></td> <td><h3>Fuel type   </h3></td> <td><h3>Model year   </h3></td> <td><h3>Price   </h3></td> </tr>");
            foreach (var item in cars)
            {
                stringBuilder.Append($"<tr><td>{item.Equipment.Id}</td> <td>{item.Brand.NameBrand}</td> <td>{item.Model.NameModel}</td>" +
                    $"<td>{item.Brand.ProducingCountry}</td> <td>{item.Equipment.FuelType}</td> <td>{item.Equipment.ModelYear}</td>" +
                    $"<td>{item.Equipment.PriceEquipment}</td> </tr>");
            }
            stringBuilder.Append("</table>");
            return stringBuilder.ToString();
        }
    }
}
