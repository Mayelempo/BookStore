using BookStore.BusinessLogic.Dtos.Books;
using BookStore.DataAccess.Entities;

namespace BookStore.BusinessLogic.Interfaces
{
    public interface IBookService: IBaseService<BookDto>
    {
        Task<BookDto> GetBookByNameAsync(string bookName, CancellationToken cancellationToken);
        Task<BookDto> GetBookByDescriptionAsync(string bookDescription, CancellationToken cancellationToken);  
    }
}
