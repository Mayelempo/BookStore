using BookStore.DataAccess.DataContext;
using BookStore.DataAccess.Interfaces;
using BookStore.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BookStore.DataAccess.Repositories
{
    public class CollectionRepository : ICollectionRepository
    {
        private readonly DatabaseContext _databaseContext;
        public CollectionRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void AddAsync(Collection collection) 
        { 
            _databaseContext.Add(collection);
           
        }

        public void DeleteAsync(Collection collection)
        {
            _databaseContext.Remove(collection);
        }

        public async Task<List<Collection>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _databaseContext
                           .Collections
                           .AsNoTracking()
                           .ToListAsync(cancellationToken);
        }

        public  async Task<Collection> GetBySomethingAsync(Func<Collection, bool> predicate, CancellationToken cancellationToken)
        {
            var query = _databaseContext.Set<Collection>().AsQueryable();
            foreach (var propertyInfo in typeof(Collection).GetProperties())
            {
                var parameter = Expression.Parameter(typeof(Collection), "x");
                var propertyAccess = Expression.Property(parameter, propertyInfo);
                var value = Expression.Constant(propertyInfo.GetValue(predicate.Target));
                var condition = Expression.Equal(propertyAccess, value);
                var lambda = Expression.Lambda<Func<Collection, bool>>(condition, parameter);
                query = query.Where(lambda);
       
            }

            return await query
                         .AsNoTracking()
                         .FirstOrDefaultAsync(cancellationToken);
        }
         
        public void UpdateAsync(Collection collection)
        {
            _databaseContext.Update(collection);
        }
    
    }
}
