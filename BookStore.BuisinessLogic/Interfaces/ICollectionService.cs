using BookStore.BusinessLogic.Dtos.Collections;
using BookStore.DataAccess.Models;

namespace BookStore.BusinessLogic.Interfaces
{
    public interface ICollectionService: IBaseService<CollectionDto>
    {
        Task<CollectionDto> GetCollectionByNameAsync(string collectionName, CancellationToken cancellationToken);
        Task<CollectionDto> GetCollectionByTagAsync(string tag , CancellationToken cancellationToken);
        Task<CollectionDto> GetCollectionByDescriptionAsync(string description , CancellationToken cancellationToken); 
    }
}
