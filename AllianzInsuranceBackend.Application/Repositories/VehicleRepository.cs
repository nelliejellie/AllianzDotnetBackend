using AllianzInsuranceBackend.Application.Interfaces;
using AllianzInsuranceBackend.Domain.Entites;
using AllianzInsuranceBackend.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllianzInsuranceBackend.Application.Repositories
{
    public class VehicleRepository : GenericRepository<Vehicle>, IVehicleRepository
    {
        private readonly AppDbContext _context;
        public VehicleRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
