using Lab1.Entity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DBContext>(options => options.UseSqlServer(connection));

var app = builder.Build();

app.MapGet("/", (DBContext db) => db.Brands.ToList());

app.Run();
