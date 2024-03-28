using BookStore.BusinessLogic.Dtos.Comments;
using BookStore.DataAccess.Models;

namespace BookStore.BusinessLogic.Interfaces
{
    public interface ICommentService: IBaseService<CommentDto>
    {
        Task<CommentDto> GetCommentByCreationDateTimeAsync(DateTime creationDateTime, CancellationToken cancellationToken);
        Task<CommentDto> GetCommentByCommentTextAsync(string commentText, CancellationToken cancellationToken);    
    }
}
