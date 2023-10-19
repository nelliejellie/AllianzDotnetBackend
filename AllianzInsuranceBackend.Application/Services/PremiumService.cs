using AllianzInsuranceBackend.Application.Interfaces;
using AllianzInsuranceBackend.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllianzInsuranceBackend.Application.Services
{
    public class PremiumService : IPremiumService
    {
        private readonly IPremiumRepository _premiumRepository;

        public PremiumService(IPremiumRepository premiumRepository)
        {
            _premiumRepository = premiumRepository;
        }

        public async Task<ApiResponse<List<Premium>>> GetAllPremium()
        {
            try
            {
                var premiums =  await _premiumRepository.GetAsync();
                return new ApiResponse<List<Premium>>
                {
                    Data = premiums.ToList(),
                    Success = true,
                    Message = "all available premiums"
                };
            }
            catch (Exception)
            {
                return new ApiResponse<List<Premium>>
                {
                    Success = false,
                    Message = "An error occurred"
                };
                throw;
            }
        }
    }
}
