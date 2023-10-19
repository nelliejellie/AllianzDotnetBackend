using AllianzInsuranceBackend.Application.Interfaces;
using AllianzInsuranceBackend.Application.Repositories;
using AllianzInsuranceBackend.Application.Services;
using AllianzInsuranceBackend.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AllianzInsuranceBackend.Presentation
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
            builder.Services.AddSwaggerGen();

            // dbconfig
            if (builder.Environment.IsDevelopment())
                builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("Default")));
            else
                builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("Prod")));

            // db config ends

            // repo config
            builder.Services.AddScoped<IUserRepository,UserRepository>();
            builder.Services.AddScoped<IVehicleRepository,VehicleRepository>();
            builder.Services.AddScoped<IPremiumRepository,PremiumRepository>();
            builder.Services.AddScoped<IPurchaseHistoryRepository,PurchaseHistoryRepository>();
            builder.Services.AddScoped<ICarRepository,CarRepository>();
            // repo end


            // app service
            builder.Services.AddScoped<ICarService,CarService>();
            builder.Services.AddScoped<IPremiumService,PremiumService>();
            builder.Services.AddScoped<IPurchaseService,PurchaseService>();
            // app service end

            //cors config
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(
                    "_myAllowAnyOrigin", policy =>
                    {
                        policy.AllowAnyOrigin();
                        policy.AllowAnyHeader();
                        policy.AllowAnyMethod();
                    });
            });

            // cors config end




            var app = builder.Build();

            using (var servicescope = app.Services.CreateScope())
            {
                var services = servicescope.ServiceProvider;
                var _context = services.GetRequiredService<AppDbContext>();

                _context.Database.Migrate();
                DataSeeder.SeedData(_context).Wait();
                
               

            }

            // Configure the HTTP request pipeline.
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseCors("_myAllowAnyOrigin");
            app.UseHttpsRedirection();

            app.UseAuthorization();

            
            app.MapControllers();

            app.Run();
        }
    }
}