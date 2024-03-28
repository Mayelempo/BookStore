using AutoMapper;
using BookStore.BusinessLogic.Dtos.Categories;
using BookStore.DataAccess.Models;

namespace BookStore.Presentation.Profiles
{
    public class CategoryProfile :Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryDto, Category>()
                .ReverseMap();
        }
    }
}
