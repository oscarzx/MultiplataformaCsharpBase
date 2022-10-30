using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using StoresAPI.CSharpBase.Interfaces;

namespace StoresAPI.CSharpBase.Repositories.Base
{
    public abstract class GenericRepository<T, TContext> : IGenericRepository<T>, IDisposable
        where T : class
        where TContext : DbContext
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(TContext context)
        => (_dbContext, _dbSet) = (context, context.Set<T>());

        public async Task DeleteAsync(object id)
        {
            var result = await _dbSet.FindAsync(id);
            if(result is not null)
            {
                _dbContext.Remove(result);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var items = await _dbSet.ToListAsync();
            return items;
        }

        public async Task<T> GetAsync(object id)
        {
            var result = await _dbSet.FindAsync(id);
            return result!;
        }

        public async Task<T> PostAsync(T value)
        {
            var entity = await _dbSet.AddAsync(value);
            await _dbContext.SaveChangesAsync();
            return entity.Entity;
        }

        public void Dispose()
        {
            _dbContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
