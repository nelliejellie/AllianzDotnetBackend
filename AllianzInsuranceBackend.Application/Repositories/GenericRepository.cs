using AllianzInsuranceBackend.Application.Interfaces;
using AllianzInsuranceBackend.Domain.Entites;
using AllianzInsuranceBackend.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AllianzInsuranceBackend.Application.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _table;
        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }
        public async Task<T> AddAsync(T entity)
        {
            await _table.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T>? GetByIdAsync(int id)
        {
            return await _table.SingleAsync(entity => entity.Id == id);
        }

        public async Task<T>? GetSingleWithCondition(Expression<Func<T, bool>> expression)
        {
            return await _table.SingleAsync(expression);
        }

        public async Task UpdateAsync(T entity)
        {
            await Task.Run(() => _table.Update(entity));
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAsync()
        {
            var tables = await Task.FromResult(_table.AsNoTracking());
            return tables;
        }
    }
}
