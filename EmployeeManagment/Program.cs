using EmployeeManagment.Data;
using EmployeeManagment.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;


namespace EmployeeManagment
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // before building the app
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<AppDbContext>(
                options => options.UseInMemoryDatabase("EmployeeDb")
                );

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("MyCors", builder =>
                {
                    builder.WithOrigins("http://localhost:4200")
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });

            // add the employee repository to the DI (Dependency-Injection)
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddControllers();

            // build App
            var app = builder.Build();

            app.UseCors("MyCors");

            app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}
