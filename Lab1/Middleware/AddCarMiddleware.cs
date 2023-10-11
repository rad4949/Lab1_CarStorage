using Lab1.Entity;
using Lab1.Interfaces;

namespace Lab1.Middleware
{
    public class AddCarMiddleware
    {
        RequestDelegate next;

        public AddCarMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context, DBContext dbContext, IHost application)
        {
            context.Response.ContentType = "text/html; charset=utf-8";


            if (context.Request.Path == "/addcar")
            {
                var addCarService = application.Services.GetService<IAddCarService>();
                var form = context.Request.Form;

                Car car = new Car();

                car.Brand.NameBrand = form["nameBrand"];
                car.Model.NameModel = form["nameModel"];
                car.Brand.ProducingCountry = form["producingCountry"];
                car.Model.BodyType = form["bodyType"];
                car.Model.Guarantee = form["guarantee"];

                car.Equipment.DriverType = form["driverType"];
                car.Equipment.EngineCapacity = float.Parse(form["engineCapacity"]);
                car.Equipment.FuelType = form["fuelType"];
                car.Equipment.ModelYear = int.Parse(form["modelYear"]);
                car.Equipment.PriceEquipment = decimal.Parse(form["priceEquipment"]);

                addCarService.AddCar(context, dbContext, car);

                context.Response.Redirect("/cars"); ;

            }
            else
            {
                if (context.Request.Path == "/form")
                {
                    await context.Response.SendFileAsync("html/AddCar.html");
                }
                else
                {
                    await next.Invoke(context);
                }
            }

        }
    }
}
