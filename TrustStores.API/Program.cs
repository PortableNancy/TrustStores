using Microsoft.EntityFrameworkCore;
using TrustStores.Core.DTOs;
using TrustStores.Core.Interface;
using TrustStores.Core.Model;
using TrustStores.Core.Services;
using TrustStores.Infrastructure.Datastore;
using TrustStores.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<TrustStoreDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddAutoMapper(typeof(MapInitializer));
builder.Services.AddScoped<IUnitofWork, UnitOfWork>();
builder.Services.AddScoped<IProduct, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ProductDto>();
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
