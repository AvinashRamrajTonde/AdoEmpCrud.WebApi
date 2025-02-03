
using AdoEmpCrud.WebApi.Data;
using AdoEmpCrud.WebApi.Data.Core;
using AdoEmpCrud.WebApi.Helpers;
using Scalar.AspNetCore;

namespace AdoEmpCrud.WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();
        
        builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

        DatabaseHelper.EnsureDatabase();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.MapScalarApiReference(); 
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
