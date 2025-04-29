using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.DAL.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllListsAsync();
        Task<IEnumerable<T>> GetAllListsByPredicateAsync(Func<T, bool> predicate);
        Task<T> GetByIdAsync(int id);
        Task<T> GetByIdAsync(string id);
        Task<T> GetByPredicateAsync(Func<T, bool> predicate);
        Task<int?> GetCountByPredicateAsync(Func<T, bool> predicate);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<bool> DeleteAsync(T entity);
        Task<bool> DeleteByRangeAsync(IEnumerable<T> entities);
        Task SaveChangesAsync();
        Task DisposeAsync();
    }
}
