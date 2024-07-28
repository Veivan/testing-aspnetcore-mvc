using EmployeesApp.Contracts;
using EmployeesApp.Extensions;
using EmployeesApp.Models;
using EmployeesApp.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<EmployeeContext>(opts =>
//opts.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection")));
opts.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=CatalogServ;Trusted_Connection=True;"));
//opts.UseInMemoryDatabase("CatalogService"));


builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();


builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Employees}/{action=Index}/{id?}");

app.MigrateDatabase();
app.Run();

public partial class Program { }
