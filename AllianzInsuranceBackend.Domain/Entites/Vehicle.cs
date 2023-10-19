using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllianzInsuranceBackend.Domain.Entites
{
    public class Vehicle : BaseEntity
    {
        public string VehicleMake { get; set; } = string.Empty;
        public string VehicleModel { get; set; } = string.Empty;
        public string BodyType { get; set; } = string.Empty;
        public string RegisterationNumber { get; set; } = string.Empty;
        public int UserId { get; set; }
    }
}
