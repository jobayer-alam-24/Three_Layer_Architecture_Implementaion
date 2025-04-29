using CORE.DAL.Interfaces;
using INFRASTRUCTURE.BLL.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.BLL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AppDbContext _context;
        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteByRangeAsync(IEnumerable<T> entities)
        {
            _context.Set<IEnumerable<T>>().RemoveRange(entities);
            await SaveChangesAsync();
            return true;
        }

        public Task DisposeAsync()
        {
            _context.DisposeAsync();
            SaveChangesAsync();
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<T>> GetAllListsAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllListsByPredicateAsync(Func<T, bool> predicate)
        {
            return await Task.Run(() =>
            {
                return _context.Set<T>().Where(predicate).ToList();
            });
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> GetByIdAsync(string id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> GetByPredicateAsync(Func<T, bool> predicate)
        {
            return await Task.Run(() =>
            {
                return _context.Set<T>().FirstOrDefault(predicate);
            });
        }

        public async Task<int?> GetCountByPredicateAsync(Func<T, bool> predicate)
        {
            var count = _context.Set<T>().Where(predicate).Count();
            return await Task.FromResult<int?>(count);
        }

        public Task SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await SaveChangesAsync();
            return entity;
        }
    }
}
