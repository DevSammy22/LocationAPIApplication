using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationApi.Data.Repository.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> Table { get; }
        IQueryable<T> TableNoTracking { get; }

        Task DeleteAsync(Guid id);
        Task DeleteAsync(T entityToDelete);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAysnc(int id);
        Task<bool> InsertAsync(T entityToInsert);
        Task UpdateAsync(T entityToUpdate);
    }
}
