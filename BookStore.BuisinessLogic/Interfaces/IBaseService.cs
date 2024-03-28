using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BusinessLogic.Interfaces 
{
    public interface IBaseService<T> where T : class
    {
        Task<T> AddAsync(T entity, CancellationToken cancellationToken);
        Task<T> DeleteAsync(T entity,CancellationToken cancellationToken);
        Task<T> UpdateAsync(T entity, CancellationToken cancellationToken);
        Task<List<T>> GetAllAsync(CancellationToken cancellationToken);
        Task<T> GetByIdAsync(T entity, CancellationToken cancellationToken);
    }
}
