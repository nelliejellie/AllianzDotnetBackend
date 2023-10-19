using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllianzInsuranceBackend.Domain.Entites
{
    public class Premium : BaseEntity
    {
        public string BodyType { get; set; } = string.Empty;
        public decimal PremiumPrice { get; set; }
    }
}
