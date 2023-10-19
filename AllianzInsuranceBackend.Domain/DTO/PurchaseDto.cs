using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllianzInsuranceBackend.Domain.DTO
{
    public class PurchaseDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string DOB { get; set; }
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string VehicleMake { get; set; } = string.Empty;
        public string VehicleModel { get; set; } = string.Empty;
        public string BodyType { get; set; } = string.Empty;
        public string RegisterationNumber { get; set; } = string.Empty;
        public decimal AmountPaid { get; set; }
        public bool IsSuccessful { get; set; } = false;

    }
}
