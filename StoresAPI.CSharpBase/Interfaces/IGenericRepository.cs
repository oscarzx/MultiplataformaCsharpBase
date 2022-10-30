using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace StoresAPI.CSharpBase.Interfaces;

public interface IGenericRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<EntityEntry> PostAsync(T value);
    Task<T> GetAsync(object id);
    Task DeleteAsync(object id);
}
