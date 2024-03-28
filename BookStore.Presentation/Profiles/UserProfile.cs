using AutoMapper;
using BookStore.BusinessLogic.Dtos.Users;
using BookStore.DataAccess.Entities;

namespace BookStore.Presentation.Profiles
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<UserCreateDto, User>()
            .ReverseMap();

            CreateMap<UserReadDto, User>()
           .ReverseMap();
        }
    }
}
