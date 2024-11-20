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

            // swagger
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // build App
            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
                    c.RoutePrefix = string.Empty;
                });
            }

            app.UseCors("MyCors");
            app.MapControllers();
            app.Run();
        }
    }
}
