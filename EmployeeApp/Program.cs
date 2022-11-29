using EmployeeApp.Models;
using EmployeeApp.Services.Interfaces;
using EmployeeApp.Services.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


var allowedOrigins = "_allowedOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowedOrigins,
                policy =>
                {
                    policy.WithOrigins("http://localhost:3000");
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                });
});

string? db_connection = builder.Configuration.GetConnectionString("EmployeeDbConnection");

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(db_connection));
builder.Services
    .AddControllers(options => options.EnableEndpointRouting = false)
    .AddNewtonsoftJson();

builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddTransient<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddTransient<IFileCustomFunctions, CustomFileMethods>();


var app = builder.Build();

app.UseRouting();

app.UseStaticFiles();

app.UseCors(allowedOrigins);

app.MapControllers();

app.Run();
