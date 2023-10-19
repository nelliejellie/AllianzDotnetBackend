using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllianzInsuranceBackend.Domain.Entites
{
    public class Car : BaseEntity
    {
        public string CarMake { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
    }
}
