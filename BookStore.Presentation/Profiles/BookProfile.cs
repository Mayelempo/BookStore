using AutoMapper;
using BookStore.BusinessLogic.Dtos.Books;
using BookStore.DataAccess.Entities;

namespace BookStore.Presentation.Profiles
{
    public class BookProfile:Profile
    {
        public BookProfile()
        {
            CreateMap<BookDto, Book>()
            .ReverseMap();
        }
    }
}
