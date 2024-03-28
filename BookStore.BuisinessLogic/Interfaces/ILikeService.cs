using BookStore.BusinessLogic.Dtos.Likes;
using BookStore.DataAccess.Models;

namespace BookStore.BusinessLogic.Interfaces
{
    public interface ILikeService: IBaseService<LikeDto>
    {
        Task<LikeDto> GetLikeByCreationDateTimeAsync (DateTime creationDateTime, CancellationToken cancellationToken); 
    } 
}
