using AllianzInsuranceBackend.Application.Interfaces;
using AllianzInsuranceBackend.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllianzInsuranceBackend.Application.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;

        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<ApiResponse<List<Car>>> GetAllCars()
        {
            try
            {
                var cars = await _carRepository.GetAsync();
                return new ApiResponse<List<Car>>
                {
                    Data = cars.ToList(),
                    Success = true,
                    Message = "all available premiums"
                };
            }
            catch (Exception)
            {
                return new ApiResponse<List<Car>>
                {
                    Success = false,
                    Message = "An error occurred"
                };
                throw;
            }
        }
    }
}
