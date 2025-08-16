using Microsoft.EntityFrameworkCore;
using RepositoryStore.Data;
using RepositoryStore.Repositories;
using RepositoryStore.Repositories.Abstractions;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(connectionString);
});

builder.Services.AddTransient<IProductRepository, ProductRepository>();

var app = builder.Build();

app.MapGet("/v1/products", async (IProductRepository repository) => await repository.GetAllAsync(0,30));

app.MapPost("/v1/products", (AppDbContext context) => "Hello World!");
app.MapPut("/v1/products", (AppDbContext context) => "Hello World!");
app.MapDelete("/v1/products", (AppDbContext context) => "Hello World!");

app.Run();
