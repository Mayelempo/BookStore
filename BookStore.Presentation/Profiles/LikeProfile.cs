using AutoMapper;
using BookStore.BusinessLogic.Dtos.Likes;
using BookStore.DataAccess.Models;

namespace BookStore.Presentation.Profiles
{
    public class LikeProfile:Profile
    {
        public LikeProfile()
        {
            CreateMap<LikeDto, Like>()
                .ReverseMap();
        }
    }
}
