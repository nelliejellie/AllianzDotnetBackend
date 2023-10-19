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
    public class CarRepository : GenericRepository<Car>, ICarRepository
    {
        private readonly AppDbContext _context;

        public CarRepository(AppDbContext context):base(context)
        {
            _context = context;
        }
    }
}
