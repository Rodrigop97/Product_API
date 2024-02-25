using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Products_API.DTOs;
using Products_API.Model;
using Products_API.Repository;
using Products_API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddKeyedScoped<ICommonService<ProductDto, ProductEditDto>, ProductService>("productService");
builder.Services.AddKeyedScoped<ICommonService<BrandDto, BrandDto>, BrandService>("brandService");

// Repository
builder.Services.AddKeyedScoped<IRepository<Product>, ProductRepository>("productRepository");
builder.Services.AddKeyedScoped<IRepository<Brand>, BrandRepository>("brandRepository");

// Entity Framework
builder.Services.AddDbContext<StoreContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("StoreConnection"));
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
