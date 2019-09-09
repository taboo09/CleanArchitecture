using System.Collections.Generic;
using System.Threading.Tasks;

namespace Clean.Data.Interfaces
{
    public interface IAppRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync();
        T Add(T entity);
        void Delete(T entity);
        Task SaveAllAsync();
    }
}