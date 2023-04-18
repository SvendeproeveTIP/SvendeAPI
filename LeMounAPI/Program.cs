// Global using Models
global using LeMounAPI.Models;
// Global accesing Services folder
global using LeMounAPI.Services;
global using Microsoft.EntityFrameworkCore;
global using LeMounAPI.Data;

// Global accesing lower tree of Services folder
using LeMounAPI.Services.UserService;
using LeMounAPI.Services.OrderService;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Registering the Services
builder.Services.AddScoped<IModelService<User>, UserService>();
builder.Services.AddScoped<IModelService<Order>, OrderService>();
// Registering the DBContext
builder.Services.AddDbContext<DataContext>();

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
