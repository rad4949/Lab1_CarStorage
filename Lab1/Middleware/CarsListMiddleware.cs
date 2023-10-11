using Lab1.Entity;
using Lab1.Entity.Models;
using Lab1.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace Lab1.Middleware
{
    public class CarsListMiddleware
    {
        RequestDelegate next;

        public CarsListMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context, DBContext dbContext, IHost application)
        {
            if (context.Request.Path == "/cars")
            {              
                var carService = application.Services.GetService<IGetCarsService>();

                context.Response.ContentType = "text/html; charset=utf-8";
                var stringBuilder = new System.Text.StringBuilder("<h3>Cars</h3><table>");
                stringBuilder.Append("<tr> <td><h3>#   </h3></td> <td><h3>Brand name   </h3></td> <td><h3>Model name   </h3></td>" +
                    " <td><h3>Country   </h3></td> <td><h3>Fuel type   </h3></td> <td><h3>Model year   </h3></td> <td><h3>Price   </h3></td> </tr>");
                int i = 1;
                foreach (var item in carService.GetCars(context, dbContext))
                {
                    stringBuilder.Append($"<tr><td>{i}</td> <td>{item.Brand.NameBrand}</td> <td>{item.Model.NameModel}</td>" +
                        $"<td>{item.Brand.ProducingCountry}</td> <td>{item.Equipment.FuelType}</td> <td>{item.Equipment.ModelYear}</td>" +
                        $"<td>{item.Equipment.PriceEquipment}</td> </tr>");
                    i++;
                }
                
                stringBuilder.Append("</table>");

                await context.Response.WriteAsync(stringBuilder.ToString());                
            }
            else
            {
                await next.Invoke(context);
            }          
        }
    }
}
