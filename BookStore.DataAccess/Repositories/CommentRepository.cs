using BookStore.DataAccess.DataContext;
using BookStore.DataAccess.Interfaces;
using BookStore.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BookStore.DataAccess.Repositories
{
    public class CommentRepository : ICommentRepository 
    {
        private readonly DatabaseContext _databaseContext;
        public CommentRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void AddAsync(Comment comment)
        {
            _databaseContext.Add(comment);

        }

        public void DeleteAsync(Comment comment)
        {
            _databaseContext.Remove(comment);
        }

        public async Task<List<Comment>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _databaseContext
                         .Comments
                         .AsNoTracking()
                         .ToListAsync(cancellationToken);
        }

        public async Task<Comment> GetBySomethingAsync(Func<Comment, bool> predicate, CancellationToken cancellationToken)
        {
            var query = _databaseContext.Set<Comment>().AsQueryable();
            foreach (var propertyInfo in typeof(Comment).GetProperties())
            {
                var parameter = Expression.Parameter(typeof(Comment), "x");
                var propertyAccess = Expression.Property(parameter, propertyInfo);
                var value = Expression.Constant(propertyInfo.GetValue(predicate.Target));
                var condition = Expression.Equal(propertyAccess, value);
                var lambda = Expression.Lambda<Func<Comment, bool>>(condition, parameter);
                query = query.Where(lambda);
            }

            return await query
                     .AsNoTracking()
                     .FirstOrDefaultAsync(cancellationToken);

        }
        public void UpdateAsync(Comment comment)
        {
            _databaseContext.Update(comment); 
        }
    }
}
