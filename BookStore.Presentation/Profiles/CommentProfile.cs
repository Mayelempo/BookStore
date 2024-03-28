using AutoMapper;
using BookStore.BusinessLogic.Dtos.Comments;
using BookStore.DataAccess.Models;

namespace BookStore.Presentation.Profiles
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<CommentDto, Comment>()
                .ReverseMap();
        }
    }
}
