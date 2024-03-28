using BookStore.DataAccess.DataContext;
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
    public class LikeRepository : ILikeRepository
    {
        private readonly DatabaseContext _databaseContext;
        public LikeRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void AddAsync(Like like) 
        { 
            _databaseContext.Add(like);
        }

        public void DeleteAsync(Like like)
        {
            _databaseContext.Remove(like);
        }


        public async Task<List<Like>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _databaseContext
                         .Likes
                         .AsNoTracking() 
                         .ToListAsync(cancellationToken);
        }

        public async Task<Like> GetBySomethingAsync(Func<Like, bool> predicate, CancellationToken cancellationToken)
        {
            var query = _databaseContext.Set<Like>().AsQueryable();
            foreach (var propertyInfo in typeof(Like).GetProperties())
            {
                var parameter = Expression.Parameter(typeof(Like), "x");
                var propertyAccess = Expression.Property(parameter, propertyInfo);
                var value = Expression.Constant(propertyInfo.GetValue(predicate.Target));
                var condition = Expression.Equal(propertyAccess, value);
                var lambda = Expression.Lambda<Func<Like, bool>>(condition, parameter);
                query = query.Where(lambda);
            }

            return await query
                      .AsNoTracking()
                      .FirstOrDefaultAsync(cancellationToken);

        }
        public void UpdateAsync(Like like)
        {
            _databaseContext.Update(like);
        }
    }
}
