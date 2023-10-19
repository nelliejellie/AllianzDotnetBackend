using AllianzInsuranceBackend.Application.Interfaces;
using AllianzInsuranceBackend.Domain.DTO;
using AllianzInsuranceBackend.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllianzInsuranceBackend.Application.Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IUserRepository _userRepository;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IPurchaseHistoryRepository _purchaseHistoryRepository;

        public PurchaseService(IUserRepository userRepository,
            IVehicleRepository vehicleRepository,
            IPurchaseHistoryRepository purchaseHistoryRepository)
        {
            _userRepository = userRepository;
            _vehicleRepository = vehicleRepository;
            _purchaseHistoryRepository = purchaseHistoryRepository;
        }

        public async Task<ApiResponse<PurchaseDto>> CreateOrder(PurchaseDto purchase)
        {
            try
            {
                var dob = DateTime.TryParseExact(purchase.DOB, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result);
                if (purchase.IsSuccessful)
                {
                    var user = new User
                    {
                        FirstName = purchase.FirstName,
                        LastName = purchase.LastName,
                        Email = purchase.Email,
                        DOB = result.ToUniversalTime(),
                        PhoneNumber = purchase.PhoneNumber,
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow,
                    };

                    var savedUser = await _userRepository.AddAsync(user);
                    var vehicle = new Vehicle
                    {
                        BodyType = purchase.BodyType,
                        VehicleMake = purchase.VehicleMake,
                        VehicleModel = purchase.VehicleModel,
                        RegisterationNumber = purchase.RegisterationNumber,
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow,
                        UserId = savedUser.Id,
                    };
                    var savedVehicle = await _vehicleRepository.AddAsync(vehicle);
                    var purchaseData = new PurchaseHistory
                    {
                        AmountPaid = purchase.AmountPaid,
                        BodyType = purchase.BodyType,
                        PaymentSuccessful = true,
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow,
                        VehicleId = savedVehicle.Id,
                    };

                    var savedPurchase = await _purchaseHistoryRepository.AddAsync(purchaseData);
                }

                return new ApiResponse<PurchaseDto>
                {
                    Data = purchase,
                    Success = true,
                    Message = "Your purchase was successful"
                };
                
            }
            catch (Exception)
            {
                return new ApiResponse<PurchaseDto>
                {
                    Success = false,
                    Message = "Your purchase was not successful"
                };
                throw;
            }
        }
    }
}
