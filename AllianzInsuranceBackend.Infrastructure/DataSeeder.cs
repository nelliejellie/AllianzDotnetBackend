using AllianzInsuranceBackend.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllianzInsuranceBackend.Infrastructure
{
    public class DataSeeder
    {
        

        public DataSeeder()
        {
           
        }

        public static async void SeedData(AppDbContext context)
        {
            var cars = new List<Car>
            {
                new Car
                {
                    Id = 1,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    CarMake = "Toyota",
                    Model = "Corolla"
                },
                new Car
                {
                    Id = 2,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    CarMake = "Toyota",
                    Model = "Camry"
                },
                new Car
                {
                    Id = 3,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    CarMake = "Honda",
                    Model = "Accord"
                },
                new Car
                {
                    Id = 4,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    CarMake = "Honda",
                    Model = "Civic"
                }
            };

            var premiums = new List<Premium>
            {
                new Premium
                {
                    Id = 1,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    BodyType = "Car",
                    PremiumPrice = 15000,
                },
                new Premium
                {
                    Id = 2,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    BodyType = "SUV",
                    PremiumPrice = 20000,
                },
                new Premium
                {
                    Id = 3,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    BodyType = "Truck",
                    PremiumPrice = 100000,
                },
                new Premium
                {
                    Id = 4,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    BodyType = "Van",
                    PremiumPrice = 20000,
                }
            };

            if (!context.Cars.Any())
            {
                context?.Cars.AddRangeAsync(cars);
                await context!.SaveChangesAsync();
            }
            if (!context.Premiums.Any())
            {
                context?.Premiums.AddRange(premiums);
                await context!.SaveChangesAsync();
            }

        }
    }
}
