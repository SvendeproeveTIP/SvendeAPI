// Global using Models
global using LeMounAPI.Models;
// Global accesing Services folder
global using LeMounAPI.Services;
global using Microsoft.EntityFrameworkCore;
global using LeMounAPI.Data;
// Global access to Auto mapper
global using AutoMapper;
global using AutoMapper.QueryableExtensions;


// Global accesing lower tree of Services folder
using LeMounAPI.Services.UserService;
using LeMounAPI.Services.OrderService;
using LeMounAPI.Services.StatusService;
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
builder.Services.AddScoped<IModelService<UserModel>, UserService>();
builder.Services.AddScoped<IModelService<OrderModel>, OrderService>();
builder.Services.AddScoped<IModelService<UserStatusModel>, UserStatusService>();
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
