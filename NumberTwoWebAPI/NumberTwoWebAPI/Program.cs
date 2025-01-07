
using Contracts;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Services;

namespace NumberTwoWebAPI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<ICountryService,CountryService>();

            builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("InMemoryDatabase"));

            var serviceProvider = builder.Services.BuildServiceProvider();
            var context = (AppDbContext)serviceProvider.GetService(typeof(AppDbContext));

            if (context is not null)
            {
                await DataSeeder.LoadData(context);
            }

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
