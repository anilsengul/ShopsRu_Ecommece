using StoresRU_API.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped < IGeneric< Invoices>,GenericRepository < Invoices >> ();
builder.Services.AddScoped<IGeneric<Members>, GenericRepository<Members>>();
builder.Services.AddScoped<IGeneric<Products>, GenericRepository<Products>>();
builder.Services.AddScoped<IGeneric<Orders>, GenericRepository<Orders>>();
builder.Services.AddScoped<IGeneric<OrderDetails>, GenericRepository<OrderDetails>>();
builder.Services.AddScoped<IBasket, BasketRepository>();
builder.Services.AddMvc().SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0);
builder.Services.AddSession();
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
app.UseSession();
app.Run();
