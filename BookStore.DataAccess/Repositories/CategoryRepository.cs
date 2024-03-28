using BookStore.DataAccess.DataContext;
using BookStore.DataAccess.Entities;
using BookStore.DataAccess.Interfaces;
using BookStore.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DatabaseContext _databaseContext;
        public CategoryRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void AddAsync(Category category)
        {
            _databaseContext.Add(category);
         }

        public void DeleteAsync(Category category)
        {
            _databaseContext.Remove(category);
        }

        public async Task<List<Category>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _databaseContext
                         .Categories
                         .AsNoTracking()
                         .ToListAsync(cancellationToken);
        }

        public async Task<Category> GetBySomethingAsync(Func<Category, bool> predicate, CancellationToken cancellationToken)
        {
            var query = _databaseContext.Set<Category>().AsQueryable();
            foreach (var propertyInfo in typeof(Category).GetProperties())
            {
                var parameter = Expression.Parameter(typeof(Category), "x");
                var propertyAccess = Expression.Property(parameter, propertyInfo);
                var value = Expression.Constant(propertyInfo.GetValue(predicate.Target));
                var condition = Expression.Equal(propertyAccess, value);
                var lambda = Expression.Lambda<Func<Category, bool>>(condition, parameter);
                query = query.Where(lambda);
            }

            return await query
                      .AsNoTracking()
                      .FirstOrDefaultAsync(cancellationToken);
        }

        public void UpdateAsync(Category category)
        {
             _databaseContext.Update(category);
        }
    }
}
