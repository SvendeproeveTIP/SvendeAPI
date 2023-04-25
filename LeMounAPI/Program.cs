// Global using Models
global using LeMounAPI.Models;
// Global accesing Services folder
global using LeMounAPI.Repositories;
global using Microsoft.EntityFrameworkCore;
global using LeMounAPI.Data;
// Global access to Auto mapper
global using AutoMapper;
global using AutoMapper.QueryableExtensions;
// Global access to Exceptions
using LeMounAPI.Repositories.CustomExceptions;
// Global accesing lower tree of Services folder
using LeMounAPI.Repositories.UserRepository;
using LeMounAPI.Repositories.OrderRepository;
using LeMounAPI.Repositories.UserStatusRepository;
using LeMounAPI.Repositories.UserRoleRepository;
using LeMounAPI.Repositories.VehicleRepository;
using LeMounAPI.Repositories.VehicleTypeRepository;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

// Register DBContext with connection string.
var connString = builder.Configuration["ConnectionStrings:Lemoun"];
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseMySql(connString, ServerVersion.AutoDetect(connString));
});

// Registering the Services
builder.Services.AddScoped<IModelRepository<OrderModel>, OrderRepository>();
builder.Services.AddScoped<IModelRepository<UserModel>, UserRepository>();
builder.Services.AddScoped<IModelRepository<UserStatusModel>, UserStatusRepository>();
builder.Services.AddScoped<IModelRepository<UserRoleModel>, UserRoleRepository>();
builder.Services.AddScoped<IModelRepository<VehicleModel>, VehicleRepository>();
builder.Services.AddScoped<IModelRepository<VehicleTypeModel>, VehicleTypeRepository>();
// Registering the DBContext
//builder.Services.AddDbContext<DataContext>();

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
