using Microsoft.EntityFrameworkCore;
using WebApplication4.Context;
using WebApplication4.Models;

public class Program
{
    public static void Main(string[] args)
    {
        var bulider = WebApplication.CreateBuilder(args);
        bulider.Services.AddEndpointsApiExplorer();
        bulider.Services.AddSwaggerGen();
        bulider.Services.AddControllers();
        bulider.Services.AddDbContext<APBDContext>(options =>
                        options.UseSqlServer(bulider.Configuration.GetConnectionString("DefaultConnection")));
//        bulider.Services.AddScoped<>()
        var app = bulider.Build();
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.MapControllers();

        app.Run();
        
    }
}