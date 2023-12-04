using BusinessLogisLayer.IServices;
using BusinessLogisLayer.Services;
using DataAccesLayer.EF;
using DataAccesLayer.EF.Models;
using DataAccesLayer.Interfaces;
using DataAccesLayer.Repos;
using EmployeeManagement.AuthFilters;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeConnection")));

builder.Services.AddScoped<IRepo<tblEmployee, int, bool>, EmployeeRepo>();
builder.Services.AddScoped<IRepo<tblEmployeeAttendance, int, bool>, EmployeeAttendanceRepo>();
builder.Services.AddScoped<IRepo<Token, int, Token>, TokenRepo>();
builder.Services.AddScoped<IRepo<User, string, bool>,  UserRepo>();
builder.Services.AddScoped<IAuth<User>, UserRepo>();

builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<Logged>();
builder.Services.AddScoped<IAuthService, AuthService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<Logged>();

app.MapControllers();

app.Run();
