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
    public class PurchaseHistoryRepository : GenericRepository<PurchaseHistory>, IPurchaseHistoryRepository
    {
        private readonly AppDbContext _context;
        public PurchaseHistoryRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
