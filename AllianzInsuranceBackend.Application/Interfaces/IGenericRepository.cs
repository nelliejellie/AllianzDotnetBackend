using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AllianzInsuranceBackend.Application.Interfaces
{
    public interface IGenericRepository<T>
    {
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task<T>? GetByIdAsync(int id);
        Task<T>? GetSingleWithCondition(Expression<Func<T, bool>> expression);
        Task<IEnumerable<T>> GetAsync();
    }
}
