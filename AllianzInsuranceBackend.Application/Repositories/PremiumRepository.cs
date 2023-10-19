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
    public class PremiumRepository : GenericRepository<Premium>, IPremiumRepository
    {
        private readonly AppDbContext _context;

        public PremiumRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
