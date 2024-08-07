
using Contract.Interfaces.IServices;
using Application.MappingProfiles;
using Application.Services;
using Microsoft.OpenApi.Models;

namespace WebResApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AutoMapper", Version = "v1" });
            });

            builder.Services.AddScoped<IDrinkService, DrinkSevice>();
            builder.Services.AddScoped<IFoodService, FoodService>();

            builder.Services.AddAutoMapper(typeof(DrinkMappingProfile));
            builder.Services.AddAutoMapper(typeof(FoodMappingProfile));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "AutoMapper v1");
                });
            }


            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
