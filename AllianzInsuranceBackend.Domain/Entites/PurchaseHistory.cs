using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllianzInsuranceBackend.Domain.Entites
{
    public class PurchaseHistory : BaseEntity
    {
        public decimal AmountPaid { get; set; }
        public string BodyType { get; set; } = string.Empty;
        public bool PaymentSuccessful { get; set; }
        public int VehicleId { get; set; }
    }
}
