using BookStore.DataAccess.DataContext;
using BookStore.DataAccess.Entities;
using BookStore.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace BookStore.DataAccess.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly DatabaseContext _databaseContext;
        public BookRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public void AddAsync(Book book)
        {
            _databaseContext.Add(book); 
         }

        public void DeleteAsync(Book book)
        {
            _databaseContext.Remove(book);
        }

        public async Task<List<Book>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await  _databaseContext
                          .Books
                          .AsNoTracking()
                          .ToListAsync(cancellationToken);
        }

        public async Task<Book> GetBySomethingAsync(Func<Book, bool> predicate, CancellationToken cancellationToken)
        {
            var query = _databaseContext.Set<Book>().AsQueryable();
            foreach (var propertyInfo in typeof(Book).GetProperties())
            {
                var parameter = Expression.Parameter(typeof(Book), "x");
                var propertyAccess = Expression.Property(parameter, propertyInfo);
                var value = Expression.Constant(propertyInfo.GetValue(predicate.Target));
                var condition = Expression.Equal(propertyAccess, value);
                var lambda = Expression.Lambda<Func<Book, bool>>(condition, parameter);
                query = query.Where(lambda);
            }
            
            return await query 
                      .AsNoTracking()
                      .FirstOrDefaultAsync(cancellationToken);
                
        }

        public void UpdateAsync(Book book)
        {
            _databaseContext.Update(book);
        }
    }
}
