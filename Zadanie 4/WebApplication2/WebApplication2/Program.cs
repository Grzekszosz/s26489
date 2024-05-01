using System.Data.SqlClient;
using WebApplication2.Repositories;
using WebApplication2.Services;

//using WebApplication2.Repositories;
//using WebApplication2.Services;

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddControllers();
        builder.Services.AddScoped<IWareHouseRepository, WareHouseRepository>();
        builder.Services.AddScoped<IWareHouseService, WareHouseService>();
       
        var app = builder.Build();
       
// Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.MapControllers();
        }
        app.Run();

    }
}