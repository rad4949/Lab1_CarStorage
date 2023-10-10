using Lab1.Entity;
using Lab1.Interfaces;
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
            if (context.Request.Path == "/brands")
            {
                var timeService = application.Services.GetService<IShowTableService>();
                await context.Response.WriteAsync(timeService?.ShowTable(context, dbContext));
            }
            else
            {
                await next.Invoke(context);
            }          
        }
    }
}
