using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Interfaces
{
    public interface IBaseRepository<T> 
    {
        void AddAsync(T entity);
        void UpdateAsync(T entity);
        void DeleteAsync(T entity);
        Task<List<T>> GetAllAsync(CancellationToken cancellationToken);
        Task<T> GetBySomethingAsync(Func<T, bool> predicate, CancellationToken cancellationToken); 
    }
}
