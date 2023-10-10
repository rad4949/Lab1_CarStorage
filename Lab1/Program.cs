using Lab1.Entity;
using Lab1.Interfaces;
using Lab1.Middleware;
using Lab1.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DBContext>(options => options.UseSqlServer(connection));

builder.Services.AddScoped<IDBContext, DBContext>();

builder.Services.AddTransient<IShowTableService, ShowCarService>();

var app = builder.Build();

app.UseMiddleware<CarsListMiddleware>();

app.Run(async (context) => await context.Response.WriteAsync("Hello IGOR"));

app.Run();
