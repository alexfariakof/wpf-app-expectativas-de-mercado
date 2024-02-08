using Microsoft.EntityFrameworkCore;
using Repository;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<RegisterContext>(options => 
options.UseSqlServer(
    builder.Configuration.GetConnectionString("SqlServerConnectionString"), 
    b => b.MigrationsAssembly("Expectativas_de_Mercado.Migrations")));

var app = builder.Build();
app.MapGet("/", () => "Migrations SqlServer Expectativas de Mercado!");
app.Run();