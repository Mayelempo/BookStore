using BookStore.BusinessLogic.Dtos.Categories;
using BookStore.DataAccess.Models;

namespace BookStore.BusinessLogic.Interfaces
{
    public interface ICategoryService : IBaseService<CategoryDto>
    {
        Task<CategoryDto> GetCategoryByNameAsync(string categoryName, CancellationToken cancellationToken);  
    }
}
